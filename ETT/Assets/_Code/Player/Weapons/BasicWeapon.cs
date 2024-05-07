using UnityEngine;
using UnityEngine.InputSystem;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;
    [Space(5f)]
    [SerializeField] private InputAction fireAction;
    
    private bool _isFiring = false; 
    private bool _canShoot = true;
    
    private void Awake()
    {
        fireAction.started += ctx => StartShooting();
        fireAction.canceled += ctx => StopShooting();
    }
    
    private void OnEnable()
    {
        fireAction.Enable();
    }
    
    private void OnDisable()
    {
        fireAction.Disable();
    }

    private void Update()
    {
        if (_isFiring && _canShoot)
        {
            Shoot();
            Invoke("CoolDown", 0.5f);
            _canShoot = false;
        }
    }
    
    private void StartShooting()
    {
        _isFiring = true;
    }
    
    private void StopShooting()
    {
        _isFiring = false;
    }
    
    private void Shoot()
    {
        Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity).Init(transform.right);
    }

    private void CoolDown()
    {
        _canShoot = true;
    }
}
