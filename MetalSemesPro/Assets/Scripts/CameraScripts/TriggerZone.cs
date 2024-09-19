using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private CameraManager cameraManager;

    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Предполагается, что у игрока есть тег "Player"
        {
            cameraManager.ChangeCamera(gameObject);
        }
    }
}