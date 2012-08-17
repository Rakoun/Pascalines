using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

using Pascalines.MyData;
using Pascalines.Views;
using Pascalines.Views.Tools;


// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace Pascalines
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ItemsPage : Pascalines.Common.LayoutAwarePage
    {
        public ItemsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Assign a bindable collection of items to this.DefaultViewModel["Items"]
            var group = MyDataSource.GetSubGroup((string)navigationParameter);
            this.DefaultViewModel["Items"] = group.Items;
        }

        private async void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var myItem = ((MyTileItem)e.ClickedItem);

            switch (myItem.UniqueId)
            {
                case "Calculer-Vente-PrixDeVente":
                    {
                        //this.Frame.Navigate(typeof(SalePricePage), myItem);
                        var messageDialog =
                            new MessageDialog("Pas implémenté");
                        await messageDialog.ShowAsync();
                    }
                    break;
                case "Calculer-Outils-Convertisseur":
                    {
                        this.Frame.Navigate(typeof(ConverterPage), myItem);
                    }
                    break;
                default:
                    {
                        var messageDialog =
                            new MessageDialog(string.Format(
                                        "Impossible de trouver l'id {0}",
                                        myItem.UniqueId));
                        await messageDialog.ShowAsync();
                    }
                    break;
            }
        }
    }
}
