using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaYIELD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        intento();
    }

    void intento()
    {
        StartCoroutine(YieldStopTime(1.5f));
    }

    IEnumerator YieldStopTime(float n)
    {
        Debug.Log("entra");
        yield return new WaitForSeconds(n);
        Debug.Log("sale");

        StopAllCoroutines();


    }
}
