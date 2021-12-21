using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaugeHealth : MonoBehaviour
{
    public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
        Debug.Log("Dead");
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}