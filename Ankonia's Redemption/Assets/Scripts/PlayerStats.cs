using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int lives;
    private SpriteRenderer spriteRenderer;
    public int heartsCollected = 0;
    public int shieldsCollected = 0;
    private Animator anim;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
      
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("Hurt", true);
        this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
        if (this.lives > 0 && this.health == 0)
            {
                //FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 10;
                this.lives--;
              }
            else if(this.lives <= 0)
            {
                Die();

            }
   
            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        
    }
 
  
    void Die()
    {
        Debug.Log("GAME OVER");
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this.gameObject,2f);
        SceneManager.LoadScene("GameOverScene");

    }
}
