﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour, IPointerDownHandler
{
    public static float volume;

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Thesis")
        {
            DisableEnableButtons(ConstStrings.GameModeHolder, false);
            DisableEnableButtons(ConstStrings.GameCategoryHolder, false);
            DisableEnableButtons(ConstStrings.SettingHolder, false);
            DisableEnableButtons(ConstStrings.HighScoreHolder, false);
            DisableEnableButtons(ConstStrings.AboutHolder, false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject != null)
        {
            if (eventData.selectedObject.name != null)
            {

                switch (eventData.selectedObject.name)
                {
                    case ConstStrings.PlayBtn:
                        GameObject gameMode = GameObject.Find(ConstStrings.GameModeHolder);
                        GameObject initial = GameObject.Find(ConstStrings.InitialHolder);
                        if (gameMode != null)  
                        {
                            DisableEnableButtons(ConstStrings.GameCategoryHolder, true);
                            DisableEnableButtons(ConstStrings.InitialHolder, false);
                        }
                        else if (initial != null)
                        {
                            DisableEnableButtons(ConstStrings.InitialHolder, true);
                        }
                        break;
                    case ConstStrings.SettingsBtn:
                        DisableEnableButtons(ConstStrings.SettingHolder, true);
                        DisableEnableButtons(ConstStrings.InitialHolder, false);
                        break;
                    case ConstStrings.HighScoreBtn:
                        DisableEnableButtons(ConstStrings.HighScoreHolder, true);
                        DisableEnableButtons(ConstStrings.GameModeHolder, false);
                        DisableEnableButtons(ConstStrings.GameCategoryHolder, false);
                        DisableEnableButtons(ConstStrings.SettingHolder, false);
                        DisableEnableButtons(ConstStrings.InitialHolder, false);
                        //DisableEnableButtons(ConstStrings.HighScoreHolder, false);

                        GameObject[] highScoreBox = GameObject.FindGameObjectsWithTag(ConstStrings.PicWordHighScoreBoard);

                        string[] scores = PlayerPrefs.GetString(ConstStrings.PicWordHighScore).Split(',');

                        List<double> highScoresArray = new List<double>();

                        foreach (string item in scores)
                        {
                            double toPut = 0.0f;
                            double.TryParse(item, out toPut);
                            highScoresArray.Add(toPut);
                        }

                        for(int i = 0; i < highScoresArray.Count -1; i++)
                        {
                            for (int x = 0; x < highScoresArray.Count - i - 1; x++)
                            {
                                if (highScoresArray[x] > highScoresArray[x+1])
                                {
                                    double temp = highScoresArray[x];
                                    highScoresArray[x] = highScoresArray[x + 1];
                                    highScoresArray[x + 1] = temp;
                                }
                            }
                        }

                        int index = 0;
                        foreach (GameObject item in highScoreBox)
                        {
                            if (index < highScoresArray.Count)
                            {
                                item.GetComponentInChildren<Text>().text = highScoresArray[index].ToString("0.0");
                            }

                            index++;
                        }
                        break;
                    case ConstStrings.QuitBtn:
                            Application.Quit();
                        break;
                    case ConstStrings.PicWordBtn:
                            SceneManager.LoadScene(ConstStrings.PicWordsScene);
                        break;
                    case ConstStrings.CrossWordBtn:
                        int randomNum = 1;

                        if (KeepMusicScript.Era != ConstStrings.ChineseBtn)
                        {
                            randomNum = Random.Range(1, 3);
                        }

                        string toLoad = string.Format("{0}-{1}{2}",ConstStrings.CrossWordScene,KeepMusicScript.Era,randomNum);
                        SceneManager.LoadScene(toLoad);
                        break;
                    case ConstStrings.QAndABtn:

                        int randNum = 1;
                        if (KeepMusicScript.Era != ConstStrings.ChineseBtn)
                        {
                            randNum = Random.Range(1, 3);
                        }

                        string QandALoad = string.Format("{0}-{1}{2}", ConstStrings.QandAScene, KeepMusicScript.Era, randNum);
                        SceneManager.LoadScene(QandALoad);

                        break;
                    case ConstStrings.BackToMainMenuBtn:
                        SceneManager.LoadScene(ConstStrings.MainMenuScene);
                        break;
                    case ConstStrings.AmericaBtn:
                        SceneManager.LoadScene("America");
                        KeepMusicScript.Era = ConstStrings.AmericaBtn;
                        //DisableEnableButtons(ConstStrings.GameModeHolder, true);
                        //DisableEnableButtons(ConstStrings.GameCategoryHolder, false);
                        break;
                    case ConstStrings.ChineseBtn:
                        SceneManager.LoadScene("Japanese");
                        KeepMusicScript.Era = ConstStrings.ChineseBtn;
                        //DisableEnableButtons(ConstStrings.GameModeHolder, true);
                        //DisableEnableButtons(ConstStrings.GameCategoryHolder, false);
                        break;
                    case ConstStrings.SpanishBtn:
                        SceneManager.LoadScene("Spanish");
                        KeepMusicScript.Era = ConstStrings.SpanishBtn;
                        //DisableEnableButtons(ConstStrings.GameModeHolder, true);
                        //DisableEnableButtons(ConstStrings.GameCategoryHolder, false);
                        break;
                    case ConstStrings.About:
                        SceneManager.LoadScene("About");
                        break;
                    case "Continue":
                        SceneManager.LoadScene("GameMode");
                        break;
                    default:
                        break;
                }
            }
        }

    }

    private static void DisableEnableButtons(string whatToDisable,bool isEnable)
    {
        GameObject tempGameObject = GameObject.Find(whatToDisable);
        if (tempGameObject != null)
        {
            for (int i = 0; i < tempGameObject.transform.childCount; i++)
            {
                Transform transformObject = tempGameObject.transform.GetChild(i);
                Image image = transformObject.GetComponent<Image>();

                if (image != null)
                {
                    image.enabled = isEnable;
                }

                Text text = transformObject.GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.enabled = isEnable;
                }

                Slider slider = transformObject.GetComponentInChildren<Slider>();
                if (slider != null)
                {
                    slider.enabled = isEnable;
                }
            }
        }
    }
}
