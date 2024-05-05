using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraState CameraState;

    [SerializeField] private CinemachineVirtualCamera _fppCamera;
    [SerializeField] private CinemachineFreeLook _tppCamera;

    [SerializeField] private InputManager _inputManager;

    private void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }

    private void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }

    private void SwitchCamera()
    {
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tppCamera.gameObject.SetActive(false);
            _fppCamera.gameObject.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tppCamera.gameObject.SetActive(true);
            _fppCamera.gameObject.SetActive(false);
        }
    }

    public void SetFPPClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        CinemachinePOV pov = _fppCamera.GetComponentInChildren<CinemachinePOV>();

        pov.m_HorizontalAxis.m_Wrap = !isClamped;
        pov.m_HorizontalAxis.m_MinValue = playerRotation.y - (isClamped ? 45 : 180);
        pov.m_HorizontalAxis.m_MaxValue = playerRotation.y + (isClamped ? 45 : 180);
    }

    public void SetTPPFieldOfView(float fieldOfView)
    {
        _tppCamera.m_Lens.FieldOfView = fieldOfView;
    }
}
