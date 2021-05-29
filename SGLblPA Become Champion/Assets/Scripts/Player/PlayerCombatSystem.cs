using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerNS
{
    public class PlayerCombatSystem : MonoBehaviour
    {
        public Animator animator;

        public Text phraseForm;

        public Transform attackPoint;
        public LayerMask enemyLayers;

        private float attackRange = 2.5f;
        public int attackDamage = 20;

        private float attackRate = 1f;
        private float nextAttackTime = 0f;

        void Start()
        {
            attackDamage = PlayerPrefs.GetInt("CurrentPlayerDamage");
            phraseForm.text = "";
        }

        void Update()
        {
            if (GetComponent<Player>().PhrasesList.Count != 0)
                if (Time.time >= nextAttackTime)
                    if (Input.GetKeyDown(KeyCode.Space)) 
                    {
		                FindObjectOfType<AudioManager>().Play("Player Attack");
                        Attack();
                        StartCoroutine(Scream());
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
        }

        void Attack()
        {
            animator.SetTrigger("Attack");
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 
                attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        private IEnumerator Scream()
        {
            phraseForm.text = GetComponent<Player>().PhrasesList 
                [Random.Range(0, GetComponent<Player>().PhrasesList.Count)];

            yield return new WaitForSeconds(0.5f);

            phraseForm.text = "";
        }

        void OnDrawGizmosSelected() 
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}