using UnityEngine;
using UnityEngine.SceneManagement;

public class QandAScript : MonoBehaviour
{
    public static bool victory = false;

    public Texture NextStage;
    public Texture BackToMainMenu;

    public void Start()
    {
        victory = false;
    }

    public void OnGUI()
    {
        if (victory)
        {
            GUI.backgroundColor = Color.clear;

            //if (GUI.Button(new Rect(Screen.width * .05f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), NextStage))
            //{
            //    SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            //}

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), BackToMainMenu))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }

        }
    }

}
