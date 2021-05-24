using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerNS;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    
    private int attackDamage = 5;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }
    }

    public virtual void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        // Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public virtual void Die() 
    {
        Debug.Log("Enemy Died");

        // Die Animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
    }
}
