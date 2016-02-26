using UnityEngine;
using System.Collections;

public class FriendlyMove : MonoBehaviour {
    public int stoppingDistance = 10;

    GameObject[] allEnemies;
    GameObject closestEnemy;
    float closestEnemyDistance = 1000;
    NavMeshAgent mesh;
    bool alreadySet;

    // Use this for initialization
    void Start()
    {

        mesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length > 0)
        {
            foreach (GameObject enemy in allEnemies)
            {
                if (allEnemies.Length == 1)
                {
                    closestEnemy = enemy;
                }
                else
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);
                    if (dist < closestEnemyDistance)
                    {
                        closestEnemy = enemy;
                        closestEnemyDistance = dist;
                    }
                }
            }
        }
        if (closestEnemy != null)
        {
            if (Vector3.Distance(transform.position, closestEnemy.transform.position) <= stoppingDistance)
            {
                mesh.enabled = false;
            }
            else {
                mesh.enabled = true;
                mesh.SetDestination(closestEnemy.transform.position);
            }
        }
        else
        {
            mesh.enabled = false;
        }
    }
}