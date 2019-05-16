using AdvancedStopwatch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedStopwatch.ViewModel
{
    public class DesignAlarmsViewModel
    {
        public AlarmModel Alarm { get; set; }
            = new AlarmModel(TimeSpan.FromSeconds(60))
            {
                Name = "Alarm 1",
            };

        public ObservableCollection<AlarmModel> Alarms => 
            new ObservableCollection<AlarmModel>() { Alarm, Alarm, Alarm, Alarm };
    }
}
