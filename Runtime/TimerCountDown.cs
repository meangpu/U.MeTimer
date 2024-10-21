using UnityEngine;
using UnityEngine.Events;
using VInspector;

namespace Meangpu.Timer
{
    public class TimerCountDown : Timer
    {
        [SerializeField] UnityEvent _onTimeReachZero;
        protected float _maxTimer;

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

        [Button]
        public void DoStartTimerDown(float secondCountDown)
        {
            SetupTimer(secondCountDown);
            DoStartTimer();
        }

        public override void ResetTimer()
        {
            DoStopTimer();
            _minuteCount = 0;
            _hourCount = 0;
            _secondsCount = _maxTimer;
            UpdateTextUI();
        }


        public override void SetupTimer(float startSecond)
        {
            base.SetupTimer(startSecond);
            _maxTimer = startSecond;
        }

        protected override bool IsTimerIsUp() => GetTimeSecond() <= 0;
    }
}
