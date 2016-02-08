using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour {

    public float speed = 75;
    public bool hitWall = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Grappling(Vector3 grapplePoint)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, grapplePoint, step);
        Debug.Log("Grappling");
    }
    public void EndGrapple()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {
            Debug.Log("Collided with the wall");
            hitWall = true;
        }
    }
}
