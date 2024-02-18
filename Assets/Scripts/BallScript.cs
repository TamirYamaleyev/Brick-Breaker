using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject paddle;
    private Rigidbody2D _rb { get; set; }
    public float speed;
    bool magnetize = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        MagnetizedBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetize)
        {
            MagnetizedBall();
        }
        if (Input.GetKeyDown("space"))
        {
            magnetize = false;
            SendBall();
        }
    }

    private void SendBall()
    {
        SetRandomTrajectory();
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        if (Random.value < 0.5f) force.x = -0.5f;
        else force.x = 0.5f;
        force.y = 1;

        _rb.AddForce(force.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") && magnetize)
        {
            MagnetizedBall();
        }
    }

    private void MagnetizedBall()
    {
        gameObject.transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 0.35f);
    }
}
