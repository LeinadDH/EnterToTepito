using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI;
    
    [Header("Enemies and Waves")]
    [SerializeField] private IntValue _enemiesKilled;
    [SerializeField] private IntValue _enemyToSpawn;
    [SerializeField] private IntValue _enemiesSpawned;
    [SerializeField] private IntValue _wave;
    
    [Header("Shop Dependencies")]
    [SerializeField] private IntValue _itemCost;
    [SerializeField] private IntValue _coins;
    [SerializeField] private IntValue _currentHP;
    [SerializeField] private IntValue _maxHP;
    [SerializeField] private IntValue _maxShield;
    [SerializeField] private IntValue _shieldRegen;
    [SerializeField] private IntValue _maxCanon;
    [SerializeField] private IntValue _currentCanon;
    
    
    [Header("Enemy Spawner")]
    [SerializeField] private EnemySpawner _enemySpawner;
    
    [Header("Player Input")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _gun;
    
    [Header("UI Dependencies")]
    [SerializeField] private TextMeshProUGUI _moreCanonCost;
    [SerializeField] private TextMeshProUGUI _moreHPCost;
    [SerializeField] private TextMeshProUGUI _moreShieldCost;
    [SerializeField] private TextMeshProUGUI _moreShieldRegenCost;

    public void ObjectsCost()
    {
        _moreCanonCost.text = "x" + _itemCost.value;
        _moreHPCost.text = "x" + _itemCost.value;
        _moreShieldCost.text = "x" + _itemCost.value;
        _moreShieldRegenCost.text = "x" + _itemCost.value;
    }
    
    public void MoreCanon()
    {
        if (_coins.value >= _itemCost.value)
        {
            _coins.value -= _itemCost.value;
            _itemCost.value += 1;
            _maxCanon.value++;
            _currentCanon.value = _maxCanon.value;
            ObjectsCost();
        }
    }
    
    public void MoreHP()
    {
        if (_coins.value >= _itemCost.value)
        {
            _coins.value -= _itemCost.value;
            _itemCost.value += 1;
            _maxHP.value += 20;
            _currentHP.value = _maxHP.value;
            ObjectsCost();
        }
    }
    
    public void MoreShield()
    {
        if (_coins.value >= _itemCost.value)
        {
            _coins.value -= _itemCost.value;
            _itemCost.value += 1;
            _maxShield.value += 10;
            ObjectsCost();
        }
    }
    
    public void MoreShieldRegen()
    {
        if (_coins.value >= _itemCost.value)
        {
            _coins.value -= _itemCost.value;
            _itemCost.value += 1;
            _shieldRegen.value += 2;
            ObjectsCost();
        }
    }

    public void CanonRefill()
    {
        if (_coins.value >= 2)
        {
            _coins.value -= 2;
            _currentCanon.value = _maxCanon.value;
            ObjectsCost();
        }
    }
    
    public void HPRefill()
    {
        if (_coins.value >= 2)
        {
            _coins.value -= 2;
            _currentHP.value = _maxHP.value;
            ObjectsCost();
        }
    }
    
    public void NextWave()
    {
        _enemiesKilled.value = 0;
        _enemyToSpawn.value += 4;
        _enemiesSpawned.value = 0;
        _wave.value++;
        _playerInput.enabled = true;
        _gun.SetActive(true);
        _enemySpawner.NewWave();
        _shopUI.SetActive(false);
    }
}
