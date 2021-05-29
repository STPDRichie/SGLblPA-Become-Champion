using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PlayerNS
{
	public class Player : MonoBehaviour
	{
        public Animator animator;  

		[HideInInspector]
		public List<string> PhrasesList;

		public int maxHealth = 100;
		public int currentHealth = 100;

		public HealthBar healthBar;

        public static bool isPlayerAlive = true;

        void Start()
        {
            currentHealth = PlayerPrefs.GetInt("CurrentPlayerHealth");
            healthBar.SetHealth(currentHealth);

            var phrasesString = PlayerPrefs.GetString("PlayerPhrasesString");
            PhrasesList = phrasesString.Split(';').Where(x => x != "").ToList();
        }

		public void TakeDamage(int damage)
		{
			currentHealth -= damage;
            PlayerPrefs.SetInt("CurrentPlayerHealth", currentHealth);

            animator.SetTrigger("Hurt");

			healthBar.SetHealth(currentHealth);

			if (currentHealth <= 0) 
			{
				Die();
                return;
			}
            
			FindObjectOfType<AudioManager>().Play("Player Hurt");
		}

        void Die() 
        {
            // animator.SetBool("IsDead", true);
            isPlayerAlive = false;
            
			FindObjectOfType<AudioManager>().Play("Player Death");
        }
	}
}