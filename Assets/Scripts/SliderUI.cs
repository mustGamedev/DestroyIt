using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderUI : MonoBehaviour
{
    [Header("Slider ping-pong velocity")]
    [SerializeField] private float _sliderSpeed = 0.03f;
    private Slider _sliderComponent;

    [Header("Debug slider bar")]
    [SerializeField] private bool _isPowerIsIncreasing;
    [SerializeField] private bool _isPowerBarOn = true;

    private void Awake()
    {
        _sliderComponent = GetComponent<Slider>();
        _sliderComponent.value = _sliderComponent.minValue;
        _isPowerIsIncreasing = true;
        StartCoroutine(UpdateSliderBar());
    }
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateSliderBar());
    }

    IEnumerator UpdateSliderBar()
    {
        while (_isPowerBarOn == true)
        {
            if (_isPowerIsIncreasing == false)
            {
                _sliderComponent.value -= _sliderSpeed;

                if (_sliderComponent.value <= 0)
                {
                    _isPowerIsIncreasing = true;
                }
            }
            if (_isPowerIsIncreasing == true)
            {
                _sliderComponent.value += _sliderSpeed;

                if (_sliderComponent.value >= _sliderComponent.maxValue)
                {
                    _isPowerIsIncreasing = false;
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}