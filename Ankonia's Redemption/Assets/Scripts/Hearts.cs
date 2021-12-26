using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Taken", true);
            FindObjectOfType<PlayerStats>().heartsCollected += 1;
            //  FindObjectOfType<Player>().heartsCounter += 1;
            Destroy(this.gameObject);
            if (FindObjectOfType<PlayerStats>().health <= 0 || FindObjectOfType<PlayerStats>().health < 10)
                FindObjectOfType<PlayerStats>().health = 10;
            Debug.Log("Player Hearts: " + FindObjectOfType<PlayerStats>().heartsCollected.ToString());
            Debug.Log("Player Health: " + FindObjectOfType<PlayerStats>().health.ToString());

        }
            
    }
}
