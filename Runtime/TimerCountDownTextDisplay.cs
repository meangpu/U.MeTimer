using TMPro;

namespace Meangpu.Timer
{
    public class TimerCountDownTextDisplay : TimerCountDown
    {
        private string _textTimer;
        public TMP_Text _text;

        protected override void UpdateTimerUI()
        {
            base.UpdateTimerUI();
            _textTimer = $"{(int)_secondsCount:D2}";
            _text.SetText(_textTimer);
        }
    }
}