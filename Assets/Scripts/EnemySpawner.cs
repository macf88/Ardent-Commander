using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 2;

    int randomEnemy;
    float timer = 2.5f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        timer = 0f;
        randomEnemy = Random.Range(0, 10);
        switch (randomEnemy)
        {
            case 1:
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                break;
            case 2:
            case 3:
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                break;
            case 4:
            case 5:
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                break;
            case 6:
            case 7:
                Instantiate(enemy, transform.position, transform.rotation);
                Instantiate(enemy, transform.position, transform.rotation);
                break;
            case 8:
            case 9:
            case 10:
                Instantiate(enemy, transform.position, transform.rotation);
                break;
        }
    }
}
