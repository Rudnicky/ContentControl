using ContentControlPoC.Interfaces;
using System;
using System.Timers;

namespace ContentControlPoC.Utils
{
    public class ClockManager : IClockManager
    {
        private Timer _timer;
        private const int INTERVAL = 1000;

        public event EventHandler OnTimeEllapsed;

        public ClockManager()
        {
            _timer = new Timer();
            _timer.Interval = INTERVAL;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Enabled = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnTimeEllapsed?.Invoke(sender, e);
        }

        public void CallEvery(int timeInMilliseconds)
        {
            if (_timer != null)
            {
                if (_timer.Enabled)
                {
                    _timer.Enabled = false;
                }
                _timer.Interval = timeInMilliseconds;
            }
        }

        public void Start()
        {
            if (_timer != null && !_timer.Enabled)
            {
                _timer.Enabled = true;
            }
        }

        public void Stop()
        {
            if (_timer != null && _timer.Enabled)
            {
                _timer.Enabled = false;
            }
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Elapsed -= Timer_Elapsed;
            }
        }
    }
}
