using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerNS;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;
    
    public int attackDamage = 5;
    
    private float attackRate = 1f;
    private float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        float moveX = GetComponent<EnemyAI>().moveDirection.x;
        float moveY = GetComponent<EnemyAI>().moveDirection.y;
        
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            if (Time.time >= nextAttackTime)
            {
		        FindObjectOfType<AudioManager>().Play("Enemy Attack");
                player.TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public virtual void TakeDamage(int damage) 
    {
        currentHealth -= damage;

		FindObjectOfType<AudioManager>().Play("Enemy Hurt");
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public virtual void Die() 
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }
}
