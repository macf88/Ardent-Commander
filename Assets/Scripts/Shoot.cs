using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	
	Transform cam;
	public int damageInflicted = 10;
	public float timeBetweenBullets = 0.2f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.
    public float grappleBuffer;
    public GameObject Model;
    public int ammo = 20;
    public Slider ammoDisplay;
    
    KickBack kickBack;
    bool reloading;
    Grapple grappleScript;
    RaycastHit hit;
    bool firingEffectsActive;
    bool grappleButtonHeld = false;
    bool grappleActive;
    bool Zoommed;
    Vector3 grapplePoint;
    Vector3 grapplePointBuffer;
	int shootableMask;    
    float timer;                                    // A timer to determine when to fire.     
	LineRenderer gunLine;                           // Reference to the line renderer.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

	// Use this for initialization
	void Awake () 
	{
        grappleScript = GetComponentInParent<Grapple>();
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponentInChildren <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
        kickBack = GetComponentInParent<KickBack>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        if (firingEffectsActive == true)
        {
            SetGunLinePos();
        }
        if (Input.GetKey(KeyCode.Mouse3))
        {
            grappleButtonHeld = true;
        }
        else
        {
            grappleButtonHeld = false;
        }

		if (Input.GetKey (KeyCode.Mouse0) && timer >= timeBetweenBullets && grappleButtonHeld == false && ammo > 0 && reloading == false) 
		{
			Fire ();
		}
        else if (ammo <= 0)
        {
            ReloadAnimation();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAnimation();
        }
        //else if(Input.GetKey(KeyCode.Mouse0) && grappleButtonHeld == true)
        //{
        //    grappleActive = true;
        //    grapplePoint = hit.point;
        //}

        if (grappleActive == true)
        {

            if (grappleScript.gameObject.transform.position != grapplePointBuffer && grappleScript.hitWall != true/*Mathf.Abs(transform.position.x - grapplePoint.x) >= grappleBuffer && Mathf.Abs(transform.position.y - grapplePoint.y) >= grappleBuffer && Mathf.Abs(transform.position.z - grapplePoint.z) >= grappleBuffer*/)
            {
                Debug.Log("Grappling");

                gameObject.GetComponentInParent<Rigidbody>().useGravity = false;

                cam = Camera.main.transform;
                Ray ray = new Ray(cam.position, cam.forward);
                ray.origin = cam.transform.position;
                ray.direction = cam.transform.forward;   
                if (Physics.Raycast(ray, out hit, range))
                {
                    
                }
                grapplePointBuffer = new Vector3(grapplePoint.x, grapplePoint.y + 1f, grapplePoint.z);
                grappleScript.Grappling(grapplePointBuffer);
            }
            else
            {
                grappleScript.hitWall = false;
                grappleScript.EndGrapple();
                gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
                grappleActive = false;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            timeBetweenBullets = 1f;
            damageInflicted = 30;
            gunAudio.pitch = .35f;
            Zoommed = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            timeBetweenBullets = .15f;
            damageInflicted = 10;
            gunAudio.pitch = .95f;
            Zoommed = false;
        }

		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects ();
		}
	}

	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
        firingEffectsActive = false;

	}

	void Fire ()
	{

		// Reset the timer.
		timer = 0f;

        kickBack.KickAnimation();

		// Play the gun shot audioclip.
		gunAudio.Play ();

		// Enable the light.
		gunLight.enabled = true;

		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;

        firingEffectsActive = true;

        gunLine.SetPosition(0, transform.position);
        cam = Camera.main.transform;
		Ray ray = new Ray(cam.position, cam.forward);
		ray.origin = cam.transform.position;
		ray.direction = cam.transform.forward;
		if(Physics.Raycast (ray, out hit, range, shootableMask))
		{
			gunLine.SetPosition (1, hit.point);
			if (hit.transform.tag == "Enemy") 
			{
				hit.collider.SendMessage ("TakeDamage", damageInflicted, SendMessageOptions.DontRequireReceiver);
			}

			print (hit.transform.name);
		}
		else 
		{
			gunLine.SetPosition (1, ray.origin + ray.direction * range);
		}
        if (Zoommed == true)
        {
            ammo -= 4;
        }
        else
        {
        ammo--;
        }
        ammoDisplay.value = ammo;
	}
    
    void SetGunLinePos()
    {
        gunLine.SetPosition(0, transform.position);
    }
    void ReloadAnimation()
    {
        if (reloading == false)
        {
            kickBack.ReloadAnimation();
            StartCoroutine(Reload());
            reloading = true;
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.35f);
        ammo = 20;
        ammoDisplay.value = ammo;
        reloading = false;
    }
}
