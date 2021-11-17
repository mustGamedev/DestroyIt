using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Place prefabs here")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Set your shooting settings")]
    [SerializeField] private Transform _shootPosition;
    [Range(0.1f,10f)] [SerializeField] private float _shootPower = 2f;

    private Rigidbody _bulletPrefabRigidBody;
    private Animator _cannonAnimator;

    private void Awake()
    {
        _cannonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CannonShoot();
        }
    }

    ///<summary>Shoot bullet from cannon</summary>
    public void CannonShoot()
    {
        _cannonAnimator.Play("Armature_animShoot");

        GameObject bulletCopy = Instantiate(_bulletPrefab, _shootPosition.position, transform.rotation) as GameObject;
        
        _bulletPrefabRigidBody = bulletCopy.GetComponent<Rigidbody>();
        _bulletPrefabRigidBody.AddForce(transform.forward * _shootPower*1000f);
    }

}