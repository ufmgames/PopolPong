using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    [SerializeField] private GameObject _upLimit;
    [SerializeField] private GameObject _downLimit;
    [SerializeField] private GameObject _leftLimit;
    [SerializeField] private GameObject _rightLimit;
    private GameManager gameManager;
    private bool isGoal = false;
    public Transform sparkle;


    private void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Stop();



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (!isGoal)
            {
                if (CheckGoal(collision.gameObject))
                {
                    ParticleSystem ps = GetComponent<ParticleSystem>();
                    ps.Play();
                    StartCoroutine(stopSparkles());
                    Debug.Log("Goalllllllllllllllll");
                    isGoal = true;
                    stopSparkles();
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

     IEnumerator stopSparkles()
    {
        Debug.Log("Enter");
        yield return new WaitForSeconds(.5f);
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Stop();
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
