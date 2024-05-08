using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Transform _player;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_spawnInterval);
        
        Vector3 spawnPosition = GetRandomSpawnPosition();
        if (Vector3.Distance(spawnPosition, _player.position) < 4f)
        {
            spawnPosition = GetRandomSpawnPosition();
        }
        
        EnemyHP enemy = ObjectPooler.DequeueObject<EnemyHP>("Enemy");
        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);

        StartCoroutine(SpawnEnemy());
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-6f, 12f), Random.Range(-12f, -2f), 0f);
    }
}
