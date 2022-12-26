using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)) FindObjectOfType<InGameUI>().ShowPauseScreen(); 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "DeadlyToPlayer"){
            KillPlayer();
        }
        if(other.collider.tag == "VictoryBlock"){
            FindObjectOfType<InGameUI>().ShowVictoryScreen();
            Destroy(gameObject);
        } 
    }

    private void KillPlayer()
    {
        Instantiate(deathParticles, GetComponent<Transform>().position, Quaternion.identity);
        FindObjectOfType<InGameUI>().ShowDeathScreen();
        Destroy(gameObject);
    }
}
