using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public float range = 100f;
    public GameObject rocket;

    Transform cam;
    RaycastHit hit;
    GameObject[] currentRockets;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
	}
    void Fire()
    {
        cam = Camera.main.transform;
        Ray ray = new Ray(cam.position, cam.forward);
        ray.origin = cam.transform.position;
        ray.direction = cam.transform.forward;
        if (Physics.Raycast(ray, out hit, range))
        {
            Instantiate(rocket, transform.position, transform.rotation);
            currentRockets = GameObject.FindGameObjectsWithTag("Rocket");
            foreach (GameObject _rocket in currentRockets)
            {
                _rocket.GetComponent<Rocket>().startMoving = true;
                _rocket.GetComponent<Rocket>().targetPos = hit.point;
            }
        }
        Reload();
    }
    void Reload()
    {

    }
}
