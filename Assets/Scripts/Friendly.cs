using UnityEngine;
using System.Collections;

public class Friendly : MonoBehaviour {
    public int health;

    Shield shield;
	// Use this for initialization
	void Start () {
        shield = gameObject.GetComponentInChildren<Shield>();

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
        if (shield.shieldActive == true)
        {
            shield.ShieldTakeDamage(damage);
        }
        else {
            health = health - damage;
        }
    }
}
