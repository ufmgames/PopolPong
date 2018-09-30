using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour {
    Rigidbody2D rb;
    public float Velocidad;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Velocidad, 0);
	}
}
