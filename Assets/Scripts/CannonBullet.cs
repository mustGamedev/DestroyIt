using UnityEngine;
using CreativeVeinStudio.Simple_Pool_Manager;

public class CannonBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        DespawnObject();
    }

    private void OnBecameInvisible()
    {
        DespawnObject();
    }

    ///<summary>Despawn object with zero velocity</summary>
    private void DespawnObject()
    {
        SPManager.instance.DisablePoolObject("CanonBalls",this.transform);
        this.GetComponent<Rigidbody>().Sleep();
    }
}
