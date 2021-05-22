using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerNS
{
    public class PlayerCombatSystem : MonoBehaviour
    {
        public Animator animator;

        public Transform attackPoint;
        public LayerMask enemyLayers;

        private float attackRange = 2.5f;
        public int attackDamage = 20;

        private float attackRate = 1f;
        private float nextAttackTime = 0f;

        void Start()
        {
            attackDamage = PlayerPrefs.GetInt("CurrentPlayerDamage");
        }

        void Update()
        {
            if (GetComponent<Player>().PhrasesList.Count != 0)
                if (Time.time >= nextAttackTime)
                    if (Input.GetKeyDown(KeyCode.Space)) 
                    {
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
        }

        void Attack()
        {
            // Play an attack amination
            animator.SetTrigger("Attack");
            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 
                attackRange, enemyLayers);

            // Damage enemies
            foreach (Collider2D enemy in hitEnemies) 
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

        void OnDrawGizmosSelected() 
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}