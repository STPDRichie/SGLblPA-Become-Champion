using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public SpriteRenderer spriteRenderer;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();

        spriteRenderer.sortingOrder = 5;

        GetComponent<TogglingGameObject>().Toggle(false);
    }
}
