/**
 * @brief The Ball class is responsible for controlling the behavior of a ball in a 2D game.
 *
 * It has properties for controlling the ball's speed and tracking player scores. It also handles collision events
 * with paddles and goals.
 */
using UnityEngine;
using TMPro;
using static SceneCommon;

public class ScoreKeeper : MonoBehaviour
{
    /**
    * The UI TextMeshProUGUI component for displaying the left player's score.
    */
    [SerializeField]
    private TextMeshProUGUI textPlayerScore;

    /**
     * The score of the player.
     */
    private int playerScore = 0;

    /**
     * This method is called every frame.
     *
     * It ensures that the ball is always moving at the desired speed.
     */
    void Update()
    {
        textPlayerScore.SetText(playerScore.ToString());
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
        if (collider.CompareTag("Ball"))
        {
            playerScore++;
        }
    }
}
