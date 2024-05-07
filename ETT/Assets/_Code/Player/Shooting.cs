using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mousePosition;
    
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
    }
}
