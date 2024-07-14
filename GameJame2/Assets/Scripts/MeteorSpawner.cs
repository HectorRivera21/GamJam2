using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField] private GameObject meteor;
    [SerializeField] private float spawnRate = 0.5f;
    private int randX = 0;
    private int randY = 0;
    private int maxRange = 20;
    private int minRange = -20;
    void Start()
    {
        //do nothing rn
        randX = Random.Range(minRange, maxRange);
        randY = Random.Range(minRange, maxRange);
        InvokeRepeating("spawn_meteor", 0.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        randX = Random.Range(minRange, maxRange);
        randY = Random.Range(minRange, maxRange);
    }

    private void spawn_meteor()
    {
           Instantiate(meteor, new Vector3(randX, randY, 0), Quaternion.identity);
    }
}
