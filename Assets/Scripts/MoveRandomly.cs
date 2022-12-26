using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if((rb.velocity.x == 0f) && (rb.velocity.z == 0f)) rb.AddForce(NewMoveVector() * speed, ForceMode.Acceleration);
    }

    Vector3 NewMoveVector()
    {
        Vector3 moveVector = new Vector3(0f, 0f, 0f);
        int randNum = Random.Range(1, 9);
        switch(randNum){
            case 1:
                moveVector = new Vector3(1f, 0f, 1f);
                break;
            case 2:
                moveVector = new Vector3(1f, 0f, 1f);
                break;
            case 3:
                moveVector = new Vector3(0f, 0f, 1f);
                break;
            case 4:
                moveVector = new Vector3(-1f, 0f, 1f);
                break;
            case 5:
                moveVector = new Vector3(-1f, 0f, 0f);
                break;
            case 6:
                moveVector = new Vector3(-1f, 0f, -1f);
                break;
            case 7:
                 moveVector = new Vector3(0f, 0f, -1f);
                break;
            case 8:
                moveVector = new Vector3(1f, 0f, -1f);
                break;
        }
        return moveVector.normalized;
    }
}
