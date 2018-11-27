using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PicWordButtonScript : MonoBehaviour, IPointerDownHandler
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
        GameObject backToMainMenuImg = GameObject.Find(ConstStrings.BackToMainMenuHolder);
        GameObject pauseBtn = GameObject.Find(ConstStrings.PauseBtn);
        GameObject[] pics = GameObject.FindGameObjectsWithTag(FourPicScript.questionAnswer);

        if (Time.timeScale == 0)
        {
            ShowHideImages(backToMainMenuImg, pics,true);

            pauseBtn.GetComponent<Image>().sprite = pause;
            Time.timeScale = 1;
        }
        else
        {
            ShowHideImages(backToMainMenuImg, pics, false);

            pauseBtn.GetComponent<Image>().sprite = play;
            Time.timeScale = 0;
        }
    }

    private void ShowHideImages(GameObject backToMainMenuImg, GameObject[] pics, bool showImage)
    {
        backToMainMenuImg.GetComponentInChildren<Image>().enabled = !showImage;

        foreach (GameObject item in pics)
        {
            item.GetComponent<Image>().enabled = showImage;
        }
    }
}
