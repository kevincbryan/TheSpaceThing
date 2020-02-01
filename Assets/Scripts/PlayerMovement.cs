using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 50f;

    CharacterController characterController;
    
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

    private void MoveByPlayerInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        characterController.Move(transform.forward * Time.deltaTime * moveSpeed * verticalInput);
        transform.Rotate(0f, horizontalInput * Time.deltaTime * rotateSpeed, 0f);
    }
}
