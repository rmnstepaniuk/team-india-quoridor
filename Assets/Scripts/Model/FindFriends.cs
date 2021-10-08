using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFriends : MonoBehaviour
{
    public GameObject friendBase;
    private FriendList friendList;
    private FriendList friendFriendList;

    public GameObject RNotFriend;
    public GameObject BNotFriend;
    public GameObject DNotFriend;
    private bool friendFound = false;

    public int price = 0;

    // Start is called before the first frame update

    private void Start()
    {
        friendList = friendBase.GetComponent<FriendList>();
    }

    private void OnTriggerEnter(Collider friend)
    {
        if (!friendFound)
        {
            
            if (friend.gameObject.tag == "Square")
            {
                if (this.tag == "RightNotFriend")
                {
                    RNotFriend = friend.gameObject;
                    friendList.addFriend(friend.gameObject);
                    friendFriendList = friend.gameObject.GetComponent<FriendList>();
                    friendFriendList.addFriend(friendBase);
                }
                if (this.tag == "BottomNotFriend")
                {
                    BNotFriend = friend.gameObject;
                    friendList.addFriend(friend.gameObject);
                    friendFriendList = friend.gameObject.GetComponent<FriendList>();
                    friendFriendList.addFriend(friendBase);
                }
                if (this.tag == "DiagonalNotFriend")
                {
                    DNotFriend = friend.gameObject;
                }

                friendFound = true;
            }
        }
    }

}
