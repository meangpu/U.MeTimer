using UnityEngine;
using TMPro;

namespace Meangpu.timer
{
    public class TimerTextDisplay : Timer
    {
        private string _textTimer;
        [SerializeField] TMP_Text _text;

        protected override void UpdateTimerUI()
        {
            base.UpdateTimerUI();
            _textTimer = $"{_minuteCount:D2}:{(int)_secondsCount:D2}";
            _text.SetText(_textTimer);
        }

    }

}