using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 70f;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }else if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        {
            this.direction = Vector2.right;
        }
        else { this.direction = Vector2.zero; }
    }
    private void FixedUpdate()
    {
       if(this.direction!=Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction*this.speed) ;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if(ball != null)
        {
            Vector3 recpostion = this.transform.position;
            Vector2 contacpoint = collision.GetContact(0).point;    
        }
    }
}
