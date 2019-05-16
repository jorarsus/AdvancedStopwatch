using AdvancedStopwatch.Model;
using AdvancedStopwatch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdvancedStopwatch.View
{
    /// <summary>
    /// Interaction logic for AlarmsView.xaml
    /// </summary>
    public partial class AlarmsView : UserControl
    {
        private AlarmsViewModel _dataContext;

        public AlarmsView()
        {
            InitializeComponent();

            DataContext = new AlarmsViewModel();
            _dataContext = DataContext as AlarmsViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newAlarmDialog = new NewAlarm();
            if(newAlarmDialog.ShowDialog() ?? false)
            {
                if(newAlarmDialog.DataContext is NewAlarmViewModel vm)
                {
                    var timeRemaining = TimeSpan.FromHours(vm.Alarm.Hours);
                    timeRemaining = timeRemaining.Add(TimeSpan.FromMinutes(vm.Alarm.Minutes));
                    timeRemaining = timeRemaining.Add(TimeSpan.FromSeconds(vm.Alarm.Seconds));

                    var alarm = new AlarmModel(timeRemaining) { Name = vm.Alarm.Name };
                    _dataContext.Alarms.Add(alarm);
                }
            }
        }
    }
}
