using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bullet : MonoBehaviour
{

    public int dmgAmount;
    public float bulletSpeed = 3f;
    public Rigidbody2D theRB;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        direction = Player_controller.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Player_controller.instance.takeDamage(dmgAmount);
            Destroy(gameObject);
        }
        
    }
}
