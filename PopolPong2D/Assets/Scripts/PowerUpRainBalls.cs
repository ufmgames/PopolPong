using UnityEngine;

public class PowerUpRainBalls : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float ballSpeed;
    bool activePowerUp = true;
    private Vector2[] points;

    private void Start()
    {
        points = new Vector2[] { new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1) };
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball") && activePowerUp)
        {
            activePowerUp = false;
            Vector2 powerUpPosition = new Vector2(transform.position.x, transform.position.y);
            for (int i = 0; i < points.Length; i++)
            {
                GameObject ballObject = Instantiate(ballPrefab, powerUpPosition, Quaternion.identity);
                Ball ball = ballObject.GetComponent<Ball>();
                ball.updateMovement(points[i]);
                ball.updateSpeed(5);
            }
            Destroy(this.gameObject);
        }
    }
}
