using System;
using System.Diagnostics;

namespace Meangpu.Timer
{
    // from [Our Favorite Advanced C# Trick - YouTube](https://www.youtube.com/watch?v=DU472-5kd_s)
    public class DisposableStopWatch : IDisposable
    {
        private Stopwatch _stopwatch;

        public DisposableStopWatch()
        {
            // when enter this script, will do this, use by start with
            // using (new DisposableStopWatch()) {}
            _stopwatch = new();
            _stopwatch.Start();
        }

        public void Dispose()
        {
            // after end will do this
            _stopwatch.Stop();
            long elapse = _stopwatch.ElapsedMilliseconds;
            UnityEngine.Debug.Log($"took: {elapse} ms");
        }
    }
}
