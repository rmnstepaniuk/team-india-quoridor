using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoryzontalButton : MonoBehaviour
{
    public GameObject wall;
    private int walls = 0;
    public GameObject friendBase;
    private FriendList friendList;
    private FriendList rightfriendList;
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
                        friendList.RemoveFriend(BottomFriendFinder.GetComponent<FindFriends>().BNotFriend);
                        BottomFriendFinder.GetComponent<FindFriends>().BNotFriend.GetComponent<FriendList>().RemoveFriend(friendBase);

                        rightfriendList = RightFriendFinder.GetComponent<FindFriends>().RNotFriend.GetComponent<FriendList>();
                        rightfriendList.RemoveFriend(DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend);
                        DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend.GetComponent<FriendList>().RemoveFriend(RightFriendFinder.GetComponent<FindFriends>().RNotFriend);
                        player.GetComponent<Player>().walls -= 1;
                        foreach (Player player1 in gm.playerList)
                        {
                            bool reachCheck;
                            if (player1.playerType == Player.PlayerType.Player1)
                            {
                                reachCheck = player1.currentSquare.GetComponent<FriendList>().canReachExit(7);
                            }
                            else
                            {
                                reachCheck = player1.currentSquare.GetComponent<FriendList>().canReachExit(1);
                            }
                            print($"{player1} -- {reachCheck}");
                            if (!reachCheck)
                            {
                                friendList.addFriend(BottomFriendFinder.GetComponent<FindFriends>().BNotFriend);
                                BottomFriendFinder.GetComponent<FindFriends>().BNotFriend.GetComponent<FriendList>().addFriend(friendBase);
                                rightfriendList.addFriend(DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend);
                                DiagonalFriendFinder.GetComponent<FindFriends>().DNotFriend.GetComponent<FriendList>().addFriend(RightFriendFinder.GetComponent<FindFriends>().RNotFriend);
                                player.GetComponent<Player>().walls += 1;
                                wall.SetActive(false);
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            foreach (Player player1 in gm.playerList)
            {
                player1.WallPassTurn();
                player1.BotMove();
            }

            
        }


    }

    //public bool canReachExit(int price)
    //{
    //    List<GameObject> reachableFriends = friendList.friendList;
    //    friendBase.GetComponent<FriendList>().friendsChecked = true;
    //    bool notAllFriendsChecked = true;
    //    while (notAllFriendsChecked)
    //    {
    //        notAllFriendsChecked = false;
    //        foreach (GameObject friend in reachableFriends)
    //        {
    //            if (!friend.GetComponent<FriendList>().friendsChecked)
    //            {
    //                foreach (GameObject friend2 in friend.GetComponent<FriendList>().friendList)
    //                {
    //                    if (!reachableFriends.Contains(friend2))
    //                    {
    //                        reachableFriends.Add(friend2);
    //                    }
    //                }
    //                friend.GetComponent<FriendList>().friendsChecked = true;
    //                notAllFriendsChecked = true;
    //                break;
    //            }
    //        }
    //    }

    //    friendBase.GetComponent<FriendList>().friendsChecked = false;
    //    foreach (GameObject friend in reachableFriends)
    //    {
    //        friend.GetComponent<FriendList>().friendsChecked = false;
    //    }

    //    foreach (GameObject friend in reachableFriends)
    //    {
    //        if (friend.GetComponent<FindFriends>().price == price)
    //        {
    //            return true;
    //        }
    //    }

    //    return false;
    //}

}
