using UnityEngine;
using UnityEngine.Events;

public class CannonReloadTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCannonReloadFinished;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out DragMouseObject dragMouseScipt))
        {
            Debug.Log("Reloading cannon");
            OnCannonReloadFinished.Invoke(); // invoke anim "ToShoot"
            Destroy(dragMouseScipt.gameObject); //destroy reloaded bullet!
        }
    }
}