using AdvancedStopwatch.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace AdvancedStopwatch.Model
{
    public class AlarmModel : ModelBase
    {
        public event EventHandler Elapsed;

        public string Name { get; set; }

        public TimeSpan TimeRemaining => _timeRemaining;
        public string TimeRemainingString
        {
            get
            {
                return TimeRemaining.ToString(@"hh\:mm\:ss");
            }
        }

        public bool HasElapsed => TimeRemaining.TotalSeconds <= 0;

        private readonly TimeSpan _initialTimeRemaining;
        private DispatcherTimer _timer;

        private TimeSpan _interval = TimeSpan.FromSeconds(1);

        private TimeSpan _timeRemaining;

        private ICommand _toggleTimerCommand;
        public ICommand ToggleTimerCommand =>
            _toggleTimerCommand ?? (_toggleTimerCommand = new CommandHandler(ToggleTimer, !HasElapsed));
        private void ToggleTimer() => 
            _timer.IsEnabled = !_timer.IsEnabled;

        private ICommand _restartCommand;
        public ICommand RestartCommand =>
            _restartCommand ?? (_restartCommand = new CommandHandler(Restart, !HasElapsed));
        private void Restart()
        {
            Stop();

            _timeRemaining = _initialTimeRemaining;
            RefreshUi();

            Start();
        }

        public AlarmModel(TimeSpan timeRemaining, bool autoStart = true)
        {
            _initialTimeRemaining = _timeRemaining = timeRemaining;
            _timer = new DispatcherTimer() { Interval = _interval };

            if(autoStart)
            {
                Start();
            }
        }

        public void Start()
        {
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Tick -= Timer_Tick;
            _timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeRemaining = _timeRemaining.Subtract(_interval);
            RefreshUi();

            if (_timeRemaining.TotalSeconds == 0)
            {
                Stop();
                RefreshUi();
                OnElapsed();
            }
        }

        private void RefreshUi()
        {
            OnPropertyChanged(nameof(TimeRemainingString));
            OnPropertyChanged(nameof(HasElapsed));
        }

        private void OnElapsed()
        {
            Elapsed?.Invoke(this, new EventArgs());
        }
    }
}
