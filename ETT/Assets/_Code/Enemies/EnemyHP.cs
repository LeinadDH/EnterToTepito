using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private IntValue _enemiesKilled;
    [SerializeField] private IntValue _Score;
    [SerializeField] private IntValue _coins;
    private int maxHP = 100;
    private int currentHP;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("BasicBullet"))
        {
            TakeDamage(20);
        }
        else if(other.gameObject.CompareTag("StrongBullet"))
        {
            TakeDamage(50);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("StrongBullet"))
        {
            TakeDamage(50);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            int coinPercent = Random.Range(1, 5);
            
            if (coinPercent ==  1)
            {
                _coins.value += 1;
            }
            _Score.value += 100;
            _enemiesKilled.value++;
            ObjectPooler.EnqueueObject(this, "Enemy");
        }
    }
}
