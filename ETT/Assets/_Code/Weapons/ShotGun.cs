using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private IntValue _maxCanon;
    [SerializeField] private IntValue _currentCanon;
    [SerializeField] private Transform _spawnPoint;
    [Space(5f)]
    [SerializeField] private InputAction fireAction;
    
    private void Awake()
    {
        fireAction.performed += ctx => Shoot();
    }

    private void Start()
    {
        _maxCanon.value = 2;
        _currentCanon.value = _maxCanon.value;
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
        if(_currentCanon.value > 0)
        {
            Projectile instance = ObjectPooler.DequeueObject<Projectile>("StrongBullet");
            instance.gameObject.SetActive(true);
            instance.transform.position = _spawnPoint.position;
            instance.transform.rotation = _spawnPoint.rotation;
            instance.Init(transform.right);
            _currentCanon.value--;
        }
    }
}
