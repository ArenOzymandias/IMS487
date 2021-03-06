﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public Text winText;
    public GameObject player;

    private int numOfEnemies;
    private int playerHealth;
    

	// Use this for initialization
	void Start () {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        playerHealth = player.GetComponent<PlayerController>().playerHealth;

        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        playerHealth = player.GetComponent<PlayerController>().playerHealth;
        if(playerHealth <= 0)        {
            Destroy(player);
            winText.text = "Game Over";
        }

        if (numOfEnemies <= 0)
        {
            winText.text = "You Win";
        }
        /*
         * End the game if there are no enemies left
         */

    }

    /*
     * This is currently public... needs to be reworked.
     * 
     * Updates numOfEnemies whenever an enemy is destroyed
     * 
     */
    public void UpdateEnemyCount()    {
        numOfEnemies--;
    }


}
