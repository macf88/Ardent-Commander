using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RocketExplosion : MonoBehaviour {
    public float radius = 10.0F;
    public float power = 100.0F;
    public float maxDamage = 10f;
    public GameObject explosionParticles;

    Collider[] colliders;
    List<Collider> collidersList = new List<Collider>();

    float deathTimer;
    void Start()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        Vector3 explosionPos = transform.position;
        colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.attachedRigidbody;

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);

            // Find the TankHealth script associated with the rigidbody.
            Enemy targetHealth = hit.gameObject.GetComponent<Enemy>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;

            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damageTaken = CalculateDamage(rb.position);

            int damageInt = (int)Math.Round(damageTaken, 0);
            // Deal this damage to the tank.
            targetHealth.TakeDamage(damageInt);

        }
    }
    
    private float CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (radius - explosionDistance) / radius;

        // Calculate damage as this proportion of the maximum possible damage.
        float classDamage = relativeDistance * maxDamage;
        print("Damage = " + classDamage);

        // Make sure that the minimum damage is always 0.
        classDamage = Mathf.Max(0f, classDamage);

        return classDamage;
    }

    // Update is called once per frame
    void Update () {
        deathTimer++;
        foreach (Collider hit in colliders)
        {
            if (hit != null)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb)
                {
                    if ((rb.position - transform.position).magnitude > (radius / 1.25))
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                        collidersList = colliders.ToList();
                        collidersList.Remove(hit);
                        colliders = collidersList.ToArray();
                    }
                }
            }
        }
        if (deathTimer > 200)
        {
            Destroy(gameObject);
        }
	}
}
