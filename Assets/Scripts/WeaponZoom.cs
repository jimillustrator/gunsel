using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponZoom : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float defaultFOV = 60;
    [SerializeField] float zoomedInFOV = 15;
    [SerializeField] float zoomedOutSensitivity = 4f;
    [SerializeField] float zoomedInSensitivity = 2f;


    public void Zoom(bool zoomedIn)
    {
        //camera.m_Lens.FieldOfView = zoomedIn ? zoomedInFOV : defaultFOV;
        if(zoomedIn)
        {
            fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
            fpsController.RotationSpeed = zoomedInSensitivity;
        }
        else
        {
            fpsCamera.m_Lens.FieldOfView = defaultFOV;
            fpsController.RotationSpeed = zoomedOutSensitivity;
        }
        
    }
}