using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Slider _gameSlider;
    [SerializeField] private bool _canShoot;

    private void Update()
    {
        if (_canShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gameSlider.gameObject.SetActive(true);
                _gameSlider.value = _gameSlider.minValue;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _gameSlider.gameObject.SetActive(false);
                CannonController.instance.CannonShoot();
                _canShoot = false; // only one shot lock
            }
        }
    }

    #region AnimatorValues
    public void OnCanonReloaded()
    {
        _canShoot = true;
    }
    #endregion
}
