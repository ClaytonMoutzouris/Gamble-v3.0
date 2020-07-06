using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject[] players = new GameObject[4];
    int numPlayers = 0;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            if (numPlayers < 3)
            {
                players[numPlayers] = Instantiate(playerPrefab);
                numPlayers++;
            }
        }
    }
}
