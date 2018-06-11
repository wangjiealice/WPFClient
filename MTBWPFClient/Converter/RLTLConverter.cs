using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFClient
{
    class RLTLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is short)
            {
                short RLTL = (short)value;
                if((string)parameter == "RL")
                {
                    if (RLTL == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if((string)parameter == "TL")
                {
                    if (RLTL == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                if (parameter.ToString() == "RL")
                {

                    return 1;
                }
                else if (parameter.ToString() == "TL")
                {
                    return 2;
                }
            }

            return null;
        }
    }
}
