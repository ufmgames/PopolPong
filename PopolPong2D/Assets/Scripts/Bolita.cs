using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour {
    Rigidbody2D rb;
    public float VelocidadInicial = 5;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Iniciar();
	}
	
	// Update is called once per frame
	void Iniciar ()
    {
        transform.position = Vector3.zero;
        rb.velocity = new Vector3(Random.Range(-1, 2) * VelocidadInicial, -VelocidadInicial);
	}
}
