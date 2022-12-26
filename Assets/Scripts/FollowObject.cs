using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public float xTrailDistance;
    public float yTrailDistance;
    public float zTrailDistance;
    public Transform objectToFollow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow != null)
            GetComponent<Transform>().position = new Vector3(objectToFollow.position.x - xTrailDistance, objectToFollow.position.y - yTrailDistance, objectToFollow.position.z - zTrailDistance);
    }
}
