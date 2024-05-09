using UnityEngine;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour
{
    [SerializeField] private IntValue _currentHP;
    [SerializeField] private IntValue _maxHP;
    [SerializeField] private IntValue _maxShield;
    [SerializeField] private IntValue _shieldRegen;
    [SerializeField] private GameObject _endGameCanvas;
    public Slider healthSlider;
    public Slider shieldSlider;
    
    private float shieldRegenDelay = 5f;
    
    private int currentShield;
    private float lastDamageTime;
    private float lastShieldRegenTime;

    void Start()
    {
        _endGameCanvas.SetActive(false);
        _shieldRegen.value = 2;
        _maxHP.value = 40;
        _maxShield.value = 20;
        _currentHP.value = _maxHP.value;
        currentShield = _maxShield.value;
        lastDamageTime = Time.time;
        lastShieldRegenTime = Time.time;
        
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
                _currentHP.value += currentShield;
                currentShield = 0;
            }
        }
        else
        {
            _currentHP.value -= damage;
        }

        if (_currentHP.value <= 0)
        {
            Die();
        }
        
        UpdateSliders();
    }

    void RegenerateShield()
    {
        if (Time.time - lastShieldRegenTime > 1f)
        {
            currentShield += _shieldRegen.value;
            if (currentShield > _maxShield.value)
            {
                currentShield = _maxShield.value;
            }
            lastShieldRegenTime = Time.time;
            
            UpdateSliders();
        }
    }

    void UpdateSliders()
    {
        if (healthSlider != null && shieldSlider != null)
        {
            healthSlider.value = (float)_currentHP.value / _maxHP.value;
            shieldSlider.value = (float)currentShield / _maxShield.value;
        }
    }

    void Die()
    {
        _endGameCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}