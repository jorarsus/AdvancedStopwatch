using AdvancedStopwatch.Model;

namespace AdvancedStopwatch.ViewModel
{
    internal class NewAlarmViewModel
    {
        public NewAlarmModel Alarm { get; set; }

        public NewAlarmViewModel()
        {
            Alarm = new NewAlarmModel();
        }
    }
}