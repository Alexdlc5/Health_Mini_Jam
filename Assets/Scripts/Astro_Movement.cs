using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro_Movement : MonoBehaviour
{
    private Ship_Manager ship;
    private Animator animator;
    public float speed = 10;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
    }
    private void FixedUpdate()
    {
        if (!ship.gameover)
        {
            animator.SetBool("Key", false);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool("Key", true);
                animator.SetBool("Up", true);
                transform.position += (Vector3)Vector2.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("Key", true);
                animator.SetBool("Up", false);
                transform.position += (Vector3)Vector2.down * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("Key", true);
                animator.SetBool("Right", false);
                transform.position += (Vector3)Vector2.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("Key", true);
                animator.SetBool("Right", true);
                transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
            }
        }
    }
}
