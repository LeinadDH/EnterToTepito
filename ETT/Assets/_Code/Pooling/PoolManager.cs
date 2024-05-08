using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Projectile _basicProyectilePrefab;
    [SerializeField] private Projectile _strongProyectilePrefab;
    [SerializeField] private EnemyHP _enemyPrefab;

    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        ObjectPooler.SetupPool(_basicProyectilePrefab, 10, "BasicBullet");
        ObjectPooler.SetupPool(_strongProyectilePrefab, 12, "StrongBullet");
        ObjectPooler.SetupPool(_enemyPrefab, 64, "Enemy");
    }
}