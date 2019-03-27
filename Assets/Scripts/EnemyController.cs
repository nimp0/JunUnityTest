using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 10f;
    public Rigidbody rb;
    private Vector3 spawnPosition;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        BoundCheck();
    }

    void FixedUpdate ()
    {
        Move();        
    }

    private void Move()
    {
        if (rb.gameObject.tag == "Diagonal" || rb.gameObject.tag == "Special")
        {
            if (spawnPosition == new Vector3(-10f, spawnPosition.y, 10f))
            {
                rb.MovePosition(transform.position + new Vector3(1f, transform.position.y, -1f) * Time.deltaTime * speed);
            }
            else if (spawnPosition == new Vector3(10f, spawnPosition.y, 10f))
            {
                rb.MovePosition(transform.position + new Vector3(-1f, transform.position.y, -1f) * Time.deltaTime * speed);
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            }
        }
        else if (rb.gameObject.tag == "Vertical")
        {
            rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);            
        }
    }

    private void BoundCheck()
    {
        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
            if (rb.gameObject.tag != "Special")
            {
                SoundManager.instance.EnemyMissingSound();
                PlayerLogic.counter++;                
            }
        }
    }
}
