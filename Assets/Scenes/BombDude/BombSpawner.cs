using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject BombPrefab;
    public GameObject SpawnerParrent;
    public GameObject Heart;
    private int randomSpawn;
    private float timer;
    public float RateOfFire;
    [SerializeField]
    private bool canSpawn;

    
    // Start is called before the first frame update
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && RateOfFire > 0 && canSpawn)
        {
            var pos = SpawnerParrent.transform.position;
            var rot = transform.rotation;
            randomSpawn = Random.Range(0, 10);
            if(randomSpawn == 1)
            {
                var heart = Instantiate(Heart, pos, rot);
                heart.transform.position = pos;
            }
            else
            {
                var Bomb = Instantiate(BombPrefab, pos, rot);
                Bomb.transform.position = pos;
            }
            
            
            timer = RateOfFire;
        }
    }
}
