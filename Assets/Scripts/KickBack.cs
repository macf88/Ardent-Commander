using UnityEngine;
using System.Collections;

public class KickBack : MonoBehaviour {
    Animator rifleAnim;

    // Use this for initialization
    void Start () {
        rifleAnim = GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
    }
    public void KickAnimation()
    {
        rifleAnim.SetTrigger("Fire");
    }
    public void ReloadAnimation()
    {
        rifleAnim.SetTrigger("Reload");
    }
}
