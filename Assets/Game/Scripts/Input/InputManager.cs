using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Debug.Log("Vertical Axis: " + verticalAxis);
        Debug.Log("Horizontal Axis: " + horizontalAxis);
    }
}
