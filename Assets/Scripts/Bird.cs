using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Bird : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidbody2D;
        [SerializeField, Range(0, 10)]
        private float speed;
        [SerializeField]
        private List<RuntimeAnimatorController> birdAnimatorControllers;

        private void Awake()
        {
            if (rigidbody2D == null)
                rigidbody2D = GetComponent<Rigidbody2D>();
            
            if (birdAnimatorControllers.Count > 0)
            {
                int randomIndex = Random.Range(0, birdAnimatorControllers.Count);
                RuntimeAnimatorController selectedController = birdAnimatorControllers[randomIndex];
                
                Animator animator = GetComponent<Animator>();
                if (animator != null)
                {
                    animator.runtimeAnimatorController = selectedController;
                }
            }
        }
        
        private void Update()
        {
            if (GameManager.Instance.isGameOver)
                return;

#if UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                Move();
#endif

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
                Move();
#endif
        }

        private void Move()
        {
            if (rigidbody2D != null)
                rigidbody2D.velocity = Vector2.up * speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Pipe"))
                GameManager.Instance.GameOver();
            else if (collision.gameObject.CompareTag("Ground"))
                GameManager.Instance.GameOver();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PipeTrigger"))
                GameManager.Instance.IncreaseScore();
        }
    }
}