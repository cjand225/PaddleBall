/**
 * @brief The Ball class is responsible for controlling the behavior of a ball in a 2D game.
 *
 * It has properties for controlling the ball's speed and tracking player scores. It also handles collision events
 * with paddles and goals.
 */
using UnityEngine;
using TMPro;
using static SceneCommon;

public class Ball : MonoBehaviour
{
    /**
     * The name of the UI Object.
     */
    private string canvasName = "Canvas";

    private string playerScoreLeftName = "TextPlayerScoreLeft";

    private string playerScoreRightName = "TextPlayerScoreRight";

    /**
    * The Canvas object for displaying the UI.
    */
    private Canvas canvas;

    /**
    * The UI TextMeshProUGUI component for displaying the left player's score.
    */
    private TextMeshProUGUI textPlayerScoreLeft;

    /**
    * The UI TextMeshProUGUI component for displaying the right player's score.
    */
    private TextMeshProUGUI textPlayerScoreRight;

    /**
     * The speed of the ball.
     */
    private float speed = 5f;

    /**
     * The rigidbody component of the ball.
     */
    private Rigidbody2D rigidBody;

    /**
     * The initial direction the ball is launched in.
     */
    private Vector2 initialDirection;

    /**
     * The score of the left player.
     */
    private int playerScoreLeft = 0;

    /**
     * The score of the right player.
     */
    private int playerScoreRight = 0;

    /**
     * This method is called when the object is first enabled.
     *
     * It sets up the rigidbody component and launches the ball in a random direction.
     */
    void Start()
    {
        SceneCommon.setTimeScale(1f);

        //Initialize UI
        canvas = GameObject.Find(canvasName).GetComponent<Canvas>();
        textPlayerScoreLeft = GameObject.Find(playerScoreLeftName).GetComponent<TextMeshProUGUI>();
        textPlayerScoreRight = GameObject.Find(playerScoreRightName).GetComponent<TextMeshProUGUI>();

        //Initialize ball physics
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        LaunchBall(GetRandomDirection());
    }

    /**
     * This method is called every frame.
     *
     * It ensures that the ball is always moving at the desired speed.
     */
    void Update()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
                
        textPlayerScoreLeft.SetText(playerScoreLeft.ToString());
        textPlayerScoreRight.SetText(playerScoreRight.ToString());
    }

    /**
     * This method launches the ball in the given direction.
     *
     * @param direction The direction in which to launch the ball.
     */
    private void LaunchBall(Vector2 direction)
    {
        rigidBody.velocity = direction * speed;
    }

    private void ResetBall()
    {
        //Reset position and velocity and relaunch ball
        transform.position = Vector2.zero;
        rigidBody.velocity = Vector2.zero;
    }

    /**
     * This method returns a random direction for the ball to be launched in.
     *
     * @return A random direction for the ball to be launched in.
     */
    private Vector2 GetRandomDirection()
    {
        // Choose a random angle with a more significant X direction and a smaller Y direction
        float randomAngle = Random.Range(-30f, 30f);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Randomly choose the side (left or right) for the launch direction
        int randomSide = Random.Range(0, 2);
        if (randomSide == 1)
        {
            direction.x *= -1;
        }

        return direction;
    }

    /**
     * This method is called when the ball collides with another object.
     *
     * If the other object is a paddle, it changes the ball's direction based on where it hit the paddle.
     *
     * @param collision The collision data.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // Calculate the position the ball hits on the paddle.
            float y = PositionHit(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Determine whether or not the left or right paddle was hit.
            if (collision.collider.transform.position.x < 0)
            {
                Vector2 dir = new Vector2(1, y).normalized;
                rigidBody.velocity = dir * speed;
            }
            else
            {
                Vector2 dir = new Vector2(-1, y).normalized;
                rigidBody.velocity = dir * speed;
            }

        }  

    }

    /**
     * This method calculates the hit factor based on the position of the ball and paddle.
     *
     * @param ballPosition The position of the ball.
     * @param paddlePosition The position of the paddle.
     * @param paddleHeight The height of the paddle.
     * @return The hit factor (a value between -1 and 1) based on the position where the ball hit the paddle.
     */
    float PositionHit(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / paddleHeight;
    }

    /**
     * This method is called when the ball enters a trigger collider.
     *
     * If the trigger is a goal, it updates the score and launches the ball in a random direction.
     *
     * @param collider The collider that was entered.
     */
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Goal"))
        {
            if (collider.transform.position.x < 0)
            {
                playerScoreRight++;
            }
            else
            {
                playerScoreLeft++;
            }

            ResetBall();
            LaunchBall(GetRandomDirection());
        }
    }
}
