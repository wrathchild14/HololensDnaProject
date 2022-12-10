using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utility
{
    public class ScalePositionController : MonoBehaviour
    {
        [FormerlySerializedAs("multiplier")] [SerializeField] private float posMultiplier = 10;

        public void OnSliderScaleUpdated(SliderEventData eventData)
        {
            var sliderSliderValue = eventData.Slider.SliderValue + 0.5f;
            transform.localScale = new Vector3(sliderSliderValue, sliderSliderValue, sliderSliderValue);
        }

        public void OnSliderPositionUpdated(SliderEventData eventData)
        {
            var sliderSliderValue = eventData.Slider.SliderValue + 0.5f;
            transform.position =
                new Vector3(transform.position.x, transform.position.y, sliderSliderValue * posMultiplier - 100f);
        }
    }
}