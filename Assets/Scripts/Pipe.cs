using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float timeToDestroyPipe;

        private void Start()
        {
            StartCoroutine(DestroyPipe());
        }

        private void Update()
        {
            if (GameManager.Instance.isGameOver)
                return;

            transform.position += (Vector3.left * Time.deltaTime * speed);
        }

        private IEnumerator DestroyPipe()
        {
            yield return new WaitForSeconds(timeToDestroyPipe);

            Destroy(gameObject);
        }
    }
}