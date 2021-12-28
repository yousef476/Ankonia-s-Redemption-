using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guards : MonoBehaviour
{
    // Start is called before the first frame update
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private bool isFacingRight = false;
    private Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 1.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Flip")
        {
            dirX *= -1f;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
  
   
    private void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            isFacingRight = true;
        else if (dirX < 0)
            isFacingRight = false;

        if (((isFacingRight) && (localScale.x < 0)) || ((!isFacingRight) && (localScale.x > 0)))
            localScale.x *= -1;


        transform.localScale = localScale;

    }
   
   
    //void Attack()
    //{

    //}
    //void Die()
    //{
    //    Debug.Log("Guard died");
    //    anim.SetBool("isDead", true);
    //    GetComponent<Collider2D>().enabled = false;
    //    this.enabled = false;
    //    Destroy(this.gameObject, 2f);
    //    SceneManager.LoadScene("GameOverScene");
    //}
}
