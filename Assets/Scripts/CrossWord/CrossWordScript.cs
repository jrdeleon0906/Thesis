﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossWordScript : MonoBehaviour {


    public static string selectedCharacters;

    public static int correctAnswer = 0;

    public static bool victory = false;

    public Texture NextStage;
    public Texture BackToMainMenu;

    // Use this for initialization
    void Start () {
        victory = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnGUI()
    {
        if (victory)
        {
            GUI.backgroundColor = Color.clear;

            if (GUI.Button(new Rect(Screen.width * .05f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), NextStage))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), BackToMainMenu))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }

        }
    }
}
