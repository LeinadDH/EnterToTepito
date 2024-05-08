using UnityEngine;
using UnityEngine.InputSystem;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI;
    
    [SerializeField] private IntValue _enemiesKilled;
    [SerializeField] private IntValue _enemyToSpawn;
    [SerializeField] private IntValue _enemiesSpawned;
    [SerializeField] private IntValue _wave;
    
    [SerializeField] private EnemySpawner _enemySpawner;
    
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _gun;
    
    public void NextWave()
    {
        _enemiesKilled.value = 0;
        _enemyToSpawn.value += 4;
        _enemiesSpawned.value = 0;
        _wave.value++;
        Cursor.visible = false;
        _playerInput.enabled = true;
        _gun.SetActive(true);
        _enemySpawner.NewWave();
        _shopUI.SetActive(false);
    }
}
