using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_Tank : MonoBehaviour
{
    public bool isAsteroid = false;
    public float oxygen = 15;
    public bool in_zone = true;
    private Ship_Manager ship;
    public GameObject audio;
    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
    }
    private void FixedUpdate()
    {
        if (!in_zone)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAsteroid && collision.gameObject.tag.Equals("Airlock"))
        {
            if (ship.ox_time + oxygen > ship.ox_max)
            {
                ship.ox_time = ship.ox_max;
            }
            else
            {
                ship.ox_time += oxygen;
            }
            Instantiate(audio);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Game_Area"))
        {
            in_zone = false;
        }
    }
}
