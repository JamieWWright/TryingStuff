using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInput;
    [SerializeField] private CharacterController playerController;

    InputAction move;
    InputAction jump;

    void Start()
    {
        move = playerInput.FindAction("Move");
        jump = playerInput.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {

        if(move.IsPressed())
        {
            playerController.Move(new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y));
        }
        if (jump.WasPerformedThisFrame())
        {
            playerController.Jump();
        }
    }
}
