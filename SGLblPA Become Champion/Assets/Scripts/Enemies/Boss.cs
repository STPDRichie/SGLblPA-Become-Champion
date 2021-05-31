using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public string bossDungeon;

    public SpriteRenderer spriteRenderer;

    public BossHealthBar healthBar;
    public GameObject healthBarObject;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
		FindObjectOfType<AudioManager>().Play("Boss Start");
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

		FindObjectOfType<AudioManager>().Play("Boss Hurt");
        animator.SetTrigger("Hurt");
        
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();

        FindObjectOfType<AudioManager>().Play("Boss Death");

        StartCoroutine(AfterDeathAnimation());

        CloseDoor();
    }

    private IEnumerator AfterDeathAnimation()
    {
        yield return new WaitForSeconds(2);

        spriteRenderer.sortingOrder = 5;

        GetComponent<TogglingGameObject>().Toggle(false);
        healthBarObject.SetActive(false);
    }

    public void CloseDoor()
    {
        if (bossDungeon == "RH") HubDungeonDoors.isRHClosed = true;

        if (bossDungeon == "CF") HubDungeonDoors.isCFClosed = true;

        if (bossDungeon == "DC") HubDungeonDoors.isDCClosed = true;

        if (bossDungeon == "AH") HubDungeonDoors.isAHClosed = true;
    }
}
