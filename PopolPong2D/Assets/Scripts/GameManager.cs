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
        // reference UI
        //GameObject uiManagerObject = GameObject.Find("UIManager");
        // UIManager = uiManagerObject.GetComponent<UIManager>();

        // initialize scores
        scores.Add(PlayerID.Player1, 0);
        scores.Add(PlayerID.Player2, 0);
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
