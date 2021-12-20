using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 6;
    public int lives = 3;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
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
        if(this.isImmune == true)
        {
            SpritFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime>= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
        
    }
    void SpritFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
            this.flickerTime = this.flickerTime + Time.deltaTime;
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        if(this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if(this.lives >= 0 && this.health == 0)
            {
                FindObjectOfType<levelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if(this.lives == 0)
            {
                Die();

            }

            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        }
        PlayerHitReaction();
    }

   void PlayerHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    void Die()
    {
        Debug.Log("GAME OVER");
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this.gameObject,2f);

    }
}
