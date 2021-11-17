using UnityEngine;
using UnityEngine.UI;
using GD.MinMaxSlider;

public class SliderManager : MonoBehaviour
{
    [Header("Slider ping-pong velocity")]
    [Range(0f,2f)] [SerializeField] private float _sliderDragPower = 0.5f;
    private float _sliderDragTime;
    private Slider _sliderUI;

    [Header("Debug")]
    [MinMaxSlider(0f,10f)] [SerializeField] private Vector2 _minMaxRangeGreen;
    [MinMaxSlider(0f,10f)] [SerializeField] private Vector2 _minMaxRangeOrange;
    [MinMaxSlider(0f,10f)] [SerializeField] private Vector2 _minMaxRangeRed;

    private void Awake()
    {
        _sliderUI = GetComponent<Slider>();
    }
    
    private void Update()
    {
        _sliderDragTime +=_sliderDragPower * Time.deltaTime;
        _sliderUI.value = Mathf.PingPong(_sliderDragTime, _sliderUI.maxValue);

        /*if(_sliderUI.value >= _minMaxRangeRed.x && _sliderUI.value <= _minMaxRangeRed.y)
        {
            Debug.Log("red");
        }
        if(_sliderUI.value >= _minMaxRangeOrange.x && _sliderUI.value <= _minMaxRangeOrange.y)
        {
            Debug.Log("orange");
        }
        if(_sliderUI.value >= _minMaxRangeGreen.x && _sliderUI.value <= _minMaxRangeGreen.y)
        {
            Debug.Log("green");
        }*/
    }
}
