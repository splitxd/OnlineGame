using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float MoveSpeed = 5f;
    private Vector3 playerVelocity = Vector3.zero;
    // [SerializeField]
    // private float sensitivity = 5f;
    [SerializeField]
    private float gravity = -9.8f;
    private bool isGrounded;
    [SerializeField]
    private float jumpHeight = 3f;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
    }
    
    public void ProcessMove(Vector3 input)
    {
        Vector3 movement = Vector3.zero;
        movement.x = input.x;
        movement.z = input.y;
        characterController.Move(transform.TransformDirection(movement) * (MoveSpeed * Time.deltaTime) );
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}