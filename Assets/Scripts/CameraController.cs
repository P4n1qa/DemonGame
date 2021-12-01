using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    private Player playerTarget;
    CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        playerTarget = FindObjectOfType<Player>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = playerTarget.transform;

    }
}
