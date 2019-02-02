using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeScript : MonoBehaviour, IEndDragHandler {

    public AudioSource music;
    public Slider volume;
    float volumeValue = 1;

    public void OnEndDrag(PointerEventData eventData)
    {
        music.volume = volume.value;
        volumeValue = volume.value;
    }
}
    