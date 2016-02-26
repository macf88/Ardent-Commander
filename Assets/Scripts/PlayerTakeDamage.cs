using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTakeDamage : MonoBehaviour {

	public int health = 300;
    public Slider healthSlider;
    public Slider shieldSlider;

	Rigidbody rigidBody;
    Shield shield;
    int shieldHealth;
    // Use this for initialization
    void Start()
    {
        shield = gameObject.GetComponentInChildren<Shield>();
        rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
        TakeDamage(0);
        if (health <= 0) 
		{
			rigidBody.constraints = RigidbodyConstraints.None;
		}

	}
	void TakeDamage(int damage)
	{
        if (shield.shieldActive == true)
        {
            shieldHealth = shield.ShieldTakeDamage(damage, true);
        }
        else
        {
            print("Player took damage!");
            health = health - damage;
            print(health);
        }
        healthSlider.value = health;
        shieldSlider.value = shieldHealth;
    }
}
