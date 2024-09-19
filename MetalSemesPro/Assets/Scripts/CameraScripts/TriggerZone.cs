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
        if (other.CompareTag("Player")) // ��������������, ��� � ������ ���� ��� "Player"
        {
            cameraManager.ChangeCamera(gameObject);
        }
    }
}