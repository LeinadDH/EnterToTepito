using System;
using UnityEngine;

public class CrosshairLogic : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mousePosition;
    public SpriteRenderer _weaponRenderer;
    public SpriteRenderer _characterRenderer;
    private int _initialLayer = 12;
    
    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = _mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        RotateWeapon();
    }
    
    private void RotateWeapon()
    {
        Vector2 direction = (_mousePosition - (Vector3)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            _weaponRenderer.sortingOrder = _characterRenderer.sortingOrder - 1;
        }
        else
        {
            _weaponRenderer.sortingOrder = _initialLayer;
        }
    }
}
