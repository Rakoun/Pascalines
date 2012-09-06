using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace /*Pascalines.Views.Converters.Tools*/SLMultiBinding
{
    public class PercentageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal percentageValue = (decimal)values[0];
            decimal referenceAmount = (decimal)values[1];

            return (percentageValue / 100) * referenceAmount;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
