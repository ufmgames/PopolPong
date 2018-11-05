using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUSlowSpeed : MonoBehaviour {

    bool activePowerUp = true;
    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ball") && activePowerUp)
        {
            activePowerUp = false;
            
            Destroy(this.gameObject);
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            activePowerUp = false;
        }
    }

}
