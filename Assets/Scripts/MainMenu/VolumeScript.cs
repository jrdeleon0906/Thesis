using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeScript : MonoBehaviour, IEndDragHandler {

    public AudioSource music;
    public Slider volume;

    public void OnEndDrag(PointerEventData eventData)
    {
        music.volume = volume.value;
    }
}
    