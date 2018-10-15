using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour, IPointerDownHandler
{

    public void Start()
    {
        DisableEnableButtons(ConstStrings.AfterPlayHolder,false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject.name != null)
        {

            switch (eventData.selectedObject.name)
            {
                case ConstStrings.PlayBtn:
                    GameObject afterPlay = GameObject.Find(ConstStrings.AfterPlayHolder);
                    if (afterPlay != null)
                    {
                        DisableEnableButtons(ConstStrings.AfterPlayHolder, true);
                    }
                    GameObject initial = GameObject.Find(ConstStrings.InitialHolder);
                    if (initial != null)
                    {
                        DisableEnableButtons(ConstStrings.InitialHolder, true);
                    }
                    break;
                case ConstStrings.SettingsBtn:
                    Debug.Log(ConstStrings.SettingsBtn);
                    break;
                case ConstStrings.QuitBtn:
                        Application.Quit();
                        //System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                case ConstStrings.PicWordBtn:
                        SceneManager.LoadScene(ConstStrings.PicWordsScene);
                    break;
                case ConstStrings.BackToMainMenuBtn:
                        SceneManager.LoadScene(ConstStrings.MainMenuScene);
                    break;
                default:
                    break;
            }
        }
    }

    private static void DisableEnableButtons(string whatToDisable,bool isEnable)
    {
        GameObject afterPlay = GameObject.Find(whatToDisable);
        for (int i = 0; i < afterPlay.transform.childCount; i++)
        {
            Transform tempObject = afterPlay.transform.GetChild(i);
            tempObject.GetComponent<Image>().enabled = isEnable;
            Text text = tempObject.GetComponentInChildren<Text>();
            if (text != null)
            {
                text.enabled = isEnable;
            }
        }
    }
}
