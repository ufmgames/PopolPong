using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public float VelocidadInicial = 5;
    private bool isGoal = false;
    private PlayerID playerId;
    private float speed = 1;
    private Rigidbody2D Rigidbody;

    private bool hasVelocity = false;

    void Start()
    {
        if (!hasVelocity)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -VelocidadInicial);
        }
    }

    public void Iniciar()
    {
        //transform.position = Vector3.zero;
        Rigidbody.velocity = new Vector3(0, -VelocidadInicial);
        
    }

    public void UpdateVelocity(Vector3 velocityVector)
    {
        GetComponent<Rigidbody2D>().velocity = velocityVector;
        hasVelocity = true;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ring")
        {
            Debug.Log("Stay");
            if (!isGoal)
            {
                Ring goalRing = collision.gameObject.GetComponent<Ring>();
                if (goalRing.CheckGoal(this.gameObject))
                {
                    Debug.Log("Goalllllllllllllllll");
                    isGoal = true;
                    gameManager.GoalScore(playerId, 1);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ring")
        {
            Debug.Log("Exit");
            isGoal = false;
        }
    }
}
