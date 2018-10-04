using UnityEngine;

public class Ball : MonoBehaviour {

    private bool isGoal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ring")
        {
            Debug.Log("Enter");
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
                if(goalRing.CheckGoal(this.gameObject))
                {
                    Debug.Log("Goalllllllllllllllll");
                    isGoal = true;
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
