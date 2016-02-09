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
                if (allPlayerAllies.Length == 1)
                {
                    Debug.Log("One ally");
                    closestPlayerAlly = ally;
                }
                else
                {
                    float dist = Vector3.Distance(ally.transform.position, transform.position);
                    if (dist < closestAllyDistance)
                    {
                        Debug.Log("New closest ally");
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
