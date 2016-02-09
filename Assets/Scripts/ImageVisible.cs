using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageVisible : MonoBehaviour {
	public Color visible;
	public Color notVisible;

	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse1)) {
			image.color = visible;
		} else {
			image.color = notVisible;
		}
	}
}
