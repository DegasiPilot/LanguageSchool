using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LanguageSchool.Components
{
    public partial class ClientService
    {
        public DateTime EndTime
        {
            get{
                return StartTime.AddSeconds(Service.DurationInSeconds);
            }
        }

        public string RemainingTime
        {
            get { 
                return (StartTime - DateTime.Now).ToString(@"hh\:mm"); 
            }
        }

        public string ColorTime
        {
            get
            {
                if (StartTime - DateTime.Now < new TimeSpan(1,0,0))
                    return "Red";
                else
                    return "Black";
            }
        }
    }
}
