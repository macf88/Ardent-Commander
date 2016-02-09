using UnityEngine;
using System.Collections;

public class HeadShot : MonoBehaviour {

    Enemy enemyScript;

	// Use this for initialization
	void Start () {
        enemyScript = GetComponentInParent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void TakeDamage(int damage)
    {
        enemyScript.health = enemyScript.health - (damage * 3);
    }
}
