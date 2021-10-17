using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendList : MonoBehaviour
{

    public List<GameObject> friendList;
    public GameManager gm;
    public bool friendsChecked = false;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    public void addFriend(GameObject friend)
    {
        friendList.Add(friend);
    }

    public void RemoveFriend(GameObject friend)
    {
        friendList.Remove(friend);
    }

    private void OnMouseDown()
    {
        foreach (Player player in gm.playerList)
        {
            if (player.currentSquare.GetComponent<FriendList>().friendList.Contains(this.gameObject) && player.myTurn)
            {
                player.MoveToSquare(this.gameObject);
            }

            player.opponent.BotMove();
        }
    }

    public bool canReachExit(int price)
    {
        List<GameObject> reachableFriends = new List<GameObject>(friendList);
        friendsChecked = true;
        bool notAllFriendsChecked = true;
        while (notAllFriendsChecked)
        {
            notAllFriendsChecked = false;
            foreach (GameObject friend in reachableFriends)
            {
                if (!friend.GetComponent<FriendList>().friendsChecked)
                {
                    foreach (GameObject friend2 in friend.GetComponent<FriendList>().friendList)
                    {
                        if (!reachableFriends.Contains(friend2))
                        {
                            reachableFriends.Add(friend2);
                        }
                    }
                    friend.GetComponent<FriendList>().friendsChecked = true;
                    notAllFriendsChecked = true;
                    break;
                }
            }
        }

        friendsChecked = false;
        foreach (GameObject friend in reachableFriends)
        {
            friend.GetComponent<FriendList>().friendsChecked = false;
        }

        foreach (GameObject friend in reachableFriends)
        {
            if (friend.GetComponent<FindFriends>().price == price)
            {
                return true;
            }
        }

        return false;
    }



}
