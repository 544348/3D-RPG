using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //variables
    public int valueOfItem;
    private GameObject item;
    private GameObject player;
    private PlayerMovement playerScript;
    void Start()
    {
        player = GameObject.Find("player");
        playerScript = player.GetComponent<PlayerMovement>();
    }
    public void exit()
    {
        GameObject.Find("Shop").active = false;
    }
    public void buyingItem(int value)
    {
        value = valueOfItem;
        if(playerScript.coins >= value)
        {
            playerScript.coins = playerScript.coins - value;
            playerScript.UpdatingCoinValue();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
