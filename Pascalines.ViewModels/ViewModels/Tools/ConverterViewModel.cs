using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pascalines.Framework;
using Pascalines.Services;


namespace Pascalines.ViewModels.Tools
{
    public class ConverterViewModel : BaseViewModel
    {
        private IDialogService _windowServices;

        public ConverterViewModel() { }

        protected override void ServicesInitialization()
        {
            _windowServices
                = ServiceLocator.Instance.Retrieve<IDialogService>();
        }

        protected override void CommandsInitialization()
        {
            EraseAll = new ProxyCommand<ConverterViewModel>((_) =>
                {
                    CalculationLine = "";
                });
        }

        #region Elements d'affichage

        public string CalculatorName
        {
            get { return "Convertisseur"; }//TODO: à globaliser
        }

        // Première ligne
        public string BtEqualLabel
        {
            get { return "="; }//TODO: à globaliser
        }

        public string BtnCleanLabel
        {
            get { return "Effacer"; }//TODO: à globaliser
        }

        public string CalculationLineLabel
        {
            get { return "Ligne de calcul"; }//TODO: à globaliser
        }
        public string CalculationLine { get; set; }
        public string CalculationLineResult { get; set; }

        // Deuxième ligne
        public string OrLabel
        {
            get { return "ou"; }//TODO: à globaliser
        }
        public string PercentageLabel
        {
            get { return "%"; }//TODO: à globaliser
        }
        public string Percentage { get; set; }

        public string PercentageValueLabel
        {
            get { return "Valeur"; }//TODO: à globaliser
        }
        public string PercentageValue { get; set; }

        public string ReferenceAmountLabel
        {
            get { return "Mt de Référence"; }//TODO: à globaliser
        }
        public string ReferenceAmount { get; set; }






        #endregion //Elements d'affichage

        #region Commandes
        public ProxyCommand<ConverterViewModel> ComputeLine1 { get; set; }
        public ProxyCommand<ConverterViewModel> EraseLine1 { get; set; }
        public ProxyCommand<ConverterViewModel> EraseLine2 { get; set; }
        public ProxyCommand<ConverterViewModel> EraseLine3 { get; set; }
        public ProxyCommand<ConverterViewModel> EraseLine4 { get; set; }

        public ProxyCommand<ConverterViewModel> EraseAll { get; set; }
        public ProxyCommand<ConverterViewModel> Save { get; set; }
        public ProxyCommand<ConverterViewModel> Print { get; set; }
        public ProxyCommand<ConverterViewModel> Load { get; set; }

        #endregion //Commandes
    }
}
