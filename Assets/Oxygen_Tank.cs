using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_Tank : MonoBehaviour
{
    public float oxygen = 15;
    void Drain()
    {
        oxygen -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Airlock"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
