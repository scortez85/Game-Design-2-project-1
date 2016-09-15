using UnityEngine;
using System.Collections;

public class hashId : MonoBehaviour {

    public int speed,jump, isShooting, death;
    void Start()
    {
        speed = Animator.StringToHash("speed");
        jump = Animator.StringToHash("jump");
        isShooting = Animator.StringToHash("isShooting");
        death = Animator.StringToHash("death");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
