using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private GameObject ballPrefab;
    private Dictionary<PlayerID, int> scores = new Dictionary<PlayerID, int>();

    // Use this for initialization
    void Start()
    {
        // initialize scores
        scores.Add(PlayerID.Player1, 0);
        scores.Add(PlayerID.Player2, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            intializeBall();
        }
    }

    private void intializeBall()
    {
        GameObject ballObject = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        Ball ball = ballObject.GetComponent<Ball>();
        int yPosition = Random.Range(-1, 2);
        if (yPosition == 0)
        {
            yPosition = 1;
        }
        ball.updateMovement(new Vector2(0, yPosition));
        ball.updateSpeed(5);
    }

    public void GoalScore(PlayerID playerId, int points)
    {
        if (scores.ContainsKey(playerId))
        {
            scores[playerId] = scores[playerId] + 1;
            UIManager.updatePlayerScore(playerId, scores[playerId]);
        }
    }
}
