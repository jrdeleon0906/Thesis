using Assets.Scripts.CrossWord;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour, IPointerDownHandler
{
    public Sprite play;
    public Sprite pause;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (eventData.selectedObject.name)
        {
            case ConstStrings.PauseBtn:
                PauseUnpauseScene();

                break;
            case ConstStrings.BackToMainMenuBtn:
                    SceneManager.LoadScene(ConstStrings.MainMenuScene);
                break;
            default:
                break;
        }
    }

    private void PauseUnpauseScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        List<GameObject> pics = new List<GameObject>();

        switch (scene.name)
        {
            case ConstStrings.PicWordsScene:

                pics.AddRange(GameObject.FindGameObjectsWithTag(FourPicScript.questionAnswer));
                pics.AddRange(GameObject.FindGameObjectsWithTag(ConstStrings.PicsChoices));
                pics.Add(GameObject.Find(ConstStrings.Hint));
                Pause(scene.name, pics);


                break;
            case ConstStrings.CrossWordScene:
                pics.AddRange(GameObject.FindGameObjectsWithTag(ConstStrings.XWordChoice));
                //foreach (string item in CrossWordAnswers.crosswordAnswers)
                //{
                //    pics.AddRange(GameObject.FindGameObjectsWithTag(item));
                //}

                Pause(scene.name, pics);
                break;
            case ConstStrings.QandAScene:
                pics.AddRange(GameObject.FindGameObjectsWithTag(ConstStrings.QandAAns));
                pics.AddRange(GameObject.FindGameObjectsWithTag(ConstStrings.QAndAOtherChoice));
                pics.AddRange(GameObject.FindGameObjectsWithTag(ConstStrings.QAndAQuestion));
                Pause(scene.name, pics);


                break;
            default:
                break;
        }


       

    }

    private void Pause(string scene, List<GameObject> pics)
    {
        GameObject pauseBtn = GameObject.Find(ConstStrings.PauseBtn);
        GameObject backToMainMenuImg = GameObject.Find(ConstStrings.BackToMainMenuHolder);

        ShowHideImages(scene,pics);

        if (Time.timeScale == 0)
        {
            backToMainMenuImg.GetComponentInChildren<Image>().enabled = false;
            pauseBtn.GetComponent<Image>().sprite = pause;
            Time.timeScale = 1;
        }
        else
        {
            backToMainMenuImg.GetComponentInChildren<Image>().enabled = true;
            pauseBtn.GetComponent<Image>().sprite = play;
            Time.timeScale = 0;
        }

    }

    private void ShowHideImages(string scene, List<GameObject> pics)
    {
        bool showImage = false;
        if (Time.timeScale == 0)
        {
            showImage = true;
        }

        foreach (GameObject item in pics)
        {
            item.GetComponent<Image>().enabled = showImage;
            if (item.GetComponentInChildren<Text>() != null)
            {
                item.GetComponentInChildren<Text>().enabled = showImage;
            }
        }
    }
}
