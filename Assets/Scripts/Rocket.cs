using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float speed = 1000f;
    [HideInInspector] public bool startMoving;
    [HideInInspector] public Vector3 targetPos;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Firing(targetPos);
    }
    void Firing(Vector3 targetLocation)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
    }
    void OnCollisionEnter()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
