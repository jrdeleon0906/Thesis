using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoicesBoxScript : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.timeScale == 1)
        {
            string letterClicked = this.gameObject.GetComponentInChildren<Text>().text;

            GameObject[] answer = GameObject.FindGameObjectsWithTag(FourPicScript.questionAnswer);

            foreach (var item in answer)
            {
                if (item.GetComponentInChildren<Text>() != null)
                {
                    string ansBox = item.GetComponentInChildren<Text>().text;

                    if (letterClicked.Contains(ansBox))
                    {
                        item.GetComponentInChildren<Text>().enabled = true;
                    }
                }
            }


            if (!FourPicScript.victory)
            {
                int correctAns = 0;
                GameObject[] ansBox = GameObject.FindGameObjectsWithTag(FourPicScript.questionAnswer);

                int questionLengthRemovedSpecialCharacters = FourPicScript.questionAnswer.RemoveSpecialCharacters().Length;

                foreach (var item in ansBox)
                {
                    if (item.name.Contains(ConstStrings.AnsBox))
                    {
                        if (item.GetComponentInChildren<Text>().enabled)
                        {
                            correctAns++;
                            if (correctAns == questionLengthRemovedSpecialCharacters)
                            {
                                FourPicScript.victory = true;
                            }
                        }
                    }
                }
            }

        }
        
    }
}
