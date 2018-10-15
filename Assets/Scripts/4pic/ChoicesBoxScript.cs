using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoicesBoxScript : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        string letterClicked = this.gameObject.GetComponentInChildren<Text>().text;

        GameObject[] answer = GameObject.FindGameObjectsWithTag(ConstStrings.PicsAnsBox);

        foreach (var item in answer)
        {
            string ansBox = item.GetComponentInChildren<Text>().text;

            if (letterClicked.Contains(ansBox))
            {
                item.GetComponentInChildren<Text>().enabled = true;
            }
        }
    }
}
