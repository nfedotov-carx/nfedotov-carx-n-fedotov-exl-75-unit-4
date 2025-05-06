using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        //public float delay = 0.5f;
        private float m_lastSpawnerTime = 0;

        public float delayMax = 2f;
        public float delayMin = 0f;
        public float delayStep = 0.1f;

        public int score = 0;
        public int highScore = 0;

        private float m_delay = 0.5f;

        private List<GameObject> m_stones = new List<GameObject>(16);

        private void OnStickHit()
        {
            score++;
            highScore = Mathf.Max(highScore, score);

            Debug.Log($"score: {score} - hightScore: {highScore}");
        }

        public void Start()
        {
            m_lastSpawnerTime = Time.time;
            RefreshDelay();
        }


        private void OnEnable()
        {
            GameEvents.onCollisionStones += GameOver;
            GameEvents.onStickHit += GameOver;
        }

        private void OnDisable()
        {
            GameEvents.onCollisionStones -= GameOver;
            GameEvents.onStickHit -= GameOver;
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
    }
}