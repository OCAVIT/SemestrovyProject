using UnityEngine;

public class LaserController : MonoBehaviour
{
    public CameraManager cameraManager; // Ссылка на CameraManager
    private Camera activeCamera; // Активная камера

    void Start()
    {
        if (cameraManager != null)
        {
            cameraManager.OnCameraChanged += UpdateActiveCamera;
            activeCamera = cameraManager.triggerCameraPairs[0].camera; // Инициализация активной камеры
        }
        else
        {
            Debug.LogError("CameraManager is not assigned!");
        }
    }

    void UpdateActiveCamera(Camera newCamera)
    {
        activeCamera = newCamera;
    }

    void Update()
    {
        if (activeCamera == null)
        {
            Debug.LogError("No active camera found!");
            return;
        }

        // Получаем позицию курсора в мировых координатах
        Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        if (playerPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0; // Игнорируем изменения по оси Y

            // Поворачиваем игрока в направлении курсора
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }

    void OnDestroy()
    {
        if (cameraManager != null)
        {
            cameraManager.OnCameraChanged -= UpdateActiveCamera;
        }
    }
}