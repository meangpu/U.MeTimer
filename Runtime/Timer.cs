using System.Collections;
using UnityEngine;
using TMPro;

namespace Meangpu.Timer
{
    public class Timer : MonoBehaviour
    {
        protected bool _isCounting;
        protected float _secondsCount;
        protected int _minuteCount;
        protected int _hourCount;

        public bool _useMinuteHour;
        protected WaitForSecondsRealtime _waitTime = new(1);
        protected IEnumerator TimerEnumerator;

        protected int GetTimeSecond() => (int)((_hourCount * 360) + (_minuteCount * 60) + _secondsCount);
        protected void CountStart() => _isCounting = true;

        protected void CountStop() => _isCounting = false;

        protected void DoStopTimer()
        {
            CountStop();
            StopAllCoroutines();
            TimerEnumerator = null;
        }

        [SerializeField] TMP_Text _text;

        private void Start()
        {
            if (_text == null) _text = GetComponent<TMP_Text>();
        }

        virtual protected void ResetTimer()
        {
            _secondsCount = 0;
            _minuteCount = 0;
            _hourCount = 0;
            DoStopTimer();
            UpdateTextUI();
        }

        virtual protected void DoTimeTick()
        {
            Tick();
            UpdateTextUI();
        }

        virtual protected void Tick() { }
        virtual protected void UpdateTextUI()
        {
            // if have hour create new inheritance change this line
            if (_useMinuteHour) _text.SetText(GetMinSecString());
            else _text.SetText(GetSecString());
        }

        virtual protected bool IsTimerIsUp() => false;

        IEnumerator StartTimer()
        {
            while (_isCounting)
            {
                DoTimeTick();
                yield return _waitTime;
                if (IsTimerIsUp())
                {
                    DoStopTimer();
                    break;
                }
            }
        }

        virtual public void DoStartTimer()
        {
            _isCounting = true;
            TimerEnumerator = StartTimer();
            StartCoroutine(TimerEnumerator);
        }

        virtual protected void SetupTimer(float startSecond)
        {
            _secondsCount = startSecond;
            UpdateTextUI();
        }

        protected string GetSecString() => GetTimeSecond().ToString();
        protected string GetMinSecString() => $"{_minuteCount:D2}:{(int)_secondsCount:D2}";
        protected string GetHourMinSecString() => $"{_hourCount:D2}:{_minuteCount:D2}:{(int)_secondsCount:D2}";

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
    }
}