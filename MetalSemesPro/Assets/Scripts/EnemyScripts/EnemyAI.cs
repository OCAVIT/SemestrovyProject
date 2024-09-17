using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private Transform player;

    private bool playerDetected = false;

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}