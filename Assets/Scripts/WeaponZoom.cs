using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponZoom : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] float defaultFOV = 40;
    [SerializeField] float zoomedInFOV = 15;
    [SerializeField] float zoomedOutSensitivity = 4f;
    [SerializeField] float zoomedInSensitivity = 2f;

    FirstPersonController fpsController;

    private void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }

    public void Zoom(bool zoomedIn)
    {
        //camera.m_Lens.FieldOfView = zoomedIn ? zoomedInFOV : defaultFOV;
        if(zoomedIn)
        {
            camera.m_Lens.FieldOfView = zoomedInFOV;
            fpsController.RotationSpeed = zoomedInSensitivity;
        }
        else
        {
            camera.m_Lens.FieldOfView = defaultFOV;
            fpsController.RotationSpeed = zoomedOutSensitivity;
        }
        
    }
}