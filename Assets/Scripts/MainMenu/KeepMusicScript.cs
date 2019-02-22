using UnityEngine;

public class KeepMusicScript : MonoBehaviour {

    private static KeepMusicScript instance = null;
    public static string Era = "";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
