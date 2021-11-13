using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createObject : MonoBehaviour
{
    public GameObject ToSpawn;
    public float offsetX;
    public float offsetY;
    public float spawnInterval;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer++;
        if (spawnTimer > spawnInterval) {
            spawnTimer = 0;
        }
        if(spawnTimer == 1)
        {
            Instantiate(ToSpawn, new Vector2(transform.position.x + offsetX, transform.position.y + offsetY), Quaternion.identity);
        }
        
    }
}
