using UnityEngine;

namespace Meangpu
{
    public class Timer : MonoBehaviour
    {
        bool _isCounting;
        private float _secondsCount;
        private int _minuteCount;
        private int _hourCount;
        private string _textTimer;

        int GetTimeSecond() => (int)((_hourCount * 360) + (_minuteCount * 60) + _secondsCount);

        void CountStart() => _isCounting = true;
        void CountStop() => _isCounting = false;

        void RestartTimer()
        {
            _secondsCount = 0;
            _minuteCount = 0;
            _hourCount = 0;
            CountStop();

            UpdateTimerUI();
        }

        void Update() => UpdateTimerUI();

        void UpdateTimerUI()
        {
            if (!_isCounting) return;

            _secondsCount += Time.deltaTime;
            _textTimer = $"{_minuteCount:D2}:{(int)_secondsCount:D2}";
            // timerText.text = finalText;
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

        void AddTimerSec(float addNum)
        {
            _secondsCount += addNum;
            UpdateTimerUI();
        }
    }
}