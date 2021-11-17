using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameObject _sliderContainer;
    [SerializeField] private bool canShoot = true;

    private void Awake()
    {
        //_sliderContainer = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (canShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("d");
                _sliderContainer.SetActive(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("u");
                _sliderContainer.SetActive(false);
                //fire
                CannonController.instance.CannonShoot();
                canShoot = false; // only one shot lock
            }
        }
    }

    public void OnCanonReloadFinished()
    {
        canShoot = true;
    }
}
