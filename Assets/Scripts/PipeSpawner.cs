using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField]
        private PipePool pipePool;
        [SerializeField]
        private Transform spawnPoint;

        [Space, SerializeField, Range(-1, 1)]
        private float minHeight;
        [SerializeField, Range(-1, 1)]
        private float maxHeight;

        [Space, SerializeField]
        private float timeToSpawnFirstPipe;
        [SerializeField]
        private float timeToSpawnPipe;
        
        [SerializeField]
        private Pipe pipePrefab;

        [SerializeField] 
        private GameObject background;
        [SerializeField] 
        private Sprite backgroundDay, backgroundNight;
        [Header("Seleccionar la hora a la cual quiere que se active el modo noche. Formato 00 - 23h")] [Tooltip("Solo se debe escribir la hora.")] [SerializeField]
        int startDarkModeAt = 18;

        private void Awake()
        {
            DateTime actualTime = DateTime.Now;
            int hora = actualTime.Hour;
            
            
            
            if (hora >= startDarkModeAt)
            {
                pipePrefab.darkMode = true;
                background.GetComponent<SpriteRenderer>().sprite = backgroundNight;
            }
            else
            {
                pipePrefab.darkMode = false;
                background.GetComponent<SpriteRenderer>().sprite = backgroundDay;
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnPipes());
            
            
        }

        private Vector3 GetSpawnPosition()
        {
            return new Vector3(spawnPoint.position.x, Random.Range(minHeight, maxHeight), spawnPoint.position.z);
        }

        private IEnumerator SpawnPipes()
        {
            yield return new WaitForSeconds(timeToSpawnFirstPipe);

            while (true)
            {
                GameObject newPipe = pipePool.GetPooledPipe();

                if (newPipe != null)
                {
                    newPipe.transform.position = GetSpawnPosition();
                    newPipe.SetActive(true);
                }

                yield return new WaitForSeconds(timeToSpawnPipe);
            }
        }

        public void Stop()
        {
            StopAllCoroutines();
        }
    }
}