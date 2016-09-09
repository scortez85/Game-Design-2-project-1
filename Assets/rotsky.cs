using UnityEngine;
using System.Collections;

public class rotsky : MonoBehaviour {

	//speed value for moving the skybox
	public float speed;
	//sky color change
	public Renderer skyshade;
	void Start () {
	//this is for sky color
		skyshade = GetComponent<Renderer> ();
		//skyshade.material.shader
	}
	
	// Update is called once per frame
	void Update () {
		//move that sky
		transform.Rotate (0, speed * Time.deltaTime, 0);
	
	}
}
