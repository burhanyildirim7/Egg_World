using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    PlayerInput playerInput;
    Animator playerAnim;

    bool isMove = false;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        controller = gameObject.AddComponent<CharacterController>();
       
        GetComponent<CharacterController>().center = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector3 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);



        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
         
            playerAnim.SetBool("run", true);
        }
        else
        {
            playerAnim.SetBool("run", false);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);








    }
}
