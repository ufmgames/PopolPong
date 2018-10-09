using UnityEngine;

public class Ring : MonoBehaviour
{

    [SerializeField] private GameObject _upLimit;
    [SerializeField] private GameObject _downLimit;
    [SerializeField] private GameObject _leftLimit;
    [SerializeField] private GameObject _rightLimit;
    private GameManager gameManager;
    private bool isGoal = false;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (!isGoal)
            {
                if (CheckGoal(collision.gameObject))
                {
                    Debug.Log("Goalllllllllllllllll");
                    isGoal = true;
                    PlayerID playerId = collision.gameObject.GetComponent<Ball>().getPlayerId();
                    gameManager.GoalScore(playerId, 1);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            isGoal = false;
        }
    }

    public bool CheckGoal(GameObject ball)
    {
        if (ball.transform.position.x > _leftLimit.transform.position.x &&
            ball.transform.position.x < _rightLimit.transform.position.x &&
            ball.transform.position.y < _upLimit.transform.position.y &&
            ball.transform.position.y > _downLimit.transform.position.y)
        {
            return true;
        }
        return false;
    }
}
