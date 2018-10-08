using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : MonoBehaviour {
    public Vector2 direccion;
    public float velocidad;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            rb.velocity = direccion.normalized * velocidad;            
        }
    }
}
