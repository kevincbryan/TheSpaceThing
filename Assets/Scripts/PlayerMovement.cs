using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    CharacterController characterController;

    PlayerInputActions inputActions;

    Vector2 movementInput;

    void Awake() {
        inputActions = new PlayerInputActions();
        movementInput = new Vector2();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveByPlayerInput();
    }

    void OnEnable() {
        inputActions.Enable();
    }

    void OnDisable() {
        inputActions.Disable();
    }

    private void MoveByPlayerInput()
    {
        float horizontalInput = movementInput.x;
        float verticalInput = movementInput.y;

        transform.LookAt(transform.position + new Vector3(horizontalInput, 0, verticalInput));
        var forward = new Vector3(horizontalInput, 0, verticalInput).normalized;
        characterController.Move(forward * Time.deltaTime * moveSpeed);
    }
}
