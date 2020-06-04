using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject BombPrefab;
    public GameObject SpawnerParrent;
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
            var Bomb = Instantiate(BombPrefab, pos, rot);
            Bomb.transform.position = pos;
            timer = RateOfFire;
        }
    }
}
