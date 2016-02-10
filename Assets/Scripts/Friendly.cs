using UnityEngine;
using System.Collections;

public class Friendly : MonoBehaviour {
    public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
    void TakeDamage(int damage)
    {
        health = health - damage;
    }
}
