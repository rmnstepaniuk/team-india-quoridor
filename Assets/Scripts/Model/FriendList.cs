using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendList : MonoBehaviour
{

    public List<GameObject> friendList;
    public GameManager gm;

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
        }
    }
}
