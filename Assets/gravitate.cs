using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitate : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject[] others;
    public float startVelX;
    public float startVelY;
    public GameObject cam; // Discount the camera because we don't want objects gravitating towards it
    public bool changeColor = true;
    Vector2 force;
    public bool AimAtObject = false;
    public GameObject ObjectToAim;
    // Start is called before the first frame update
    void Start()
    {
        others = UnityEngine.Object.FindObjectsOfType<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        if (AimAtObject)
        {
            startVelX = (ObjectToAim.transform.position.x - transform.position.x) * Mathf.Pow(transform.localScale.x, 4)*10;
            startVelY = (ObjectToAim.transform.position.y - transform.position.y) * Mathf.Pow(transform.localScale.x, 4)*10;
        }
        rb.AddForce(transform.right * startVelX / transform.localScale.x / Mathf.Pow(transform.localScale.x, 3));
        rb.AddForce(transform.up * startVelY / transform.localScale.x / Mathf.Pow(transform.localScale.x, 3));

        // Rainbow Colors
        if (changeColor) {
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.3f, 1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (GameObject other in others) {
            if (other.activeInHierarchy && other != cam) {

                Vector2 direction = other.transform.position - transform.position;
                float distance = direction.magnitude;

                float forceMagnitude = Mathf.Pow(other.transform.localScale.x / transform.localScale.x, 3) / Mathf.Pow(distance, 2);
                force = direction.normalized * forceMagnitude;
                if (distance >= other.transform.localScale.x / 2 + transform.localScale.x / 2)
                {
                    rb.AddForce(force);
                }
                //other.transform.position.y - transform.position.y) / Mathf.Pow((other.transform.position.x - transform.position.x) * (other.transform.position.x - transform.position.x) + (other.transform.position.y - transform.position.y) * (other.transform.position.y - transform.position.y), 2) * Mathf.Pow(other.transform.localScale.x / transform.localScale.x, 3);
            } 
        }
        
    }
}
