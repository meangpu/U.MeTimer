using UnityEngine;

namespace Meangpu.timer
{
    public class Timer : MonoBehaviour
    {
        protected bool _isCounting;
        protected float _secondsCount;
        protected int _minuteCount;
        protected int _hourCount;

        protected int GetTimeSecond() => (int)((_hourCount * 360) + (_minuteCount * 60) + _secondsCount);

        protected void CountStart() => _isCounting = true;
        protected void CountStop() => _isCounting = false;

        protected void RestartTimer()
        {
            _secondsCount = 0;
            _minuteCount = 0;
            _hourCount = 0;
            CountStop();

            UpdateTimerUI();
        }

        void Update() => UpdateTimerUI();

        virtual protected void UpdateTimerUI()
        {
            if (!_isCounting) return;

            _secondsCount += Time.deltaTime;

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
            UpdateTimerUI();
        }
    }
}
