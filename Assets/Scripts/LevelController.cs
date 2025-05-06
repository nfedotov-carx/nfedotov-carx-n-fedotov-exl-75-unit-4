using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delay = 0.5f;
        public bool isGameOver = false;

        private IEnumerator StartStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);
                spawner.Spawn();
            }
            while (!isGameOver);
        }

        public void Start()
        {
            StartCoroutine(StartStoneProc());
        }

        /*
        public SpawnerStone spawner;
        public float delay = 0.5f;
        private float m_lastSpawnerTime = 0;

        public float delayMax = 2f;
        public float delayMin = 0f;
        public float delayStep = 0.1f;

        public int score = 0;

        private float m_delay = 0.5f;

        private List<GameObject> m_stones = new List<GameObject>(16);


        public void Start()
        {
            //StartCoroutine(SpawnStone());
            m_lastSpawnerTime = Time.time;
            RefreshDelay();
        }


        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
        }

        private void OnDisable()
        {
            Stone.onCollisionStone += GameOver;
        }

        private void GameOver()
        {
            Debug.Log("Game Over!!!");
            enabled = false;
        }


        private void Update()
        {
            if (Time.time >= m_lastSpawnerTime + m_delay)
            {
                spawner.Spawn();
                m_lastSpawnerTime = Time.time;

                RefreshDelay();
            }
        }
        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }
    */
    }

}