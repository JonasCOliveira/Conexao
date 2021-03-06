﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Default page to start the game
// Create a field Player's name
// Check if player's name isn't empty 

public class Play : MonoBehaviour
{
    public Button playButton;
    public InputField usernameInput;

    public Text nameAlert;

     private void Start() {
        
		Button btn = playButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        nameAlert.GetComponent<Text>().enabled = false;
     }

    void TaskOnClick(){

        if(usernameInput.text != ""){
            PlayerPrefs.SetString("playersName", usernameInput.text);
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        else {
            nameAlert.GetComponent<Text>().enabled = true;
        }
	}


}
