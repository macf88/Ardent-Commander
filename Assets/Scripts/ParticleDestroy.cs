using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
    float timer;
    float timeTillDestruct = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeTillDestruct)
        {
            Destroy(gameObject);
        }
	}
}
