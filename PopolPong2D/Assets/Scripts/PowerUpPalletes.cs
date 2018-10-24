using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPalletes : MonoBehaviour {
    GameObject pallete;
    Jugadores jugadoresScript;
    GameObject Ball;
    Ball ballScript;
    bool action; 

    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        ballScript = Ball.GetComponent<Ball>();
        action = true;
        if (ballScript.getPlayerId() == PlayerID.Player1)
        {
            pallete = GameObject.FindGameObjectWithTag("Jugador1");

            pallete.transform.localScale += new Vector3(2, 0, 0);

            StartCoroutine(WaitTime());


        }
        else if (ballScript.getPlayerId() == PlayerID.Player2)
        {
            pallete = GameObject.FindGameObjectWithTag("Jugador2");
            pallete.transform.localScale += new Vector3(2, 0, 0);
            StartCoroutine(WaitTime());

        }
        Destroy(this.gameObject);

    }





    IEnumerator WaitTime()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(2.5f);

    }
}
