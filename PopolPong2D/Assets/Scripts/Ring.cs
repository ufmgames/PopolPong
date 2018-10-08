using UnityEngine;

public class Ring : MonoBehaviour
{

    [SerializeField] private GameObject _upLimit;
    [SerializeField] private GameObject _downLimit;
    [SerializeField] private GameObject _leftLimit;
    [SerializeField] private GameObject _rightLimit;

    public bool CheckGoal(GameObject ball)
    {
        if (ball.transform.position.x > _leftLimit.transform.position.x &&
            ball.transform.position.x < _rightLimit.transform.position.x &&
            ball.transform.position.y < _upLimit.transform.position.y &&
            ball.transform.position.y > _downLimit.transform.position.y)
        {
            return true;
        }
        return false;
    }
}
