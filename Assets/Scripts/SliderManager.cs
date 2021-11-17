using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [Header("Slider ping-pong velocity")]
    [Range(1f,50f)] [SerializeField] private float _sliderDragPower = 5f;
    private float _sliderDragTime;
    private Slider _sliderUI;

    private void Awake()
    {
        _sliderUI = GetComponent<Slider>();
    }
    
    private void Update()
    {
        _sliderDragTime +=_sliderDragPower * Time.deltaTime;
        _sliderUI.value = Mathf.PingPong(_sliderDragTime, _sliderUI.maxValue);
    }
}
