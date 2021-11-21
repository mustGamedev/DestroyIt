using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private int _maxAmmoBullets = 3;
    [SerializeField] private float _timeBeforeFinish = 2f;
    [SerializeField] private UnityEvent OnBulletHitGround;

    public int MaxBulletTry
    { 
        get=> _maxAmmoBullets;
        set
        {
            _maxAmmoBullets = value;
            OnBulletHitGround.Invoke();
            if(_maxAmmoBullets == 0)
            {
                StartCoroutine(WaitBeforeGameFinish());
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
    IEnumerator WaitBeforeGameFinish()
    {
        yield return new WaitForSeconds(_timeBeforeFinish);
        CoreSystemUI.instance.SetGameCoreState(false);
    }
}