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

        public string CalculationLine { get; set; }


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
