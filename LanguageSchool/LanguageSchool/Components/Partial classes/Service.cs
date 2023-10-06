using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool.Components
{
    public partial class Service
    {
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
    }
}
