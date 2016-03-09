using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoreHealthHUD : MonoBehaviour {
    public Slider healthHUDSlider;
    public Text victoryText;

    Enemy enemyScript;
    Friendly friendlyScript;
    bool isFriendlyOrEnemy;
    Vector3 pos;
    Quaternion rot;
    
	// Use this for initialization
	void Start () {
        if (GetComponent<Friendly>() == true)
        {
            friendlyScript = GetComponent<Friendly>();
            isFriendlyOrEnemy = true;
        }
        else if(GetComponent<Enemy>() == true)
        {
            enemyScript = GetComponent<Enemy>();
            isFriendlyOrEnemy = false;
        }
        pos = transform.position;
        rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = pos;
        transform.rotation = rot;
	    if (isFriendlyOrEnemy == true)
        {
            if (friendlyScript.health <= 0)
            {
                victoryText.text = "You Lose!";
            }
            healthHUDSlider.value = friendlyScript.health;
        }
        else if (isFriendlyOrEnemy == false)
        {
            if (enemyScript.health <= 0)
            {
                victoryText.text = "You Win";
            }
            healthHUDSlider.value = enemyScript.health;
        }
        
	}
}
