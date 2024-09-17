using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float approachDistance = 5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate = 1f;

    private EnemyAI enemyAI;
    private float nextFireTime = 0f;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (enemyAI.IsPlayerDetected())
        {
            ApproachPlayer();
            ShootAtPlayer();
        }
    }

    private void ApproachPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > approachDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void ShootAtPlayer()
    {
        if (Time.time >= nextFireTime)
        {
            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(directionToPlayer);
            }
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}