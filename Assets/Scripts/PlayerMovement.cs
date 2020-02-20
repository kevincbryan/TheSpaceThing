using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    CharacterController characterController;

    PlayerInputManager inputManager;

    float startingY;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = GetComponent<PlayerInputManager>();

        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveByPlayerInput();
    }

    private void MoveByPlayerInput()
    {
        float horizontalInput = inputManager.GetX();
        float verticalInput = inputManager.GetY();

        transform.LookAt(transform.position + new Vector3(horizontalInput, 0, verticalInput));
        var forward = new Vector3(horizontalInput, 0, verticalInput).normalized;
        characterController.Move(forward * Time.deltaTime * moveSpeed);
        transform.position = new Vector3(transform.position.x, startingY, transform.position.z);

    }
}
