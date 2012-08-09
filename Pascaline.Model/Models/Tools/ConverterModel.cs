using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascalines.Model.Tools
{
    public partial class ConverterModel : BaseModel
    {
        private string _calculationLine;
        public string CalculationLine
        {
            get
            {
                return _calculationLine;
            }
            set
            {
                if (_calculationLine == value) return;
                _calculationLine = value;
                RaisePropertyChanged<string>(() => CalculationLine);
            }
        }

        private decimal _calculationLineResult;
        public decimal CalculationLineResult
        {
            get
            {
                return _calculationLineResult;
            }
            set
            {
                if (_calculationLineResult == value) return;
                _calculationLineResult = value;
                RaisePropertyChanged<decimal>(() => CalculationLineResult);
            }
        }

        private decimal _percentage;
        public decimal Percentage
        {
            get
            {
                return _percentage;
            }
            set
            {
                if (_percentage == value) return;
                _percentage = value;
                RaisePropertyChanged<decimal>(() => Percentage);
            }
        }

        private decimal _percentageValue;
        public decimal PercentageValue
        {
            get
            {
                return _percentageValue;
            }
            set
            {
                if (_percentageValue == value) return;
                _percentageValue = value;
                RaisePropertyChanged<decimal>(() => PercentageValue);
            }
        }

        private decimal _referenceAmount;
        public decimal ReferenceAmount
        {
            get
            {
                return _referenceAmount;
            }
            set
            {
                if (_referenceAmount == value) return;
                _referenceAmount = value;
                RaisePropertyChanged<decimal>(() => ReferenceAmount);
            }
        }

        private decimal _percentVAT; //% TVA
        public decimal PercentVAT
        {
            get
            {
                return _percentVAT;
            }
            set
            {
                if (_percentVAT == value) return;
                _percentVAT = value;
                RaisePropertyChanged<decimal>(() => PercentVAT);
            }
        }

        private decimal _valueVAT; // valeur TVA
        public decimal ValueVAT
        {
            get
            {
                return _valueVAT;
            }
            set
            {
                if (_valueVAT == value) return;
                _valueVAT = value;
                RaisePropertyChanged<decimal>(() => ValueVAT);
            }
        }

        private decimal _allTaxesExcluded; // HT
        public decimal AllTaxesExcluded
        {
            get
            {
                return _allTaxesExcluded;
            }
            set
            {
                if (_allTaxesExcluded == value) return;
                _allTaxesExcluded = value;
                RaisePropertyChanged<decimal>(() => AllTaxesExcluded);
            }
        }

        private decimal _inclusiveOfTaxes; // TTC
        public decimal InclusiveOfTaxes
        {
            get
            {
                return _inclusiveOfTaxes;
            }
            set
            {
                if (_inclusiveOfTaxes == value) return;
                _inclusiveOfTaxes = value;
                RaisePropertyChanged<decimal>(() => InclusiveOfTaxes);
            }
        }

        private decimal _markupRage; // TM (taux de marque)
        public decimal MarkupRage
        {
            get
            {
                return _markupRage;
            }
            set
            {
                if (_markupRage == value) return;
                _markupRage = value;
                RaisePropertyChanged<decimal>(() => MarkupRage);
            }
        }

        private decimal _k;
        public decimal K
        {
            get
            {
                return _k;
            }
            set
            {
                if (_k == value) return;
                _k = value;
                RaisePropertyChanged<decimal>(() => K);
            }
        }

        private decimal _crudeProfit; // Marge brute
        public decimal CrudeProfit
        {
            get
            {
                return _crudeProfit;
            }
            set
            {
                if (_crudeProfit == value) return;
                _crudeProfit = value;
                RaisePropertyChanged<decimal>(() => CrudeProfit);
            }
        }

        private decimal _sellingPriceAllTaxeExcluded; // prix de vente HT
        public decimal SellingPriceAllTaxeExcluded
        {
            get
            {
                return _sellingPriceAllTaxeExcluded;
            }
            set
            {
                if (_sellingPriceAllTaxeExcluded == value) return;
                _sellingPriceAllTaxeExcluded = value;
                RaisePropertyChanged<decimal>(() => SellingPriceAllTaxeExcluded);
            }
        }

    }
}

