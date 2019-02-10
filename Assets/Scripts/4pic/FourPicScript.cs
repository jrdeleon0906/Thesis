using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class FourPicScript : FourPicLogicScript
{

    public QuestionAndAnswers[] QandA;

    public GameObject Pic;
    public GameObject AnswerBox;
    public GameObject ChoicesBox;
    public GameObject TimerGameObject;
    

    public Texture ForuPicBg;
    public Texture NextStage;
    public Texture BackToMainMenu;
    public Texture GameOverTexture;

    public static bool victory = false;
    bool gameOver = false;

    private QuestionAndAnswers question;
    private List<int> previousQuestion = new List<int>();

    public static string questionAnswer;

    public float timer = 30;

    public void Start()
    {
        victory = false;
        Time.timeScale = 1;

        List<int> tempIndex = new List<int>();
        for (int i = 0; i < QandA.Length; i++)
        {
            if (!previousQuestion.Contains(i))
            tempIndex.Add(i);
        }

        int indexOfQuestion = tempIndex[Random.Range(0, tempIndex.Count)];
        previousQuestion.Add(indexOfQuestion);
        question = QandA[indexOfQuestion];

        ShowQuestionsAndAnswer(question);
        StartInstantiateOfChoicesBox(question, ChoicesBox);
        SetHintText(question.Hint);

        questionAnswer = question.Answer;
    }

    public void Update()
    {
        if (!gameOver)
        {
            timer -= Time.deltaTime;
            TimerGameObject.GetComponentInChildren<Text>().text = timer.ToString("0.0");
            if (timer < 0)
            {
                gameOver = true;
            }
        }
    }

    private void DestroyGameObjects(string objectTag)
    {
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag(objectTag);
        foreach (GameObject item in gameObject)
        {
            DestroyImmediate(item);
            DestroyImmediate(item.gameObject);
        }
    }

    public void OnGUI()
    {

        if (victory)
        {
            GUI.backgroundColor = Color.clear;

            if (GUI.Button(new Rect(Screen.width * .05f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), NextStage))
            {

                DestroyGameObjects(ConstStrings.PicTags);
                DestroyGameObjects(ConstStrings.PicsAnsBox);
                DestroyGameObjects(ConstStrings.PicsChoices);
                DestroyGameObjects(questionAnswer);

                if (QandA.Length == previousQuestion.Count)
                {
                    SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
                }
                else
                {
                    victory = !victory;
                    string previousHighScore = PlayerPrefs.GetString(ConstStrings.PicWordHighScore);
                    PlayerPrefs.SetString(ConstStrings.PicWordHighScore, previousHighScore + "," + timer.ToString("0.0"));
                    Start();
                }

            }

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), BackToMainMenu))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }

        }

        if (gameOver)
        {
            GUI.backgroundColor = Color.clear;

            DestroyGameObjects(ConstStrings.PicTags);
            DestroyGameObjects(ConstStrings.PicsAnsBox);
            DestroyGameObjects(ConstStrings.PicsChoices);
            DestroyGameObjects(questionAnswer);
            
            DestroyImmediate(GameObject.Find(ConstStrings.PauseBtn));

            GUI.DrawTexture(new Rect(
                Screen.width * .5f - (Screen.width * .3f / 2)
                , Screen.height * .5f - (Screen.height * .4f)
                , Screen.width * .3f
                , Screen.height * .3f),GameOverTexture);

            if (GUI.Button(new Rect(Screen.width * .5f - (Screen.width  * .5f / 2)
                , Screen.height * .5f - (Screen.height * .1f)
                , Screen.width * .5f
                , Screen.width * .5f), BackToMainMenu))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }
        }
    }
}
