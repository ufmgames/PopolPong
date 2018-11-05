using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 ballMovement = Vector2.zero;
    public float speed = 5;
    public PlayerID playerId;
    Material material;
    GameObject pallete;
    AudioSource audio;
    Jugadores jugadoresScript;
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
            audio = GetComponent<AudioSource>();
            audio.Play();
            material.color = Color.green;
            playerId = PlayerID.Player1;
            OnTriggerExit2D(collision);
        }
        else if (collision.tag == "Jugador2")
        {
            audio = GetComponent<AudioSource>();
            audio.Play();
            material.color = Color.red;
            playerId = PlayerID.Player2;
        }
        //////////////////////////////////////// SLOW FAST Power Up ////////////////////////////////
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
        //////////////////////////////////// Big Pallete ///////////////////////////////////////////////////////
        if(collision.tag == "PowerUpBPallete")
        {
            if (getPlayerId() == PlayerID.Player1)
            {
                pallete = GameObject.FindGameObjectWithTag("Jugador1");
                jugadoresScript = pallete.GetComponent<Jugadores>();
                pallete.transform.localScale += new Vector3(2, 0, 0);
                StartCoroutine(jugadoresScript.BackToNormBig());
            }
            else if (getPlayerId() == PlayerID.Player2)
            {
                pallete = GameObject.FindGameObjectWithTag("Jugador2");
                jugadoresScript = pallete.GetComponent<Jugadores>();
                pallete.transform.localScale += new Vector3(2, 0, 0);
                StartCoroutine(jugadoresScript.BackToNormBig());
            }
        }
        //////////////////////////////////// Small Pallete ///////////////////////////////////////////////////////
        if (collision.tag == "PowerUpSPallete")
        {
            if (getPlayerId() == PlayerID.Player1)
            {
                pallete = GameObject.FindGameObjectWithTag("Jugador1");
                jugadoresScript = pallete.GetComponent<Jugadores>();
                pallete.transform.localScale -= new Vector3(0.5f, 0, 0);
                StartCoroutine(jugadoresScript.BackToNormSmall());
            }
            else if (getPlayerId() == PlayerID.Player2)
            {
                pallete = GameObject.FindGameObjectWithTag("Jugador2");
                jugadoresScript = pallete.GetComponent<Jugadores>();
                pallete.transform.localScale -= new Vector3(0.5f, 0, 0);
                StartCoroutine(jugadoresScript.BackToNormSmall());
            }
        }


        
        OnTriggerExit2D(collision);
        

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
        StopAllCoroutines();

    }

    IEnumerator YieldStopTime(float n)
    {
        Debug.Log(n);
        yield return new WaitForSeconds(n);
        speed = speed + 3;
        StopAllCoroutines();

    
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
