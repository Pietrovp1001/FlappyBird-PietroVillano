using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PipePool : MonoBehaviour
    {
        [SerializeField]
        private GameObject pipePrefab;
        [SerializeField]
        private int poolSize = 5;

        private List<GameObject> pipePool;

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            pipePool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject pipe = Instantiate(pipePrefab, Vector3.zero, Quaternion.identity);
                pipe.SetActive(false);
                pipePool.Add(pipe);
            }
        }

        public GameObject GetPooledPipe()
        {
            foreach (GameObject pipe in pipePool)
            {
                if (!pipe.activeInHierarchy)
                {
                    return pipe;
                }
            }

            return null;
        }
    }
}