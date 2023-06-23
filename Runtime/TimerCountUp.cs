using UnityEngine;

namespace Meangpu.Timer
{
    public class TimerCountUp : MonoBehaviour
    {
        protected bool _isCounting;
        protected float _secondsCount;
        protected int _minuteCount;
        protected int _hourCount;

        protected int GetTimeSecond() => (int)((_hourCount * 360) + (_minuteCount * 60) + _secondsCount);

        protected void CountStart() => _isCounting = true;
        protected void CountStop() => _isCounting = false;

        protected void ResetTimer()
        {
            _secondsCount = 0;
            _minuteCount = 0;
            _hourCount = 0;
            CountStop();

            DoTimeTick();
        }

        void Update() => DoTimeTick();

        virtual protected void DoTimeTick()
        {
            if (!_isCounting) return;
            _secondsCount += Time.deltaTime;
            ConvertSecondToMinuteHour();
        }

        virtual protected void SetupTimer(float startSecond)
        {
            _secondsCount = startSecond;
            DoTimeTick();
        }

        protected void ConvertSecondToMinuteHour()
        {
            if (_secondsCount >= 60)
            {
                _minuteCount++;
                _secondsCount = 0;
            }
            else if (_minuteCount >= 60)
            {
                _hourCount++;
                _minuteCount = 0;
            }
        }

        protected void AddTimerSec(float addNum)
        {
            _secondsCount += addNum;
            DoTimeTick();
        }
    }
}
