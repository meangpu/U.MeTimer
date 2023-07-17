namespace Meangpu.Timer
{
    public class TimerCountUp : Timer
    {
        protected override void Tick()
        {
            _secondsCount++;
            if (!_useMinuteHour) return;
            ConvertSecondToMinuteHour();
        }
    }
}
