using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().shieldsCollected += 1;
            Destroy(this.gameObject);
            Debug.Log("Player Shields: " + FindObjectOfType<PlayerStats>().shieldsCollected.ToString());



        }
    }
}