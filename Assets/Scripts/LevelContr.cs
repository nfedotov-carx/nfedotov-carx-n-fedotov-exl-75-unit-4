using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class LevelContr : MonoBehaviour
    {
        public Spawners spawner;
        public float delay = 0.5f;
        public bool isGameOver = false;

        private List<GameObject> m_stones = new List<GameObject>(16);

        public void Start()
        {
            StartCoroutine(SpawnStone());
        }

        IEnumerator SpawnStone()
        {
            do 
            {
                yield return new WaitForSeconds(delay);
                spawner.Spawn();
            }
            while (!isGameOver);
        }
    }
}