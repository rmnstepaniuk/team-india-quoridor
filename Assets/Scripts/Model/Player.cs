using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerType
    {
        Player1,
        Player2,
        Bot
    }

    public PlayerType playerType = PlayerType.Player1;

    public int walls;

    private Player opponent;
    public bool myTurn = false;

    public GameObject currentSquare;
    private Vector3 targetSquareLocation;

    private GameManager gm;




    private void Start()
    {

        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(player != this.gameObject)
            {
                opponent = player.GetComponent<Player>();
            }
        }
    }

    public void PassTurn()
    {
        if (gm.gameState == GameManager.GameState.Playing)
        {
            opponent.myTurn = myTurn;
            myTurn = !myTurn;
        }
        else
        {
            myTurn = false;
        }
    }

    public void WallPassTurn()
    {
        myTurn = !myTurn;
    }

    public void MoveToSquare(GameObject square)
    {
        if (opponent.currentSquare != square)
        {
            targetSquareLocation = square.transform.position;
            targetSquareLocation.y += 2;
            this.gameObject.transform.position = targetSquareLocation;
            currentSquare = square;
            if (playerType == PlayerType.Player1)
            {
                if (currentSquare.GetComponent<FindFriends>().price == 9)
                {
                    print("оюаедю!!!");
                    gm.ChangeState(GameManager.GameState.Player1Win);
                }
            }
            else if (playerType == PlayerType.Player2)
            {
                if (currentSquare.GetComponent<FindFriends>().price == 1)
                {
                    gm.ChangeState(GameManager.GameState.Player2Win);
                }
            }
            else if (playerType == PlayerType.Bot)
            {
                if (currentSquare.GetComponent<FindFriends>().price == 1)
                {
                    gm.ChangeState(GameManager.GameState.BotWin);
                }
            }
            this.PassTurn();
        }
    }


}
