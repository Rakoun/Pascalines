using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pascalines.Framework;
using Pascalines.Services;

//TODO: il faudra utiliser un IMultiValueConverter et tout sera ok!

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
        public decimal CalculationLineResult { get; set; }

        // Deuxième ligne
        public string OrLabel
        {
            get { return "ou"; }//TODO: à globaliser
        }
        public string PercentageLabel
        {
            get { return "%"; }//TODO: à globaliser
        }
        /// <summary>
        /// Percentage = (PercentageValue * 100) / ReferenceAmount
        /// </summary>
        public decimal Percentage {get;set;}

        public string PercentageValueLabel
        {
            get { return "Valeur"; }//TODO: à globaliser
        }
        /// <summary>
        /// PercentageValue = (ReferenceAmount * Percentage) / 100
        /// </summary>
        public decimal PercentageValue { get; set; }

        public string ReferenceAmountLabel
        {
            get { return "Mt de Référence"; }//TODO: à globaliser
        }
        /// <summary>
        /// ReferenceAmount = (PercentageValue * 100) / Percentage
        /// </summary>
        public decimal ReferenceAmount { get; set; }

        // Troisième ligne
        public string AndLabel
        {
            get { return "et"; }//TODO: à globaliser
        }
        public string PercentVATLabel
        {
            get { return "% TVA"; }//TODO: à globaliser
        }
        public decimal Percent { get; set; }

        public string ValueVATLabel
        {
            get { return "Valeur"; }//TODO: à globaliser
        }
        public decimal ValueVAT { get; set; }

        public string AllTaxesExcludedLabel
        {
            get { return "Valeur HT"; }//TODO: à globaliser
        }
        public decimal AllTaxesExlcuded { get; set; }

        public string InclusiveOfTaxesLabel
        {
            get { return "Valeur TTC"; }//TODO: à globaliser
        }
        public decimal InclusiveOfTaxes { get; set; }

        //Quatrième ligne
        public string MarkupRateLabel
        {
            get { return "TM"; }//TODO: à globaliser
        }
        public decimal MarkupRate { get; set; }

        public string KLabel
        {
            get { return "K"; }//TODO: à globaliser
        }
        public decimal K { get; set; }

        public string CrudeProfitLabel
        {
            get { return "Mb"; }//TODO: à globaliser
        }
        public decimal CrudeProfit { get; set; }

        public string SellingPriceAllTaxeExcludedLabel
        {
            get { return "PV HT"; }//TODO: à globaliser
        }
        public decimal SellingPriceAllTaxeExcluded { get; set; }







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
