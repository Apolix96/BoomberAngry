using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private new Renderer renderer;
    [SerializeField]
    private float destroyTime;
    [SerializeField]
    private GameObject explosionPrefab;

    public int damage  = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer, true);
        Physics2D.IgnoreLayerCollision(gameObject.layer, explosionPrefab.layer, true);
        int force = Random.Range(3,15);
        rb2D.AddForce(transform.right * -force, ForceMode2D.Impulse);
        renderer = gameObject.GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" && gameObject.tag == "Untagged")
        {
            renderer.material.DOColor(Color.red, destroyTime).OnComplete(createExplosion);
            Destroy(gameObject, destroyTime);
            gameObject.tag = "Respawn";
        }  
    }

    private void createExplosion()
    {
        if (renderer != null)
        {
            var pos = transform.position;
            var rot = transform.rotation;
            var exsplosion = Instantiate(explosionPrefab, pos, rot);
            Destroy(exsplosion, 0.3f);
        }
    }
}
