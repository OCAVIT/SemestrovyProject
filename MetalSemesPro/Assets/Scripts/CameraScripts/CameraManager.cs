using UnityEngine;
using System.Collections.Generic;
using System;

public class CameraManager : MonoBehaviour
{
    [System.Serializable]
    public struct TriggerCameraPair
    {
        public GameObject trigger;
        public Camera camera;
    }

    public TriggerCameraPair[] triggerCameraPairs;

    private Dictionary<GameObject, Camera> triggerCameraMap;
    private Camera activeCamera;

    // Событие для уведомления о смене камеры
    public event Action<Camera> OnCameraChanged;

    void Start()
    {
        triggerCameraMap = new Dictionary<GameObject, Camera>();

        foreach (var pair in triggerCameraPairs)
        {
            triggerCameraMap[pair.trigger] = pair.camera;
            pair.camera.enabled = false;
            var audioListener = pair.camera.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = false;
            }
        }

        if (triggerCameraPairs.Length > 0)
        {
            activeCamera = triggerCameraPairs[0].camera;
            activeCamera.enabled = true;
            var audioListener = activeCamera.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = true;
            }
        }
    }

    public void ChangeCamera(GameObject trigger)
    {
        if (triggerCameraMap.ContainsKey(trigger))
        {
            activeCamera.enabled = false;
            var currentAudioListener = activeCamera.GetComponent<AudioListener>();
            if (currentAudioListener != null)
            {
                currentAudioListener.enabled = false;
            }

            activeCamera = triggerCameraMap[trigger];
            activeCamera.enabled = true;
            var newAudioListener = activeCamera.GetComponent<AudioListener>();
            if (newAudioListener != null)
            {
                newAudioListener.enabled = true;
            }

            // Уведомляем всех подписчиков о смене камеры
            OnCameraChanged?.Invoke(activeCamera);
        }
    }
}