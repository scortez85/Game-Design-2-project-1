using UnityEngine;
using System.Collections;

public class playerHud : MonoBehaviour {

    public Texture playerHealth;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(32, 32, 226/2, 62/4), playerHealth);
    }
}
