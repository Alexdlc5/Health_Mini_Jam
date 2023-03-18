using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro_Movement : MonoBehaviour
{
    private Ship_Manager ship;
    public float x_speed = 10;
    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
    }
    private void FixedUpdate()
    {
        if (!ship.gameover)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += (Vector3)Vector2.up * x_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += (Vector3)Vector2.down * x_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += (Vector3)Vector2.left * x_speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += (Vector3)Vector2.right * x_speed * Time.deltaTime;
            }
        }
    }
}
