using System;
using System.Timers;

namespace ContentControlPoC.Interfaces
{
    public interface IClockManager
    {
        event EventHandler OnTimeEllapsed;

        void Start();

        void Stop();

        void CallEvery(int timeInMilliseconds);

        void Dispose();
    }
}
