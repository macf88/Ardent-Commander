using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

	Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1))
		{
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.Mouse4))
            {
                cam.fieldOfView = 5;
            }
            else
            {
                cam.fieldOfView = 30;
            }
		}else{
			cam.fieldOfView = 60;
		}
	}
}
