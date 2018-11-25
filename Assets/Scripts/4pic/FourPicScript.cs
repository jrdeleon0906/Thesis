using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Common;
using System.Collections.Generic;

public class FourPicScript : FourPicLogicScript
{

    public QuestionAndAnswers[] QandA;

    public GameObject Pic;
    public GameObject AnswerBox;
    public GameObject ChoicesBox;

    public Texture ForuPicBg;
    public Texture NextStage;
    public Texture BackToMainMenu;

    public bool victory = false;

    private QuestionAndAnswers question;
    private List<int> previousQuestion = new List<int>();

    public void Start()
    {

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
    }

    public void Update()
    {
        if (!victory)
        { 
            GameObject[] ansBox = GameObject.FindGameObjectsWithTag(ConstStrings.PicsAnsBox);

            int questionLengthRemovedSpecialCharacters = question.Answer.RemoveSpecialCharacters().Length;

            if (ansBox.Where(x => x.GetComponentInChildren<Text>().enabled).Count() == questionLengthRemovedSpecialCharacters)
            {
                victory = true;
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

                if (QandA.Length == previousQuestion.Count)
                {

                    SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
                }
                else
                {
                    victory = !victory;
                    Start();
                }

            }

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .7f, Screen.width * .2f, Screen.width * .2f), BackToMainMenu))
            {
                SceneManager.LoadScene(ConstStrings.MainMenuScene, LoadSceneMode.Single);
            }

        }
    }
}
