using System;
using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float timeToDeactivatePipe;
        [SerializeField]
        private Sprite pipeUpDay, pipeUpNight, pipeDownDay, pipeDownNight;

        public bool darkMode;

        private void OnEnable()
        {
            StartCoroutine(DeactivatePipe());
        }

        private void Awake()
        {
            ChangeColor();
        }

        private void Update()
        {
            if (GameManager.Instance.isGameOver)
                return;

            transform.position += (Vector3.left * Time.deltaTime * speed);
        }

        private IEnumerator DeactivatePipe()
        {
            yield return new WaitForSeconds(timeToDeactivatePipe);

            gameObject.SetActive(false);
        }
        
        private void ChangeColor()
        {

            GameObject pipeUp = GameObject.Find("PipeUp");
            GameObject pipeDown = GameObject.Find("PipeDown");
            if (darkMode == true)
            {   
                
                pipeUp.GetComponent<SpriteRenderer>().sprite = pipeUpNight;
                pipeDown.GetComponent<SpriteRenderer>().sprite = pipeDownNight;
            }
            else
            {
                
                pipeUp.GetComponent<SpriteRenderer>().sprite = pipeUpDay;
                pipeDown.GetComponent<SpriteRenderer>().sprite = pipeDownDay;
            }
            
        }

        
        
    }
}