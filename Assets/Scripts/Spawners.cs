using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Spawners : MonoBehaviour
    {
        public GameObject[] prefabs;

        public void Spawn()
        {
            Debug.Log("Try Spawn!");

            var prefab = GetRandomPrefab();
            if (prefab == null)
            {
                Debug.LogError("Spawner - prefab == null");
                return;
            }

            Instantiate(prefab, transform.position, Quaternion.identity);
        }

        private GameObject GetRandomPrefab()
        {
            if (prefabs.Length == 0)
            {
                Debug.LogError("Spawner - prefab is empty");
                return null;
            }

            int index = Random.Range(0, prefabs.Length);
            return prefabs[index];
        }
    }
}