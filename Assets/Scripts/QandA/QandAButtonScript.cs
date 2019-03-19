
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QandAButtonScript : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject.tag == ConstStrings.QandAAns)
        {
            GetComponent<Image>().color = Color.yellow;
            QandAScript.victory = true;
        }
    }

}
