using System.Collections;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    [SerializeField] private float _timeBeforeHit = 2f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent(out CannonBullet bullet))
        {
            StartCoroutine(WaitSomeTime());
        }
    }
    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(_timeBeforeHit);
        CoreSystemUI.instance.SetGameCoreState(true);
    }
}