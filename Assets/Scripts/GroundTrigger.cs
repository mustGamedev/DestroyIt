using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private int maxBulletTry = 3;
    [SerializeField] private float _timeBeforeFinish = 2f;
    [SerializeField] private UnityEvent OnBulletHitGround;

    public int MaxBulletTry
    { 
        get=> maxBulletTry;
        set
        {
            maxBulletTry = value;
            OnBulletHitGround.Invoke();
            if(maxBulletTry == 0)
            {
                StartCoroutine(FinishDelay());
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent(out CannonBullet bullet))
        {
            MaxBulletTry -=1;
        }
    }

    IEnumerator FinishDelay()
    {
        yield return new WaitForSeconds(_timeBeforeFinish);
        CoreSystemUI.instance.SetGameCoreState(false);
    }
}
