using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    void Start()
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
            ObjectPooler.EnqueueObject(this, "Enemy");
        }
    }
}
