using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{

    private void Awake()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject); //Use object pooling next update
    }
}
