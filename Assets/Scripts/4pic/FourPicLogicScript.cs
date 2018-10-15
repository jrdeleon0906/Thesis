using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Common;
using System.Collections.Generic;
using System.Linq;

public class FourPicLogicScript : MonoBehaviour {

    private int numOfChoicesBox = 18;

    public void InstantiateRandomizePic(QuestionAndAnswers qAndA, GameObject pic)
    {
        GameObject image1 = Instantiate(pic, new Vector3(1, 1)
                                        , Quaternion.identity) as GameObject;
        image1.transform.SetParent(gameObject.transform, false);
        image1.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
        image1.GetComponent<RectTransform>().position = new Vector3(Screen.width * .25f, Screen.height * .8f);

        GameObject image2 = Instantiate(pic, new Vector3(1, 1)
                                , Quaternion.identity) as GameObject;
        image2.transform.SetParent(gameObject.transform, false);
        image2.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
        image2.GetComponent<RectTransform>().position = new Vector3(Screen.width * .75f, Screen.height * .8f);

        GameObject image3 = Instantiate(pic, new Vector3(1, 1)
                                , Quaternion.identity) as GameObject;
        image3.transform.SetParent(gameObject.transform, false);
        image3.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
        image3.GetComponent<RectTransform>().position = new Vector3(Screen.width * .25f, Screen.height * .5f);

        GameObject image4 = Instantiate(pic, new Vector3(1, 1)
                                , Quaternion.identity) as GameObject;
        image4.transform.SetParent(gameObject.transform, false);
        image4.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
        image4.GetComponent<RectTransform>().position = new Vector3(Screen.width * .75f, Screen.height * .5f);

        GameObject[] pics = GameObject.FindGameObjectsWithTag(ConstStrings.PicTags);

        int index = 0;
        foreach (GameObject item in pics)
        {
            item.GetComponent<Image>().sprite = qAndA.Images[index];
            index++;
        }
    }

    public void InstantiateAnswer(string answers, GameObject answerBox)
    {
        float additional = 0f;
        GameObject parent = GameObject.Find("/Canvas/AnsPlaceHolder");
        bool first = false;

        foreach (char item in answers)
        {
            if ((item >= '0' && item <= '9') || (item >= 'A' && item <= 'Z') || (item >= 'a' && item <= 'z') || item == ' ')
            {
                GameObject answerBoxObj = Instantiate(answerBox, new Vector3(1, 1)
                            , Quaternion.identity) as GameObject;

                answerBoxObj.transform.SetParent(parent.transform, false);
                answerBoxObj.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(30,30);
                if (!first)
                {
                    additional += Screen.width * .1f / 2;
                    first = true;
                }
                answerBoxObj.GetComponent<RectTransform>().position = new Vector3(additional, Screen.height * .35f);
                answerBoxObj.GetComponentInChildren<Text>().text = "" + item.ToStringToUpper();
                answerBoxObj.GetComponentInChildren<Text>().enabled = false;
                additional += Screen.width * .1f;

            }

        }
    }

    public void StartInstantiateOfChoicesBox(QuestionAndAnswers QandA, GameObject choicesBox)
    {
        List<AnswerAndIndex> letterPos = RandomizePositionOfAnswers(QandA);
        InstantiateChoicesBox(choicesBox, letterPos);
    }

    public void SetHintText(string hint)
    {
        GameObject hintText = GameObject.Find(ConstStrings.HintTxt);
        hintText.GetComponent<Text>().text = hint;
    }

    private void InstantiateChoicesBox(GameObject choicesBox, List<AnswerAndIndex> letterPos)
    {
        List<char> noRepeatedLetter = new List<char>();
        float additionalWidth = 0f;
        float additionalHeight = 0f;

        for (int i = 0; i < numOfChoicesBox; i++)// Number of box.
        {
            if (i == numOfChoicesBox / 2)
            {
                additionalWidth = 0f;
                additionalHeight = -(Screen.width * .1f);
            }

            GameObject choicesBoxObj = Instantiate(choicesBox, new Vector3(1, 1)
                        , Quaternion.identity) as GameObject;

            choicesBoxObj.transform.SetParent(gameObject.transform, false);
            choicesBoxObj.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(30,30);
            choicesBoxObj.GetComponent<RectTransform>().position = new Vector3(Screen.width * .1f + additionalWidth, Screen.height * .25f + additionalHeight);
            choicesBoxObj.GetComponentInChildren<Text>().text = "" + SetLetter(i, letterPos, noRepeatedLetter);
            additionalWidth += Screen.width * .1f;
        }
    }

    private List<AnswerAndIndex> RandomizePositionOfAnswers(QuestionAndAnswers qAndA)
    {
        List<AnswerAndIndex> returnObj = new List<AnswerAndIndex>();

        int lengthOfAnsBox = qAndA.Answer.Length;

        for (int i = 0; i < lengthOfAnsBox; i++)
        {
            AnswerAndIndex tempLetterPos = new AnswerAndIndex();

            int indexOfAns = Random.Range(0, numOfChoicesBox);
            if (returnObj.Select(x => x.Index).Contains(indexOfAns))
            {
                i--;
            }
            else
            {
                tempLetterPos.Index = indexOfAns;
                tempLetterPos.Letter = qAndA.Answer[i];
                returnObj.Add(tempLetterPos);
            }

        }

        return returnObj;
    }

    private char GetRandomLetter()
    {
        // This method returns a random lowercase letter.
        // ... Between 'a' and 'z' inclusize.
        int num = Random.Range(0, 26); // Zero to 25
        char let = (char)('A' + num);
        return let;
    }

    private char SetLetter(int index, List<AnswerAndIndex> letterPos, List<char> noRepeatedLetter)
    {
        char returnObj = letterPos.Where(x => x.Index == index).Select(x => x.Letter).FirstOrDefault().CharToUpper();

        if (letterPos.Select(x => x.Index).Contains(index))
        {
            if (!(returnObj >= 'A' && returnObj <= 'Z'))
            {
                returnObj = GetRandomLetter();
            }
        }
        else
        {
            returnObj = GetRandomLetter();
        }

        int loops = 0;
        while (noRepeatedLetter.Contains(returnObj))
        {
            if (loops == 26)//number of letter in alphabelt 
            {
                break;
            }
            returnObj = GetRandomLetter();
            loops++;
        }

        noRepeatedLetter.Add(returnObj);
        return returnObj;
    }
}
