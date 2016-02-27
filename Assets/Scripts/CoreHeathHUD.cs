using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoreHeathHUD : MonoBehaviour {
    public Slider healthHUDSlider;
    public Text victoryText;

    Enemy enemyScript;
    Friendly friendlyScript;
    bool isFriendlyOrEnemy;
    
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
	    
	}
	
	// Update is called once per frame
	void Update () {
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
