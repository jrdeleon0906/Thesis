using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public GameObject LetterBox;

	// Use this for initialization
	void Start () {
        GameObject go = Instantiate(LetterBox, new Vector2(0, 0), Quaternion.identity) as GameObject;
        go.transform.SetParent(gameObject.transform);
        go.transform.position = new Vector3(Screen.width/2, Screen.height/10);
    }
 	
	// Update is called once per frame
	void Update () {
        
	}
}
