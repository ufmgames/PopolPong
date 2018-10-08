using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreJugador1;
    [SerializeField] private TextMeshPro scoreJugador2;
    [SerializeField] private int activeLevel;
    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        levels[activeLevel].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            changeLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeLevel(2);
        }

    }

    public void changeLevel(int newActiveLevel)
    {
        levels[activeLevel].SetActive(false);
        activeLevel = newActiveLevel;
        levels[newActiveLevel].SetActive(true);
    }

    public void updatePlayerScore(PlayerID playerId, int score)
    {
        if (playerId == PlayerID.Player1)
        {
            scoreJugador1.SetText(score.ToString());
        }
        else if (playerId == PlayerID.Player2)
        {
            scoreJugador2.SetText(score.ToString());
        }
    }

    private void GenerateBalls()
    {

    }



}
