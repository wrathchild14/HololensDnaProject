using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace Utility
{
    public class ScalePositionController : MonoBehaviour
    {
        public void OnSliderUpdated(SliderEventData eventData)
        {
            var sliderSliderValue = eventData.Slider.SliderValue;
            transform.localScale = new Vector3(sliderSliderValue, sliderSliderValue, sliderSliderValue);
        }
    }
}