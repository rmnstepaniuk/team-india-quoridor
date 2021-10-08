using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Player1Win,
        Player2Win,
        BotWin
    }

    private void Start()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player.GetComponent<Player>());
        }
    }

    public GameObject player1WinCanvas;
    public GameObject player2WinCanvas;
    public GameObject BotWinCanvas;

    public List<Player> playerList = new List<Player>();

    public GameState gameState = GameState.Playing;

    public void ChangeState(GameState state)
    {
        gameState = state;

        if (state == GameState.Player1Win)
        {
            player1WinCanvas.SetActive(true);
        }
        else if (state == GameState.Player2Win)
        {
            player2WinCanvas.SetActive(true);
        }

    }

}
