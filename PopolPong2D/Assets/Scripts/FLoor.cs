using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLoor : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bolita"))
        {
            col.SendMessage("Iniciar");
        }
    }
}
