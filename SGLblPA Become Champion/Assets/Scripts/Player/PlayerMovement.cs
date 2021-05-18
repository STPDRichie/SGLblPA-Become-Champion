using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerNS
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 6f;
        public Rigidbody2D rb;
        public Animator animator;

        private Vector2 moveDirection;

        void Update()
        {
            ProcessInputs();
        }

        void FixedUpdate()
        {
            Move();
        }

        void ProcessInputs()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;

            animator.SetFloat("Horizontal", moveX);
            animator.SetFloat("Vertical", moveY);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }

        void Move()
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}