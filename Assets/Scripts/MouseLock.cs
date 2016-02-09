using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {


	void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	void DidLockCursor() {
		Debug.Log("Locking cursor");

	}
	void DidUnlockCursor() {
		Debug.Log("Unlocking cursor");

	}
	void OnMouseDown() {
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	private bool wasLocked = false;
	void Update() {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

		if (!Cursor.visible && wasLocked) {
			wasLocked = false;
			DidUnlockCursor();
		} else
			if (Cursor.visible && !wasLocked) {
				wasLocked = true;
				DidLockCursor();
			}
	}
}
