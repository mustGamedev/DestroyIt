using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderUI : MonoBehaviour
{
    [Header("Slider ping-pong velocity")]
    [SerializeField] private float _sliderSpeed = 0.03f;
    private Slider _sliderComponent;
    [SerializeField] private bool powerIsIncreasing;
    [SerializeField] private bool PowerBarON = true;

    private void Awake()
    {
        _sliderComponent = GetComponent<Slider>();
        _sliderComponent.value = _sliderComponent.minValue;
        powerIsIncreasing = true;
        StartCoroutine(UpdateSliderBar());
    }
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateSliderBar());
    }

    IEnumerator UpdateSliderBar()
    {
        while (PowerBarON == true)
        {
            if (powerIsIncreasing == false)
            {
                _sliderComponent.value -= _sliderSpeed;

                if (_sliderComponent.value <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing == true)
            {
                _sliderComponent.value += _sliderSpeed;

                if (_sliderComponent.value >= _sliderComponent.maxValue)
                {
                    powerIsIncreasing = false;
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}