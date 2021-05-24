using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PlayerNS
{
	public class Player : MonoBehaviour
	{
        public Animator animator;  

		//[HideInInspector]
		public List<string> PhrasesList;

		public int maxHealth = 100;
		public int currentHealth = 100;

		public HealthBar healthBar;

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

            // Play hurt animation
            animator.SetTrigger("Hurt");

			healthBar.SetHealth(currentHealth);

			if (currentHealth <= 0) 
			{
				Die();
			}
		}

        void Die() 
        {
            Debug.Log("Player Died");

            // Die Animation
            animator.SetBool("IsDead", true);
        }
	}
}