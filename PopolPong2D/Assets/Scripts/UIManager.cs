using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshPro scoreJugador1;
    [SerializeField] private TextMeshPro scoreJugador2;

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
}
