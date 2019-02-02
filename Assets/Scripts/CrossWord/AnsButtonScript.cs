using Assets.Scripts.CrossWord;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnsButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {

        if (GetComponent<Image>().color != Color.red)
        {
            GetComponent<Image>().color = Color.red;
            CrossWordScript.selectedCharacters += this.gameObject.GetComponentInChildren<Text>().text;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        foreach (var item in CrossWordAnswers.crosswordAnswers)
        {
            if (item.ToLower() == CrossWordScript.selectedCharacters.ToLower())
            {
                GameObject[] toShow = GameObject.FindGameObjectsWithTag(item);

                if (toShow != null)
                {
                    GameObject.Find("CrossWordBox4").GetComponentInChildren<Text>().enabled = true;
                    foreach (var child in toShow)
                    {
                        child.GetComponentInChildren<Text>().enabled = true;
                    }

                    CrossWordScript.correctAnswer++;
                }
            }
        }

        CrossWordScript.selectedCharacters = "";

        GameObject[] removeColor = GameObject.FindGameObjectsWithTag(ConstStrings.XWordChoice);
        if (removeColor != null)
        {
            foreach (var item in removeColor)
            {
                item.GetComponent<Image>().color = Color.white;
            }
        }

        if (CrossWordScript.correctAnswer == CrossWordAnswers.crosswordAnswers.Length)
        {
            CrossWordScript.victory = true;
        }

    }
}
