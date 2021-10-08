using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalButton : MonoBehaviour
{
    public GameObject wall;
    private int walls;
    public GameObject friendBase;
    private FriendList friendList;
    private FriendList downfriendList;
    public GameObject RightFriendFinder;
    public GameObject BottomFriendFinder;
    public GameObject DiagonalFriendFinder;

    private GameManager gm;

    private void Start()
    {
        friendList = friendBase.GetComponent<FriendList>();
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gm.gameState == GameManager.GameState.Playing)
        {
            foreach (Player player in gm.playerList)
            {
                if (player.GetComponent<Player>().myTurn)
                {
                    walls = player.GetComponent<Player>().walls;
                    if (walls > 0)
                    {
                        Debug.Log("Check > 0");
                        wall.SetActive(true);
                        friendList.RemoveFriend(RightFriendFinder.GetComponent<FindFriends>().RNotFriend);
                        RightFriendFinder.GetComponent<FindFriends>().RNotFriend.GetComponent<FriendList>().RemoveFriend(friendBase);

                        downfriendList = BottomFriendFinder.GetComponent<FindFriends>().BNotFriend.GetComponent<FriendList>();
                        downfriendList.RemoveFriend(DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend);
                        DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend.GetComponent<FriendList>().RemoveFriend(BottomFriendFinder.GetComponent<FindFriends>().BNotFriend);
                        player.GetComponent<Player>().walls -= 1;
                    }
                }
            }

            foreach (Player player in gm.playerList)
            {
                player.WallPassTurn();
            }


        }


    }
}