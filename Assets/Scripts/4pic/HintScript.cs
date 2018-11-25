using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts._4pic
{
    public class HintScript : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            GameObject hintText = GameObject.Find(ConstStrings.HintTxt);
            hintText.GetComponent<Text>().enabled = !hintText.GetComponent<Text>().enabled;
        }
    }
}
