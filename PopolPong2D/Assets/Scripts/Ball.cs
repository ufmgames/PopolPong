using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 ballMovement = Vector2.zero;
    public float speed = 5;
    public PlayerID playerId;
    Material material;
    bool action = true;

    private void Update()
    {
        transform.Translate(ballMovement * speed * Time.deltaTime);
        material = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jugador1")
        {
            material.color = Color.green;

            playerId = PlayerID.Player1;
            OnTriggerExit2D(collision);


        }
        else if (collision.tag == "Jugador2")
        {
            material.color = Color.red;
            playerId = PlayerID.Player2;
        }
        //On Collion with PU change speeds 
        if (collision.tag == "PowerUpSlow")
        {
            Debug.Log(speed);
            speed = speed - 3;
            StartCoroutine(YieldStopTime(1.5f));


        }
        else if (collision.tag == "PowerUpFast")
        {
            speed = speed * 2;
            StartCoroutine(YieldFastTime(.5f));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        action = false; 
    }    

    IEnumerator YieldFastTime(float n)
    {
        Debug.Log(n);
        yield return new WaitForSeconds(n);
        speed = speed /2;

    }

    IEnumerator YieldStopTime(float n)
    {
        Debug.Log(n);
        yield return new WaitForSeconds(n);
        speed = speed + 3;
    
    }



    public PlayerID getPlayerId()
    {
        Debug.Log(playerId);
        return playerId;
    }

    public void updateMovement(Vector2 newVector)
    {
        ballMovement = newVector;
    }

    public void updateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public Vector2 getBallMovement()
    {
        return ballMovement;
    }

}
