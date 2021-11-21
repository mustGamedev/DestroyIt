using System.Collections;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    [Header("Time after bullet hitted the wall")]
    [SerializeField] private float _timeAfterHit = 2f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent(out CannonBullet bullet))
        {
            StartCoroutine(WaitAfterBulletHit());
        }
    }
    IEnumerator WaitAfterBulletHit()
    {
        yield return new WaitForSeconds(_timeAfterHit);
        CoreSystemUI.instance.SetGameCoreState(true);
    }
}