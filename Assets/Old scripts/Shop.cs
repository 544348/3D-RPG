using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    //variables
    private GameObject []items;
    private GameObject player;
    private PlayerMovement playerScript;
    private string itemNames;
    private int itemValues;
    private GameObject []itemNameText;
    private GameObject []itemNameValue;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        items = GameObject.FindGameObjectsWithTag("item");
        itemNameText = GameObject.FindGameObjectsWithTag ("ItemName");
        itemNameValue = GameObject.FindGameObjectsWithTag("ItemValue");
        itemNames = items[0].GetComponent<Item>().itemName;
        itemValues = items[0].GetComponent<Item>().itemPrice;
        itemNameText[0].GetComponent<TMP_Text>().text = items[0].GetComponent<Item>().itemName;
        itemNameValue[0].GetComponent<TMP_Text>().text = items[0].GetComponent<Item>().itemPrice.ToString();
        Debug.Log("ItemNames = " + itemNames);
    }
    public void exit()
    {
        GameObject.Find("ShopMenu").active = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void buyingItem(int value)
    {
        value = itemValues;
        Debug.Log("buyingItemButton activated");
        if(playerScript.coins >= value)
        {
            Debug.Log("price of item " + value);
            playerScript.coins = playerScript.coins - value;
            Debug.Log("player has bought item "+ playerScript.coins);
            playerScript.UpdatingCoinValue();
            Debug.Log("player has enough coins");
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
