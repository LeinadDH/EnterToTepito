using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxShield = 50;
    public float shieldRegenRate = 2f;
    public float shieldRegenDelay = 5f;
    public Slider healthSlider;
    public Slider shieldSlider;

    private int currentHealth;
    private int currentShield;
    private float lastDamageTime;
    private float lastShieldRegenTime;

    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        lastDamageTime = Time.time;
        lastShieldRegenTime = Time.time;

        // Actualiza los valores iniciales de las barras deslizantes
        UpdateSliders();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    void Update()
    {
        if (Time.time - lastDamageTime > shieldRegenDelay)
        {
            RegenerateShield();
        }
    }

    void TakeDamage(int damage)
    {
        lastDamageTime = Time.time;

        if (currentShield > 0)
        {
            currentShield -= damage;
            if (currentShield < 0)
            {
                currentHealth += currentShield;
                currentShield = 0;
            }
        }
        else
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        // Actualiza las barras deslizantes después de recibir daño
        UpdateSliders();
    }

    void RegenerateShield()
    {
        if (Time.time - lastShieldRegenTime > 1f)
        {
            currentShield += 2;
            if (currentShield > maxShield)
            {
                currentShield = maxShield;
            }
            lastShieldRegenTime = Time.time;

            // Actualiza las barras deslizantes después de regenerar el escudo
            UpdateSliders();
        }
    }

    void UpdateSliders()
    {
        // Asegúrate de que las referencias de los sliders estén asignadas en el Inspector
        if (healthSlider != null && shieldSlider != null)
        {
            // Actualiza los valores de las barras deslizantes
            healthSlider.value = (float)currentHealth / maxHealth;
            shieldSlider.value = (float)currentShield / maxShield;
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
    }
}