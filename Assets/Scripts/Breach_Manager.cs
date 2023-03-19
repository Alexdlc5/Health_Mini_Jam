using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breach_Manager : MonoBehaviour
{
    private Ship_Manager ship;
    private GameObject[] breaches;
    private float timer = 0;
    public float count_to = 5;
    private float game_time = 0;
    private int breach_check_timer = 0;
    private HashSet<int> diff_tiers = new HashSet<int>();
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
        breaches = GameObject.FindGameObjectsWithTag("Breach");
        foreach (GameObject breach in breaches) 
        {
            breach.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ship.gameover)
        {
            if (!diff_tiers.Contains(1) && ship.score > 1000)
            {
                diff_tiers.Add(1);
                count_to -= .1f;
            }
            else if (!diff_tiers.Contains(2) && ship.score > 5000)
            {
                diff_tiers.Add(2);
                count_to -= .1f;
            }
            else if (!diff_tiers.Contains(3) && ship.score > 10000)
            {
                diff_tiers.Add(3);
                count_to -= .1f;
            }
            else if (!diff_tiers.Contains(4) && ship.score > 12000)
            {
                diff_tiers.Add(4);
                count_to -= .1f;
            }
            else if (!diff_tiers.Contains(5) && ship.score > 15000)
            {
                diff_tiers.Add(5);
                count_to -= .2f;
            }
            game_time += Time.deltaTime;
            //spawning countdown
            if (timer < count_to)
            {
                timer += Time.deltaTime;
            }
            else
            {
                activateBreach();
                timer = 0;
            }
        }
    }
    void activateBreach()
    {
        if (breach_check_timer < 16)
        {
            GameObject selected_breach = breaches[Random.Range(0, 16)];
            if (!selected_breach.activeInHierarchy)
            {
                selected_breach.SetActive(true);
                breach_check_timer = 0;
            }
            else
            {
                breach_check_timer++;
                activateBreach();
            }
        } 
        else
        {
            breach_check_timer = 0;
        }
    }
}
