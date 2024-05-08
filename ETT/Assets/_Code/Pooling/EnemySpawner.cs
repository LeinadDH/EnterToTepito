using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Transform _player;
    [SerializeField] private IntValue _enemiesToSpawn;
    [SerializeField] private IntValue _enemiesSpawned;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        _enemiesToSpawn.value = 4;
        _enemiesSpawned.value = 0;
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_spawnInterval);
        if (_enemiesToSpawn.value == _enemiesSpawned.value)
        {
            StopCoroutine(SpawnEnemy());
        }
        else
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            if (Vector3.Distance(spawnPosition, _player.position) < 4f)
            {
                spawnPosition = GetRandomSpawnPosition();
            }
        
            EnemyHP enemy = ObjectPooler.DequeueObject<EnemyHP>("Enemy");
            enemy.transform.position = spawnPosition;
            enemy.gameObject.SetActive(true);
            _enemiesSpawned.value++;
            StartCoroutine(SpawnEnemy());
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-6f, 12f), Random.Range(-12f, -2f), 0f);
    }

    public void NewWave()
    {
        StartCoroutine(SpawnEnemy());
    }
}
