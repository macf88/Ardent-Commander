using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health = 100;
	public GameObject deathParticles;
    bool AlreadySent;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) 
		{
			Instantiate (deathParticles, transform.position, transform.rotation);
            if (AlreadySent == true)
            {
                SendDeathInfo();
                AlreadySent = true;
            }
            
			Destroy (gameObject);
		}
	}
	void TakeDamage(int damage)
	{
		health = health - damage;
		print (health);
	}
    void SendDeathInfo()
    {
        foreach (GameObject Friendly in GameObject.FindGameObjectsWithTag("Friendly"))
        {
            Friendly.GetComponent<FriendlyShoot>().CheckForClosestEnemy();
        }
    }
}
