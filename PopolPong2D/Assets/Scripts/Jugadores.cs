using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerID { Player1 = 1, Player2 = 2 };

public class Jugadores : MonoBehaviour
{
    GameObject PU;
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

    

    public IEnumerator BackToNormBig()
    {

        yield return new WaitForSeconds(2.5f);
        this.gameObject.transform.localScale -= new Vector3(2, 0, 0);

    }

    public IEnumerator BackToNormSmall()
    {

        yield return new WaitForSeconds(2.5f);
        this.gameObject.transform.localScale += new Vector3(0.5f, 0, 0);

    }
}