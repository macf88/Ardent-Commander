using UnityEngine;
using System.Collections;

public class HitPoint : MonoBehaviour
{
    public float badGuyAim;

    Vector3 playerBuffer;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangePos(float distanceError, GameObject target)
    {
        playerBuffer = new Vector3(Random.Range(target.transform.position.x + (badGuyAim * distanceError), target.transform.position.x - (badGuyAim * distanceError)),
            Random.Range(target.transform.position.y + (badGuyAim * distanceError), target.transform.position.y - (badGuyAim * distanceError)),
            Random.Range(target.transform.position.z + (badGuyAim * distanceError), target.transform.position.z - (badGuyAim * distanceError)));
        transform.position = playerBuffer;
    }
}