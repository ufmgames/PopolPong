using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRainBalls : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float ballSpeed;
    private bool activePowerUp = true;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball") && activePowerUp)
        {
            activePowerUp = false;
            GameObject ball1 = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ball1.GetComponent<Ball>().UpdateVelocity(new Vector3(1, 1, 0) * ballSpeed);

            GameObject ball2 = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ball2.GetComponent<Ball>().UpdateVelocity(new Vector3(1, -1, 0) * ballSpeed);

            GameObject ball3 = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ball3.GetComponent<Ball>().UpdateVelocity(new Vector3(-1, -1, 0) * ballSpeed);

            GameObject ball4 = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ball4.GetComponent<Ball>().UpdateVelocity(new Vector3(-1, 1, 0)* ballSpeed);

            Destroy(this.gameObject);
            Debug.Log("generateball");
        }
    }
}
