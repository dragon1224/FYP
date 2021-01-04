using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    [SerializeField] float speed = 4.0f;
    [SerializeField] float jumpSpeed = 6f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float mouseSensitivity = 5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameStatus.playerspeed = speed;
        MovePlayer();                      //call function allow to update player 
    }

    private void MovePlayer()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            float leftRightInput = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(leftRightInput, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        if (Input.GetButton("Jump") & (controller.isGrounded)) //allow player to jump on ground
        {
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);        //allow playto move on ground


        float mouseInput = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + mouseInput * mouseSensitivity, transform.localEulerAngles.z);  //allow play to move on ground
    }
}
