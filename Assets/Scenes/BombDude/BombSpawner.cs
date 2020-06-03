using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    public GameObject BombPrefab;
    public GameObject SpawnerParrent;
    private float timer;
    public float rateOfFire;
    // Start is called before the first frame update
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && rateOfFire!=0)
        {
            var pos = SpawnerParrent.transform.position;
            var rot = transform.rotation;
            var Bomb = Instantiate(BombPrefab, pos, rot);
            Bomb.transform.position = pos;
            timer = rateOfFire;
        }
    }
}
