using UnityEngine;
using UnityEngine.UI;

namespace Meangpu.Timer
{
    public class TimerCountDownImageFill : TimerCountDown
    {
        [SerializeField] Image _timerImage;

        protected override void DoTimeTick()
        {
            base.DoTimeTick();
            _timerImage.fillAmount = _secondsCount / _maxTimer;
        }
    }
}