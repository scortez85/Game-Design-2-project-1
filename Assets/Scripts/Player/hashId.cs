using UnityEngine;
using System.Collections;

public class hashId : MonoBehaviour {

    public int speed,jump,shoot,death;
    void Start()
    {
        speed = Animator.StringToHash("speed");
        jump = Animator.StringToHash("jump");
        shoot = Animator.StringToHash("shoot");
        death = Animator.StringToHash("death");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
