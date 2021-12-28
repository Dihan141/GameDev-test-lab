using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float startTime = 3f;
    public float rate = 2f;
    public List<GameObject> zombies = new List<GameObject>();
    public bool maxZombieSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!maxZombieSpawned)
        {
            InvokeRepeating("SpawnZombie", 3f, 2f);
        }
    }

    public void SpawnZombie()
    {
        int count = 0;
        if(zombies.Count > 2)
        {
            maxZombieSpawned = true;
        }
        else
        {
            GameObject zombie = Instantiate(zombiePrefab, transform.position, transform.rotation);
            zombies.Add(zombie);
        }
        for(int i = 0; i < zombies.Count; i++)
        {
            if(zombies[i] == null)
            {
                count++;
            }
        }
        if(count == 3)
        {
            maxZombieSpawned=false;
            zombies.Clear();
        }
    }
}
