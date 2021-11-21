using UnityEngine;
using CreativeVeinStudio.Simple_Pool_Manager;

public class CannonBullet : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private float _bulletForce = 5f;
    [SerializeField] private float _forceRadius = 3f;
    [SerializeField] private float _upForce = 1f;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "SimpleCollectible")
        {
            AddExplotion();
            DespawnObject();
        }
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("<color=red>недолет</color>");
            DespawnObject();
        }
    }

    private void OnBecameInvisible()
    {
        DespawnObject();
    }

    ///<summary>Despawn object with zero velocity</summary>
    public void DespawnObject()
    {
        SPManager.instance.DisablePoolObject("CanonBalls",this.transform);
        this.GetComponent<Rigidbody>().Sleep();
    }

    ///<summary>Adds explotion forward velocity to collider surface</summary>
    private void AddExplotion()
    {
        Vector3 explotionPosition = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explotionPosition, _forceRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            if(rigidbody !=null)
            {
                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(_bulletForce, explotionPosition, _forceRadius, _upForce, ForceMode.Impulse);
            }
        }
    }
}