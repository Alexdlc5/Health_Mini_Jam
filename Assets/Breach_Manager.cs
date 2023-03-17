using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breach_Manager : MonoBehaviour
{
    private GameObject[] breaches;
    private float timer = 0;
    private float count_to = 5;
    private float game_time = 0;
    private int breach_check_timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        breaches = GameObject.FindGameObjectsWithTag("Breach");
        foreach (GameObject breach in breaches) 
        {
            breach.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        //spawnrate countdown

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
