using UnityEngine;
using Cinemachine;
using StarterAssets;


public class WeaponZoom : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private float defaultFOV = 40;
    [SerializeField] private float zoomedInFOV = 15;

    public void Zoom(bool zoomedIn)
    {
        camera.m_Lens.FieldOfView = zoomedIn ? zoomedInFOV : defaultFOV;
    }
}