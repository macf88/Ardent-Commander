using UnityEngine;
using System.Collections;

public class PlayerTakeDamage : MonoBehaviour {

	public int health = 300;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) 
		{
			rigidBody.constraints = RigidbodyConstraints.None;
		}

	}
	void TakeDamage(int damage)
	{
		print ("Player took damage!");
		health = health - damage;
		print (health);
	}
}
