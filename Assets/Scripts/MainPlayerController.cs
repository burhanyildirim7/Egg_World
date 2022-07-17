using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    PlayerInput playerInput;
    Animator playerAnim;

    public bool isMove = false;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public float _speed;
    public float _velocityX;
    public float _velocityZ;
    public FloatingJoystick _floatingJoystick;
    public Rigidbody _rigidbody;


    void Start()
    {
 
        playerAnim = GetComponent<Animator>();

       

    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        _velocityX = _rigidbody.velocity.x;
        _velocityZ = _rigidbody.velocity.z;
        Vector3 direction = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;
        // transform.Translate(direction * Time.deltaTime * _speed);
        _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _speed, _rigidbody.velocity.y, _floatingJoystick.Vertical * _speed);

        if (_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }

        if (_rigidbody.velocity.x != 0 || _rigidbody.velocity.z != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        /*
        controller.stepOffset = 0;
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
         
         

            if (GetComponent<CollectControl>().eggList.Count > 0)
            {
                playerAnim.SetBool("runWithEgg", true);
                playerAnim.SetBool("runWithoutEgg", false);
                playerAnim.SetBool("idleWithEgg", false);
                playerAnim.SetBool("idleWithoutEgg", false);
            }
            else
            {
                playerAnim.SetBool("runWithEgg", false);
                playerAnim.SetBool("runWithoutEgg", true);
                playerAnim.SetBool("idleWithoutEgg", false);
                playerAnim.SetBool("idleWithEgg", false);
            }
        }
        else
        {

            if (GetComponent<CollectControl>().eggList.Count > 0)
            {
                playerAnim.SetBool("idleWithEgg", true);
                playerAnim.SetBool("idleWithoutEgg", false);
                playerAnim.SetBool("runWithEgg", false);
                playerAnim.SetBool("runWithoutEgg", false);
            }
            else
            {
                playerAnim.SetBool("idleWithEgg", false);
                playerAnim.SetBool("runWithEgg", false);
                playerAnim.SetBool("runWithoutEgg", false);
                playerAnim.SetBool("idleWithoutEgg", true);
            }
          
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        */






    }
}
