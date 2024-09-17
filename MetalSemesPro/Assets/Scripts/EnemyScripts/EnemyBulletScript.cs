using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifeTime = 2f;

    private Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}