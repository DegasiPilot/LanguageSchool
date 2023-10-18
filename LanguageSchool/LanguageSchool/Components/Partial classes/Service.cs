using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LanguageSchool.Components
{
    public partial class Service
    {
        public decimal TotalCost
        {
            get 
            {
                if (Discount != 0)
                {
                    return Cost - Cost * ((decimal)Discount);
                }
                else
                {
                    return Cost;
                }
            }
        }

        public string CostTime
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost : 0} рублей за {DurationInSeconds/60} минут";
                else
                    return $"{Cost - Cost * ((decimal)Discount) : 0} рублей за {DurationInSeconds / 60} минут";
            }
        }

        public Visibility CostVisiblity
        {
            get
            {
                if (Discount == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public string TextDiscount
        {
            get
            {
                if (Discount == 0)
                    return null;
                else
                    return $"* скидка {Discount * 100}%";
            }
        }

        public Brush DicountBrush
        {
            get
            {
                if (Discount != 0)
                {
                    return Brushes.PaleGreen;
                }
                else
                    return Brushes.White;
            }
        }
    }
}
