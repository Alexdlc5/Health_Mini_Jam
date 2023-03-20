using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Ship_Manager : MonoBehaviour
{
    public bool inMenu = false;
    public float score = 0;
    public GameObject gameover_screen;
    public bool gameover = false;
    public Slider oxygen_slider;
    public TextMeshProUGUI score_display;
    public TextMeshProUGUI high_score_display;
    private float previous_ox_time;
    public float ox_time = 20;
    public float ox_max = 20;
    private int breach_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!inMenu)
        {
            previous_ox_time = (int)ox_time;
            oxygen_slider.maxValue = ox_max;
            oxygen_slider.value = ox_time;
            int intscore = (int)score;
            score_display.text = "Score: " + intscore;
            high_score_display.text = "High: " + Player_Data.high_score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMenu)
        {
            if (ox_time <= 0)
            {
                gameover = true;
            }
            if (!gameover)
            {
                score += Time.deltaTime * 100;
                //drain
                breach_count = GameObject.FindGameObjectsWithTag("Breach").Length;
                float drain = .8f + ((float)breach_count);
                if (score > 10000)
                {
                    ox_time -= drain * 1.2f * Time.deltaTime;
                }
                else if (score > 8000)
                {
                    ox_time -= drain * 1.2f * Time.deltaTime;
                }
                else if (score > 4000)
                {
                    ox_time -= drain * 1.2f * Time.deltaTime;
                }
                else if (score > 2000)
                {
                    ox_time -= drain * 1.2f * Time.deltaTime;
                }
                else if (score > 1000)
                {
                    ox_time -= drain * 1.2f * Time.deltaTime;
                }
                else
                {
                    ox_time -= drain * Time.deltaTime;
                }
                //UI
                oxygen_slider.value = ox_time;
                int intscore = (int)score;
                score_display.text = "Score: " + intscore;
            }
            else
            {
                gameover_screen.SetActive(true);
                oxygen_slider.gameObject.SetActive(false);
                score_display.gameObject.SetActive(false);
                high_score_display.gameObject.SetActive(false);
                if (Player_Data.high_score < score)
                {
                    Player_Data.high_score = (int)score;
                }
            }
        }
    }
}
