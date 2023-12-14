using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_ob : MonoBehaviour
{
    public float moveSpeed = 6f;
    private Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 1)
        {
            Debug.Log("Nhan vat cham vao layer 1");
        }
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

    }
}
