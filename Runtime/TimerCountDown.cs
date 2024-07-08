using UnityEngine;
using UnityEngine.Events;

namespace Meangpu.Timer
{
    public class TimerCountDown : Timer
    {
        [SerializeField] UnityEvent _onTimeReachZero;
        protected override void Tick()
        {
            _secondsCount--;
            if (_secondsCount <= 0)
            {
                _secondsCount = 0;
                _onTimeReachZero?.Invoke();
            }
            if (!_useMinuteHour) return;
            ConvertSecondToMinuteHour();
        }

        public void DoStartTimerDown(float secondCountDown)
        {
            SetupTimer(secondCountDown);
            DoStartTimer();
        }

        protected override bool IsTimerIsUp() => GetTimeSecond() <= 0;
    }
}
