using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Slider _sliderContainer;
    [SerializeField] private bool canShoot;

    private void Update()
    {
        if (canShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("d");
                _sliderContainer.gameObject.SetActive(true);
                _sliderContainer.value = _sliderContainer.minValue;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log("u");
                _sliderContainer.gameObject.SetActive(false);
                CannonController.instance.CannonShoot();
                canShoot = false; // only one shot lock
            }
        }
    }


    #region AnimatorValues
    public void OnCanonReloaded()
    {
        canShoot = true;
    }
    #endregion

}
