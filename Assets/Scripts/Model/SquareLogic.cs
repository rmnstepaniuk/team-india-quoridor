using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLogic : MonoBehaviour
{
    public GameObject wall;

    private void OnMouseDown()
    {
        wall.SetActive(true);
    }

}
