using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QandAButtonScript : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.selectedObject.tag == ConstStrings.QandAAns)
        {
            QandAScript.victory = true;
        }
    }

}
