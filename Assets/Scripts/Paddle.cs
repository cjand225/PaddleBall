/**
 * Paddle - A script for controlling the movement of a Paddle object in a Pong game.
 *
 * This script listens for input from the Player's PaddleInputActions and moves the Paddle object vertically.
 * The movement speed is adjustable via the public speed variable.
 * The Paddle's position is clamped to stay within the screen bounds.
 *
 * This script should be attached to a GameObject with a BoxCollider2D component to represent the Paddle.
 * The isLeftPaddle variable should be set to true if this Paddle is the left one, and false if it is the right one.
 */
 
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    // The movement speed of the Paddle
    private float speed = 10f;

    // Whether this Paddle is the left one or not
    public bool isLeftPaddle;

    // The PaddleInputActions object for this Paddle
    private PaddleInputActions inputActions;

    // The current vertical input value from the Player
    private float verticalInput;

    /**
     * Awake - Called when the script instance is being loaded.
     * Sets up the input actions for this Paddle.
     */
    private void Awake()
    {
        // Create a new PaddleInputActions object for this Paddle
        inputActions = new PaddleInputActions();

        // Set up the input action callbacks based on whether this is the left or right Paddle
        if (isLeftPaddle)
        {
            inputActions.Player.PaddleLeft.performed += ctx => verticalInput = ctx.ReadValue<float>();
            inputActions.Player.PaddleLeft.canceled += ctx => verticalInput = 0;
        } 
        else
        {
            inputActions.Player.PaddleRight.performed += ctx => verticalInput = ctx.ReadValue<float>();
            inputActions.Player.PaddleRight.canceled += ctx => verticalInput = 0;
        }
    }

    /**
     * OnEnable - Called when the object becomes enabled and active.
     * Enables the PaddleInputActions for this Paddle.
     */
    private void OnEnable()
    {
        inputActions.Enable();
    }

    /**
     * OnDisable - Called when the behaviour becomes disabled.
     * Disables the PaddleInputActions for this Paddle.
     */
    private void OnDisable()
    {
        inputActions.Disable();
    }

    /**
     * Update - Called every frame.
     * Moves the Paddle based on the current vertical input value and the speed variable.
     * Clamps the Paddle's position to stay within the screen bounds.
     */
    void Update()
    {
        // Calculate the amount of movement based on the current vertical input value and the speed variable
        float movement = verticalInput * speed * Time.deltaTime;

        // Move the Paddle vertically
        transform.Translate(new Vector2(0, movement));

        // Clamp the Paddle's position to stay within the screen bounds
        float clampedY = Mathf.Clamp(transform.position.y, -4.25f, 4.25f);
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}
