using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Pascalines.MyData
{
    /// <summary>
    /// Base class for <see cref="MyTileItem"/> and <see cref="MyTilesGroup"/> that
    /// defines properties common to both.
    /// </summary>    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class MyDataCommon : Pascalines.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public MyDataCommon(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._subtitle = subtitle;
            this._description = description;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get { return this._subtitle; }
            set { this.SetProperty(ref this._subtitle, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(MyDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }
    }

    /// <summary>
    /// Generic tile data model.
    /// </summary>
    public class MyTileItem : MyDataCommon
    {
        public MyTileItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content, MyTilesGroup group)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private MyTilesGroup _group;
        public MyTilesGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class MyTilesGroup : MyDataCommon
    {
        public MyTilesGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
        }

        private ObservableCollection<MyTileItem> _items = new ObservableCollection<MyTileItem>();
        public ObservableCollection<MyTileItem> Items
        {
            get { return this._items; }
        }

        public IEnumerable<MyTileItem> TopItems
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed
            get { return this._items.Take(12); }
        }

        private ObservableCollection<MyTilesGroup> _groups = new ObservableCollection<MyTilesGroup>();
        public ObservableCollection<MyTilesGroup> Groups
        {
            get { return this._groups; }
        }

        public IEnumerable<MyTilesGroup> TopGroups
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed
            get { return this._groups.Take(12); }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// </summary>
    public sealed class MyDataSource
    {
        private static MyDataSource _myDataSource = new MyDataSource();

        private ObservableCollection<MyTilesGroup> _allGroups = new ObservableCollection<MyTilesGroup>();
        public ObservableCollection<MyTilesGroup> AllGroups
        {
            get { return this._allGroups; }
        }

        public static IEnumerable<MyTilesGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return _myDataSource.AllGroups;
        }

        public static IEnumerable<MyTilesGroup> GetMyGroups(string uniqueId)
        {
            var matches = _myDataSource.AllGroups.SelectMany(group => group.Groups).Where((sgroup) => sgroup.UniqueId.Equals(uniqueId));
            return matches.ToList();
        }

        public static MyTilesGroup GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _myDataSource.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static MyTilesGroup GetSubGroup(string uniqueId)
        {
            var matches = _myDataSource.AllGroups.SelectMany(group => group.Groups).Where((sgroup) => sgroup.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static MyTileItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _myDataSource.AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public MyDataSource()
        {
            //String ITEM_CONTENT = String.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
            //            "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

            #region Création du groupe Calculer

            var calculer = new MyTilesGroup("Calculer",
                    "Calculer",
                    "Calculer",
                    "Assets/DarkGray.png",
                    "Liste des calculatrices installées par catégories");


            #region Création des sous groupes "Vente", et "Achat" et "Outils" du groupe "Calculer"

            var calculerVente = new MyTilesGroup("CalculerVente",
                    "Calculer",
                    "Calculer - Vente",
                    "Assets/DarkGray.png",
                    "Contient la liste des calculatrices destinées aux calculs de ventes");

            var calculerAchat = new MyTilesGroup("CalculerAchat",
                    "Calculer",
                    "Calculer - Achat",
                    "Assets/DarkGray.png",
                    "Contient la liste des calculatrices destinées aux calculs d'achats");

            var calculerOutils = new MyTilesGroup("CalculerOutils",
                    "Calculer",
                    "Calculer - Outils",
                    "Assets/DarkGray.png",
                    "Contient un ensemble d'outils");

            #region Création des items du sous groupe "Vente"

            var calculetteCalculerPrixDeVente = new MyTileItem("Calculer-Vente-PrixDeVente",
                        "Calculette 3 Prix de Vente",
                        "Bla bla",
                        "imagePath",
                        "description",
                        "contenu",
                        calculerVente);

            #endregion

            #region Création des items du sous groupe "Achat"
            //TODO:
            #endregion

            #region Création des items du sous groupe "Outils"

            var calculetteCalculerConvertisseur = new MyTileItem("Calculer-Outils-Convertisseur",
                        "Calculette 1 Convertisseur",
                        "Bla bla",
                        "imagePath",
                        "description",
                        "contenu",
                        calculerOutils);

            #endregion

            #endregion

            calculerVente.Items.Add(calculetteCalculerPrixDeVente);
            calculerOutils.Items.Add(calculetteCalculerConvertisseur);

            calculer.Groups.Add(calculerVente);
            calculer.Groups.Add(calculerAchat);
            calculer.Groups.Add(calculerOutils);

            #endregion

            #region Création du groupe Acheter

            var acheter = new MyTilesGroup("Acheter",
                    "Acheter",
                    "Acheter",
                    "Assets/DarkGray.png",
                    "Liste des calculatrices en vente par catégories");


            #region Création des sous groupes "Vente", et "Achat" et "Outils" du groupe "Acheter"

            var acheterVente = new MyTilesGroup("AcheterVente",
                    "Acheter",
                    "Acheter - Vente",
                    "Assets/DarkGray.png",
                    "Contient la liste des calculatrices en vente destinées aux calculs de ventes");

            var acheterAchat = new MyTilesGroup("AcheterAchat",
                    "Acheter",
                    "Acheter - Achat",
                    "Assets/DarkGray.png",
                    "Contient la liste des calculatrices en vente destinées aux calculs d'achats");

            var acheterOutils = new MyTilesGroup("AcheterOutils",
                    "Acheter",
                    "Acheter - Outils",
                    "Assets/DarkGray.png",
                    "Contient un ensemble d'outils à acheter");

            #region Création des items du sous groupe "Vente"

            var calculetteAcheterPrixDeVente = new MyTileItem("Acheter-Vente-PrixDeVente",
                        "Calculette 3 Prix de Vente",
                        "Bla bla",
                        "imagePath",
                        "description",
                        "contenu",
                        calculerVente);

            #endregion

            #region Création des items du sous groupe "Achat"
            //TODO:
            #endregion

            #region Création des items du sous groupe "Outils"

            var calculetteAcheterConvertisseur = new MyTileItem("Acheter-Outils-Convertisseur",
                        "Calculette 1 Convertisseur",
                        "Bla bla",
                        "imagePath",
                        "description",
                        "contenu",
                        calculerOutils);

            #endregion

            #endregion

            acheterVente.Items.Add(calculetteAcheterPrixDeVente);
            acheterOutils.Items.Add(calculetteAcheterConvertisseur);

            acheter.Groups.Add(acheterVente);
            acheter.Groups.Add(acheterAchat);
            acheter.Groups.Add(acheterOutils);

            #endregion



            this.AllGroups.Add(calculer);
            this.AllGroups.Add(acheter);
            //TODO;

        }
    }

}
