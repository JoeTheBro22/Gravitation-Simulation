using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing : MonoBehaviour
{
    public GameObject ToHome;
    public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ToHome)
        {
            Vector2 dir = collision.gameObject.transform.position - transform.position;
            var force = dir.normalized * magnitude;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
