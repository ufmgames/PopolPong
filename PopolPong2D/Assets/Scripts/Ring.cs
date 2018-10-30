using System.Collections;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private GameObject _upLimit;
    [SerializeField] private GameObject _downLimit;
    [SerializeField] private GameObject _leftLimit;
    [SerializeField] private GameObject _rightLimit;
    private GameManager gameManager;
    private bool isGoal = false;
    public Animator _animator;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /* check if collision with ball
         * only one goal at a time
         * check if the game object is exactly on the goal area */
        if ((collision.tag == "Ball") && (!isGoal) && CheckGoal(collision.gameObject))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            PlayerID playerId = ball.getPlayerId();
            if (playerId != 0)
            {
                isGoal = true;
                Debug.Log("Goalllllllllllllllll " + playerId);
                gameManager.GoalScore(playerId, 1);
                ball.updateSpeed(0);
                _animator.SetBool("RingGoal", true);
                StartCoroutine(ScoredGoal(ball));
            }
        }
    }

    // Coroutine
    IEnumerator ScoredGoal(Ball ball)
    {
        yield return new WaitForSeconds(1);
        _animator.SetBool("RingGoal", false);
        _animator.SetBool("GenerateBall", true);
        StartCoroutine(GenerateBall(ball));
    }

    IEnumerator GenerateBall(Ball ball)
    {
        yield return new WaitForSeconds(1);
        _animator.SetBool("GenerateBall", false);
        ball.updateSpeed(5);
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
