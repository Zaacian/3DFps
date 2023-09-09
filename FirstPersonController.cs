using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0;
    //Player Move
    public float movementSpeed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    //Jump & gravity
    public float jumpForce = 5.0f;
    public float gravity = 9.8f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //MouseLook
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Player Move
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;
        if (characterController.isGrounded)

        {
            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        characterController.Move(moveDirection * Time.deltaTime);

        moveDirection.y -= gravity * Time.deltaTime;
    }
}
