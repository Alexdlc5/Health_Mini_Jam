using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_Spawn : MonoBehaviour
{
    public Ship_Manager ship;
    public GameObject oxygen_tank;
    public float spawn_rate = .5f;
    public float[] spawn_rate_range;
    public float[] spawn_range;
    private float timer = 0;
    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!ship.gameover)
        {
            if (timer < spawn_rate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = Random.Range(spawn_rate_range[0], spawn_rate_range[1]);
                float random_angle = Random.Range(1, 359);
                float random_x = Random.Range(spawn_range[0], spawn_range[1]);
                Instantiate(oxygen_tank, new Vector2(random_x, transform.position.y), Quaternion.Euler(new Vector3(0, 0, random_angle)));
            }
        }
    }
}
