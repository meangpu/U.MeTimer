using System;
using TMPro;

namespace Meangpu.Timer
{
    public class TimerDownTextDisplay : TimerCountDown
    {
        protected string _textTimer;
        public TMP_Text _text;

        protected override void DoTimeTick()
        {
            base.DoTimeTick();
            UpdateTextUI();
        }

        virtual protected void UpdateTextUI()
        {
            _textTimer = $"{_minuteCount:D2}:{(int)_secondsCount:D2}";
            _text.SetText(_textTimer);
        }
    }
}