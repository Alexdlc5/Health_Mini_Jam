using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breach : MonoBehaviour
{
    public float repair_time_set = 2;
    public GameObject audio;
    private Ship_Manager ship;
    private bool closing = false;
    private float repair_time;

    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
        repair_time = repair_time_set;
    }
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if (!ship.gameover)
        {
            if (closing && repair_time > 0)
            {
                repair_time -= Time.deltaTime;
            }
            else if (closing)
            {
                Instantiate(audio);
                repair_time = repair_time_set;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            closing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            closing = false;
        }
    }
}
