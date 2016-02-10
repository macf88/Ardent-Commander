using UnityEngine;
using System.Collections;

public class FriendlySpawner : MonoBehaviour {

    public GameObject friendly;
    public float spawnTime = 20;

    int randomFriendly;
    float timer = 2.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        timer = 0f;
        randomFriendly = Random.Range(0, 10);
        switch (randomFriendly)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Instantiate(friendly, transform.position, transform.rotation);
                Instantiate(friendly, transform.position, transform.rotation);
                break;
            case 6:
            case 7:                
            case 8:
            case 9:
            case 10:
                Instantiate(friendly, transform.position, transform.rotation);
                break;
        }
    }
}