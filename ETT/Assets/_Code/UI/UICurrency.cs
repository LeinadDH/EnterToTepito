using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UICurrency : MonoBehaviour
{
    [SerializeField] private IntValue _coins;
    [SerializeField] private IntValue _score;
    [SerializeField] private IntValue _wave;
    [SerializeField] private IntValue _enemiesKilled;
    [SerializeField] private IntValue _enemyToSpawn;
    
    [SerializeField] private TMPro.TextMeshProUGUI _coinsTxt;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTxt;
    [SerializeField] private TMPro.TextMeshProUGUI _waveTxt;
    
    [SerializeField] private GameObject _ShopUI;
    
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _gun;

    private void Start()
    {
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
        
        if(_enemiesKilled.value == _enemyToSpawn.value)
        {
            _playerInput.enabled = false;
            _gun.SetActive(false);
            Cursor.visible = true;
            _ShopUI.SetActive(true);
        }
    }
}
