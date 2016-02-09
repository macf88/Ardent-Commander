using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{

	public int damageInflicted = 10;
	public float timeBetweenBullets = 0.25f;        // The time between each shot.
    public float timeBetweenBulletsMin = 1f;
    public float timeBetweenBulletsMax = 2f;
    public float range = 100f;                      // The distance the gun can fire.
	public GameObject hitPoint;
    public string target;


    GameObject [] AllPlayerAllies;
    GameObject closestPlayerAlly;
    float closestAllyDistance = 1000;
    float distance;
	float timer;                                    // A timer to determine when to fire.     
	LineRenderer gunLine;                           // Reference to the line renderer.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

	// Use this for initialization
	void Start ()
    {
        gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
        AllPlayerAllies = GameObject.FindGameObjectsWithTag("Friendly");
        if (AllPlayerAllies.Length > 0)
        {
            foreach (GameObject Ally in AllPlayerAllies)
            {
                if (closestPlayerAlly == null)
                {
                    closestAllyDistance = 1000;
                }
                if (AllPlayerAllies.Length == 1)
                {
                    closestPlayerAlly = Ally;
                }
                else
                {
                    float dist = Vector3.Distance(Ally.transform.position, transform.position);
                    if (dist < closestAllyDistance && dist < 100f)
                    {
                        closestPlayerAlly = Ally;
                        closestAllyDistance = dist;
                    }
                }
            }
        }
        timeBetweenBullets = Random.Range(timeBetweenBulletsMin, timeBetweenBulletsMax);
        timer += Time.deltaTime;
        Debug.Log(closestPlayerAlly);

        if (timer >= timeBetweenBullets && closestPlayerAlly != null)
        {
            Fire();
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }
	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
	}
	void Fire ()
	{
		// Reset the timer.
		timer = 0f;

        distance = Vector3.Distance(hitPoint.transform.position, transform.position);
        hitPoint.GetComponent<HitPoint>().ChangePos(distance/25, closestPlayerAlly);

		// Play the gun shot audioclip.
		gunAudio.Play ();

		// Enable the light.
		gunLight.enabled = true;

		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Linecast(transform.position, hitPoint.transform.position, out hit))
        {
            gunLine.SetPosition(1, hit.point);

            if (hit.transform.position == Vector3.zero) {
                Debug.Log("Shooting at: " + hit.transform.position); 
            }

            if (hit.transform.tag == "Friendly")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", damageInflicted, SendMessageOptions.DontRequireReceiver);
            }
            print(hit.transform.name);
        }
    }
}
