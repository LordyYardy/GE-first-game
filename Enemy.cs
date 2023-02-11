using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Hurt");
        animator.SetTrigger("Hit"); // Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("isDead", true); // Die animation

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
        this.enabled = false; // Disable the enemy
    }
}
