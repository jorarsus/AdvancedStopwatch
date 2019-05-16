using AdvancedStopwatch.Common;
using AdvancedStopwatch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdvancedStopwatch.ViewModel
{
    class AlarmsViewModel
    {
        public AlarmModel Alarm { get; set; }
            = new AlarmModel(TimeSpan.FromSeconds(20))
            {
                Name = "Alarm 1",
            };

        public ObservableCollection<AlarmModel> Alarms { get; set; }

        private ICommand _removeAlarmCommand;
        public ICommand RemoveAlarmCommand =>
            new RelayCommand(RemoveAlarm);

        private void RemoveAlarm(object alarm)
        {
            if(alarm is AlarmModel alarmModel)
            {
                Alarms.Remove(alarmModel);
            }
        }

        public AlarmsViewModel()
        {
            Alarms = new ObservableCollection<AlarmModel>()
            {
                Alarm,
            };
        }
    }
}
