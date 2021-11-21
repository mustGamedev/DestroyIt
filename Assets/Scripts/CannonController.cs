using UnityEngine;
using CreativeVeinStudio.Simple_Pool_Manager;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public static CannonController instance;

    [Header("Place prefabs here")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Set your shooting settings")]
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _shootPower = 2f;

    [Header("Set your shooting settings")]
    [SerializeField] private Slider _gameSlider;

    private Rigidbody _bulletPrefabRigidBody;
    private Animator _cannonAnimator;

    private void Awake()
    {
        instance = this;
        _cannonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){ CannonShoot(); }

        _shootPower = _gameSlider.value;
    }

    ///<summary>Shoots bullet from cannon</summary>
    public void CannonShoot()
    {
        _cannonAnimator.Play("Armature_animShoot");

        //GameObject bulletCopy = Instantiate(_bulletPrefab, _shootPosition.position, transform.rotation) as GameObject;
        GameObject bulletCopy = SPManager.instance.GetNextAvailablePoolItem("CanonBalls") as GameObject;
        bulletCopy.transform.position = _shootPosition.position;
        bulletCopy.transform.rotation = _shootPosition.rotation;
        bulletCopy.SetActive(true);

        _bulletPrefabRigidBody = bulletCopy.GetComponent<Rigidbody>();
        _bulletPrefabRigidBody.AddForce(transform.forward * _shootPower*1000f);
    }

}