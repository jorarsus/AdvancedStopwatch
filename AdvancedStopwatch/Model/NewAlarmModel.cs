using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedStopwatch.Model
{
    public class NewAlarmModel : IDataErrorInfo
    {
        public string Name { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

    }
}
