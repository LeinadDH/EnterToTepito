using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Projectile _basicProyectilePrefab;
    [SerializeField] private Projectile _strongProyectilePrefab;

    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        ObjectPooler.SetupPool(_basicProyectilePrefab, 20, "BasicBullet");
        ObjectPooler.SetupPool(_strongProyectilePrefab, 20, "StrongBullet");
    }
}