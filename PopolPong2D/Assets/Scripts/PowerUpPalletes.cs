using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPalletes : MonoBehaviour
{
    bool activePowerUp = true;

    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ball") && activePowerUp)
        {
            activePowerUp = false;

            Destroy(this.gameObject);
        }
    }



}
