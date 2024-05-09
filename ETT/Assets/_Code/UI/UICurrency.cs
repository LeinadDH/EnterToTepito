using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections.Generic;

public class UICurrency : MonoBehaviour
{
    [SerializeField] private IntValue _coins;
    [SerializeField] private IntValue _score;
    [SerializeField] private IntValue _wave;
    [SerializeField] private IntValue _enemiesKilled;
    [SerializeField] private IntValue _enemyToSpawn;
    [SerializeField] private IntValue _itemCost;
    [SerializeField] private IntValue _currentCanon;
    
    [SerializeField] private TextMeshProUGUI _coinsTxt;
    [SerializeField] private TextMeshProUGUI _scoreTxt;
    [SerializeField] private TextMeshProUGUI _bulletsTxt;
    [SerializeField] private TextMeshProUGUI _waveTxt;
    [SerializeField] private TextMeshProUGUI _waveEndGameTxt;
    [SerializeField] private TextMeshProUGUI _scoreEndGameTxt;
    
    [SerializeField] private GameObject _ShopUI;
    
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _gun;

    private void Start()
    {
        _itemCost.value = 2;
        _coins.value = 0;
        _score.value = 0;
        _wave.value = 1;
        _enemiesKilled.value = 0;
        _enemyToSpawn.value = 3;
        _ShopUI.SetActive(false);
    }

    private void Update()
    {
        _coinsTxt.text = "Coins: " +  _coins.value;
        _scoreTxt.text = "Score: " + _score.value;
        _waveTxt.text = "Wave: " + _wave.value;
        _bulletsTxt.text = "Bullets: " + _currentCanon.value;
        _waveEndGameTxt.text = "Wave: " + _wave.value;
        _scoreEndGameTxt.text = "Score: " + _score.value;

        if (_enemiesKilled.value >= _enemyToSpawn.value)
        {
            var restEnemies = FindObjectsOfType<EnemyHP>();
            foreach (var enemy in restEnemies)
            {
                enemy.gameObject.SetActive(false);
            }
            _playerInput.enabled = false;
            _gun.SetActive(false);
            _ShopUI.SetActive(true);
            gameObject.GetComponent<ShopUI>().ObjectsCost();

        }
    }
}
