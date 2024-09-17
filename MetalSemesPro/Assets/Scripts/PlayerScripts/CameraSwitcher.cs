using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == currentCameraIndex);
            AudioListener audioListener = cameras[i].GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = (i == currentCameraIndex);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchCamera(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchCamera(-1);
        }
    }

    private void SwitchCamera(int direction)
    {
        cameras[currentCameraIndex].enabled = false;
        AudioListener currentAudioListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
        if (currentAudioListener != null)
        {
            currentAudioListener.enabled = false;
        }

        currentCameraIndex += direction;

        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }
        else if (currentCameraIndex < 0)
        {
            currentCameraIndex = cameras.Length - 1;
        }

        cameras[currentCameraIndex].enabled = true;
        AudioListener newAudioListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
        if (newAudioListener != null)
        {
            newAudioListener.enabled = true;
        }
    }
}