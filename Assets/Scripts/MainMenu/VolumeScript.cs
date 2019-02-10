using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeScript : MonoBehaviour, IEndDragHandler {

    public GameObject music;
    public Slider volume;

    public void OnEndDrag(PointerEventData eventData)
    {
        if (music == null)
        {
            GameObject musicTemp = GameObject.Find("Music") as GameObject;
            music = musicTemp;
        }

        music.GetComponent<AudioSource>().volume = volume.value;
    }
}
    