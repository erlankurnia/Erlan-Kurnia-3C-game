using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<bool> OnSprintInput;
    public Action OnJumpInput;
    public Action OnClimbInput;
    public Action OnCancelClimb;

    private void Update()
    {
        CheckMovementInput();
        CheckCancelInput();
        CheckChangePOVInput();
        CheckClimbInput();
        CheckCrouchInput();
        CheckGlideInput();
        CheckJumpInput();
        CheckPunchInput();
        CheckSprintInput();
        CheckMainMenuInput();
    }

    private void CheckMovementInput()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Debug.Log("Vertical Axis: " + verticalAxis);
        Debug.Log("Horizontal Axis: " + horizontalAxis);

        Vector2 inputAxis = new Vector2(horizontalAxis, verticalAxis);

        OnMoveInput?.Invoke(inputAxis);
    }

    private void CheckSprintInput()
    {
        bool isHoldSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (isHoldSprintInput)
        {
            OnSprintInput?.Invoke(true);
        }
        else
        {
            OnSprintInput?.Invoke(false);
        }
    }

    private void CheckJumpInput()
    {
        bool isPressJumpInput = Input.GetKey(KeyCode.Space);


        if (isPressJumpInput)
        {
            OnJumpInput?.Invoke();
        }
    }

    private void CheckCrouchInput()
    {
        bool isPressCrouchInput = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);


        if (isPressCrouchInput)
        {
            Debug.Log("Crouch");
        }
    }

    private void CheckChangePOVInput()
    {
        bool isPressChangePOVInput = Input.GetKey(KeyCode.Q);


        if (isPressChangePOVInput)
        {
            Debug.Log("Change POV");
        }
    }

    private void CheckClimbInput()
    {
        bool isPressClimbInput = Input.GetKey(KeyCode.E);


        if (isPressClimbInput)
        {
            OnClimbInput?.Invoke();
        }
    }

    private void CheckGlideInput()
    {
        bool isPressGlideInput = Input.GetKey(KeyCode.G);


        if (isPressGlideInput)
        {
            Debug.Log("Glide");
        }
    }

    private void CheckCancelInput()
    {
        bool isPressCancelInput = Input.GetKey(KeyCode.C);


        if (isPressCancelInput)
        {
            OnCancelClimb?.Invoke();
        }
    }

    private void CheckPunchInput()
    {
        bool isPressPunchInput = Input.GetKey(KeyCode.Mouse0);


        if (isPressPunchInput)
        {
            Debug.Log("Punch");
        }
    }

    private void CheckMainMenuInput()
    {
        bool isPressMainMenuInput = Input.GetKey(KeyCode.Escape);


        if (isPressMainMenuInput)
        {
            Debug.Log("Back To Main Menu");
        }
    }
}
