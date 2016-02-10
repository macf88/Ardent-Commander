using UnityEngine;
using System.Collections;

public class FriendlyShoot : MonoBehaviour {

    public int damageInflicted = 10;
    public float timeBetweenBullets = 0.25f;        // The time between each shot.
    public float timeBetweenBulletsMin = 1f;
    public float timeBetweenBulletsMax = 2f;
    public float range = 100f;                      // The distance the gun can fire.
    public GameObject hitPoint;

    float distance;
    float timer;                                    // A timer to determine when to fire.     
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

    GameObject [] AllEnemies;
    GameObject closestEnemy;
    float closestEnemyDistance = 1000f;
	// Use this for initialization
	void Start () {
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (closestEnemy != null)
        {
            if (closestEnemy.GetComponent<Enemy>().health >= 0)
            {
                closestEnemy = null;
            }
        }
        
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (AllEnemies.Length > 0)
        {
        foreach (GameObject Enemy in AllEnemies)
        {
            if (AllEnemies.Length == 1)
            {
                closestEnemy = Enemy;
            }
            else
            {
                float dist = Vector3.Distance(Enemy.transform.position, transform.position);
                if (dist < closestEnemyDistance && dist < 100f)
                {
                    closestEnemy = Enemy;
                    closestEnemyDistance = dist;
                }
            }
        }
        }
        timeBetweenBullets = Random.Range(timeBetweenBulletsMin, timeBetweenBulletsMax);
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets && closestEnemy != null)
        {
            Fire();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }
    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
    void Fire()
    {
        // Reset the timer.
        timer = 0f;

        distance = Vector3.Distance(hitPoint.transform.position, transform.position);
        if (closestEnemy != null)
        {
            hitPoint.GetComponent<HitPoint>().ChangePos(distance / 20, closestEnemy);
        }

        // Play the gun shot audioclip.
        gunAudio.Play();

        // Enable the light.
        gunLight.enabled = true;

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, hitPoint.transform.position, out hit))
        {
            gunLine.SetPosition(1, hit.point);

            if (hit.transform.position == Vector3.zero)
            {
                Debug.Log("Shooting at: " + hit.transform.position);
            }

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", damageInflicted, SendMessageOptions.DontRequireReceiver);
            }
            print(hit.transform.name);
        }
    }
}
