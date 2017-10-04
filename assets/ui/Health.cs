﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour {
    private int maxHealth;

    public int startingHealth;
    public int healthPerHeart;

    public int currenthealth;
    public GUITexture heartGUI;


    public Texture[] images;

    // Use this for initialization
    private ArrayList hearts = new ArrayList();

    public int maxHeartsPerRow;

    private float spacingX;
    private float spacingY;

    void Start() {
        currenthealth = startingHealth;
        spacingX = heartGUI.pixelInset.width;
        spacingY = -heartGUI.pixelInset.height;
        AddHearts(startingHealth/healthPerHeart);
    }

    public void AddHearts(int n) {
        for (int i =0; i< n; i++)
        {
            Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject,transform.position,Quaternion.identity)).transform;
            newHeart.parent = this.transform;

            int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
            int x = hearts.Count - y * maxHeartsPerRow;

            newHeart.GetComponent<GUITexture>(). pixelInset = new Rect(x * spacingX, y * spacingY,14,14);



            hearts.Add(newHeart);
        }

        maxHealth += n * healthPerHeart;
        UpdateHearts();

    }
    public void ModifyHealth (int amount){
        currenthealth += amount;
        currenthealth = Mathf.Clamp(currenthealth,0, maxHealth);
        UpdateHearts();
        
        }
    private void UpdateHearts(){

        bool restAreEmpty = false;
        int i = 1;
        foreach (Transform heart in hearts)
        {
            if (restAreEmpty)
            {
                heart.GetComponent<GUITexture>().texture = images[images.Length - 1];
            }
            else
            {


                if (currenthealth >= i * healthPerHeart){
                    heart.GetComponent<GUITexture>().texture = images[0];
                }
                else {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currenthealth));
                    int healthPerImage = healthPerHeart / images.Length;
                    int imageIndex = currentHeartHealth / healthPerImage ;

                    if(imageIndex == 0 && currentHeartHealth > 0){
                        imageIndex = 1;
                    }

                    heart.GetComponent<GUITexture>().texture = images[imageIndex];
                    restAreEmpty = true;
                }
            }
        }
    }
}