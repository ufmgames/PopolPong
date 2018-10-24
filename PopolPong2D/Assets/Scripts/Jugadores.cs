using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerID { Player1 = 1, Player2 = 2 };

public class Jugadores : MonoBehaviour
{
    Rigidbody2D rb;
    public float Velocidad;
    public PlayerID playerId;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == ("Jugador1"))
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal1"), 0, 0) * Velocidad * Time.deltaTime);

        } else if(gameObject.tag == ("Jugador2"))
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal2"), 0, 0) * Velocidad * Time.deltaTime);

        }
    }

    public void BPPlayer()
    {
        transform.localScale += new Vector3(2, 1.5f, 1);

    }
}
