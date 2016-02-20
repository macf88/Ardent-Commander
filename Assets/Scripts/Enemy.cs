using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health = 100;
	public GameObject deathParticles;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) 
		{
			Instantiate (deathParticles, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
	void TakeDamage(int damage)
	{
		health = health - damage;
		print (health);
	}
}
