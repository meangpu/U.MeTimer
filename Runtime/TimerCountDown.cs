using UnityEngine;

namespace Meangpu.Timer
{
    public class TimerCountDown : TimerCountUp
    {
        protected override void DoTimeTick()
        {
            if (!_isCounting) return;
            _secondsCount -= Time.deltaTime;
            ConvertSecondToMinuteHour();
        }
    }
}
