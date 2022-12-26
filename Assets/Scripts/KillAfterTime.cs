using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    public float killDelay;
    private void Awake() {
        Invoke("KillObject", killDelay);
    }

    void KillObject()
    {
        Destroy(gameObject);
    }
}
