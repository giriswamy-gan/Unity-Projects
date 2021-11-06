using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchable : MonoBehaviour
{   
    Rigidbody2D rb;
    public int health = 100;
    public int punch_dam = 10;
    public float throwback = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health==0){
            Debug.Log("RIP nerd");
        }
    }

    //Collision Code
    private void OnCollisionEnter2D(Collision2D col){
        //Debug.Log("Entered"); works
        //Debug.Log(col.otherCollider);
        //Debug.Log(col.collider);
        //CapsuleCollider2D enemyBody = col.gameObject.GetComponent<CapsuleCollider2D>();
        if(col.collider is CircleCollider2D){
            //Knockback 
            rb.AddForce(col.relativeVelocity*throwback);
            health= health - punch_dam;
       // col.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity*15f);
        //Debug.Log("HaHa");
        }
    }
}
