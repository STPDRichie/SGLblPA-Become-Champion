using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerNS
{
	public class Player : MonoBehaviour
	{
		//[HideInInspector]
		public List<string> PhrasesList;

		public int maxHealth = 100;
		private int currentHealth;

		public HealthBar healthBar;

			void Start()
			{
			currentHealth = maxHealth;
			healthBar.SetMaxHealth(maxHealth);
			}

			void Update()
			{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				TakeDamage(20);
			}
			}

		void TakeDamage(int damage)
		{
			currentHealth -= damage;

			healthBar.SetHealth(currentHealth);
		}
	}
}