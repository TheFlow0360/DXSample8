using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DXSample8
{
    public class AddressStateToBrushConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            AddressState status;
            if (value is AddressState)
            {
                status = (AddressState)value;
            }
            else if (value is AddressStateWrapper)
            {
                var adressWrapper = (AddressStateWrapper)value;
                if (adressWrapper?.State != null)
                {
                    status = adressWrapper.State.Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    status = (AddressState)((Int16)value);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            switch (status)
            {
                case AddressState.Major:
                    return new SolidColorBrush(Colors.Green);
                case AddressState.Normal:
                    return new SolidColorBrush(Colors.Blue);
                case AddressState.Minor:
                    return new SolidColorBrush(Colors.Yellow);
                case AddressState.Blocked:
                    return new SolidColorBrush(Colors.Red);
                default:
                    return null;
            }
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class AddressStateToCaptionConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return NullString;
            }

            AddressState status;
            if (value is AddressState)
            {
                status = (AddressState)value;
            }
            else if (value is AddressStateWrapper)
            {
                var adressWrapper = (AddressStateWrapper)value;
                if (adressWrapper?.State != null)
                {
                    status = adressWrapper.State.Value;
                }
                else
                {
                    return NullString;
                }
            }
            else
            {
                try
                {
                    status = (AddressState)((Int16)value);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            switch (status)
            {
                case AddressState.None:
                    return "<None>";
                case AddressState.Major:
                    return "Major";
                case AddressState.Normal:
                    return "Normal";
                case AddressState.Minor:
                    return "Minor";
                case AddressState.Blocked:
                    return "Blocked";
                default:
                    return null;
            }
        }

        private string NullString => "<All>";

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}