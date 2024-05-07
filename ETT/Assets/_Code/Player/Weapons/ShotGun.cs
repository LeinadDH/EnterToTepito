using UnityEngine;
using UnityEngine.InputSystem;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private int _bulletsAmount = 2;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;
    [Space(5f)]
    [SerializeField] private InputAction fireAction;
    
    private void Awake()
    {
        fireAction.performed += ctx => Shoot();
    }
    
    private void OnEnable()
    {
        fireAction.Enable();
    }
    
    private void OnDisable()
    {
        fireAction.Disable();
    }
    
    private void Shoot()
    {
        if(_bulletsAmount > 0)
        {
            Instantiate(_projectilePrefab, _spawnPoint.position, this.transform.rotation).Init(transform.right);
            _bulletsAmount--;
        }
    }
}
