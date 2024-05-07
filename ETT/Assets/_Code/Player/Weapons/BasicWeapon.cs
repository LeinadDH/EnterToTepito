using UnityEngine;
using UnityEngine.InputSystem;

public class BasicWeapon : MonoBehaviour
{
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
        Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity).Init(transform.right);
    }
}
