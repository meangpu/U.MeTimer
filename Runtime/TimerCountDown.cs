namespace Meangpu.Timer
{
    public class TimerCountDown : Timer
    {
        protected override void Tick()
        {
            _secondsCount--;
            if (_secondsCount <= 0) _secondsCount = 0;
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
