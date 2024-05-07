using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isShotgun = false;
    [SerializeField] private Animator _animator;

    private void OnDisable()
    {
        if (_isShotgun)
        {
            _animator.SetBool("Destroy", false);
            CircleCollider2D circleCollider2D = this.gameObject.GetComponent<CircleCollider2D>();
            if (circleCollider2D != null)
            {
                Destroy(circleCollider2D);
            }
        }
    }

    public void Init(Vector2 Dir)
    {
        _rb.velocity = Dir * _speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Projectile"))
        {
            if (_isShotgun)
            {
                _rb.velocity = Vector2.zero;
                CircleCollider2D circleCollider2D = this.gameObject.AddComponent<CircleCollider2D>();
                circleCollider2D.isTrigger = true;
                circleCollider2D.radius = 2.0f;
                _animator.SetBool("Destroy", true);
                Invoke("DesactivarObjeto", 0.5f);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    
    private void DesactivarObjeto()
    {
        gameObject.SetActive(false);
    }
}
