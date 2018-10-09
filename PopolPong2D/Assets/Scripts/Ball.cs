using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 ballMovement = Vector2.zero;
    [SerializeField] private float speed = 3;
    private PlayerID playerId;

    private void Update()
    {
        transform.Translate(ballMovement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jugador1")
        {
            playerId = PlayerID.Player1;
        }
        else if (collision.tag == "Jugador2")
        {
            playerId = PlayerID.Player2;
        }
    }

    public PlayerID getPlayerId()
    {
        return playerId;
    }

    public void updateMovement(Vector2 newVector)
    {
        ballMovement = newVector;
    }

    public void updateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public Vector2 getBallMovement()
    {
        return ballMovement;
    }

}
