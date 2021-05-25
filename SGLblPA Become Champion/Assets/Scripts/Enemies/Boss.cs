using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public string bossDungeon;

    public SpriteRenderer spriteRenderer;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();

        StartCoroutine(AfterDeathAnimation());

        CloseDoor();
    }

    private IEnumerator AfterDeathAnimation()
    {
        yield return new WaitForSeconds(2);
        spriteRenderer.sortingOrder = 5;
        GetComponent<TogglingGameObject>().Toggle(false);
    }

    public void CloseDoor()
    {
        if (bossDungeon == "RH") HubDungeonDoors.isRHClosed = true;

        if (bossDungeon == "CF") HubDungeonDoors.isCFClosed = true;

        if (bossDungeon == "DC") HubDungeonDoors.isDCClosed = true;

        if (bossDungeon == "AH") HubDungeonDoors.isAHClosed = true;
    }
}
