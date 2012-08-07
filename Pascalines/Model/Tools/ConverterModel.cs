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
        private decimal _inclusiveOfTaxes; // TTC

        private decimal _markupRage; // TM (taux de marque)
        private decimal _k;

        private decimal _crudeProfit; // Marge brute
        private decimal _sellingPriceAllTaxeExcluded; // prix de vente HT

    }
}

