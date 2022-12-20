using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    int diem = 0;
    Rigidbody2D rb;
    private float speed=400;
    public Text scoretext;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
        scoretext.text = "Score: " + diem;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + diem;
    }
    
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, -1f);
        force.y = -1f;

        this.rb.AddForce(force.normalized * this.speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Square")
        {
            diem++;
        }
        if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }

}
