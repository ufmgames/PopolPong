using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDirection : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            Vector2 ballMovement = ball.getBallMovement();
            ball.updateMovement(new Vector2(ballMovement.x * -1, ballMovement.y));
        }
    }
}
