using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [Tooltip("The maximum health (health pool) the player has.")]
    [SerializeField]
    public int maximumHealth = 100;
    [Tooltip("The speed of the player.")]
    [SerializeField]
    public float playerSpeed = 2.0f;
    [Tooltip("The height the player will jump.")]
    [SerializeField]
    public float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    public int currentHealth;

    [Header("References")]
    [SerializeField]
    private AudioSource audioSource;

    public PlayerUI playerUI;

    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public static bool gamePaused = false;
    public ObjectType objectType = ObjectType.White;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;

        currentHealth = maximumHealth;
        gamePaused = false;
    }

    void Update()
    {
        // Set whether or not player is grounded
        groundedPlayer = controller.isGrounded;

        // Remove y velocity if player is grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            controller.stepOffset = 0.3f;
        }

        // Player movement
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0.0f;
        move.Normalize();
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Make player jump
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            controller.stepOffset = 0.0f;
            audioSource.Play();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Check to see if game is paused
        CheckPaused();
    }

    public void ChangeType()
    {
        switch(objectType)
        {
            case ObjectType.Red:
                UpdateType(10.0f, 1.0f, -20.0f, Color.red);
                break;
            case ObjectType.Green:
                UpdateType(10.0f, 3.0f, -9.81f, Color.green);
                break;
            case ObjectType.Blue:
                UpdateType(20.0f, 1.0f, -9.81f, Color.blue);
                break;
            case ObjectType.Yellow:
                UpdateType(10.0f, 1.0f, -4.4f, Color.yellow);
                break;
            case ObjectType.Black:
                UpdateType(10.0f, 1.0f, 0.0f, Color.black);
                break;
            case ObjectType.White:
                UpdateType(10.0f, 1.0f, -9.81f, Color.white);
                break;
        }
    }

    private void UpdateType(float newSpeed, float newJumpHeight, float newGravity, Color color)
    {
        playerSpeed = newSpeed;
        jumpHeight = newJumpHeight;
        gravityValue = newGravity;

        playerUI.UpdateColor(color);

        Debug.Log("Type Updated");
    }

    public void CheckPaused()
    {
        if (gamePaused == true)
        {
            if (cinemachineVirtualCamera.enabled == true)
            {
                cinemachineVirtualCamera.enabled = false;
            }
        }
        else if (gamePaused == false)
        {
            if (cinemachineVirtualCamera.enabled == false)
            {
                cinemachineVirtualCamera.enabled = true;
            }
        }
    }
}
