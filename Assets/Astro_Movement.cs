using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float max_booster_speed;
    public float acceleration;
    public float xdamp;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float velocityInDirection = Vector2.Dot(rb.velocity, Vector2.up);
            if (velocityInDirection <= max_booster_speed)
            {
                rb.AddForce(Vector2.up * acceleration * Time.fixedDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float velocityInDirection = Vector2.Dot(rb.velocity, Vector2.down);
            if (velocityInDirection <= max_booster_speed)
            {
                rb.AddForce(Vector2.down * acceleration * Time.fixedDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float velocityInDirection = Vector2.Dot(rb.velocity, Vector2.left);
            if (velocityInDirection <= max_booster_speed)
            {
                rb.AddForce(Vector2.left * acceleration * xdamp * Time.fixedDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float velocityInDirection = Vector2.Dot(rb.velocity, Vector2.right);
            if (velocityInDirection <= max_booster_speed)
            {
                rb.AddForce(Vector2.right * acceleration * xdamp *Time.fixedDeltaTime);
            }
        }
    }
}
