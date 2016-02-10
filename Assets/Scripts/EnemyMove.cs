using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public int stoppingDistance = 10;

    GameObject[] allPlayerAllies;
    GameObject closestPlayerAlly;
    float closestAllyDistance = 1000;
    NavMeshAgent mesh;

	// Use this for initialization
	void Start () {

        mesh = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        allPlayerAllies = GameObject.FindGameObjectsWithTag("Friendly");
        if (allPlayerAllies.Length > 0)
        {
            foreach (GameObject ally in allPlayerAllies)
            {
                if (closestPlayerAlly == null)
                {
                    closestAllyDistance = 1000;
                }
                if (allPlayerAllies.Length == 1)
                {
                    closestPlayerAlly = ally;
                }
                else
                {
                    float dist = Vector3.Distance(ally.transform.position, transform.position);
                    if (dist < closestAllyDistance)
                    {
                        closestPlayerAlly = ally;
                        closestAllyDistance = dist;
                    }
                }
            }
        }
        Debug.Log(closestPlayerAlly);
        if (closestPlayerAlly != null)
        {
            if (Vector3.Distance(transform.position, closestPlayerAlly.transform.position) <= stoppingDistance)
            {
                mesh.SetDestination(transform.position);
            }
            else {
                mesh.SetDestination(closestPlayerAlly.transform.position);
            }
        }
	}
}
