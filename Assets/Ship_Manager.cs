using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Ship_Manager : MonoBehaviour
{
    public float score = 0;
    public GameObject gameover_screen;
    public bool gameover = false;
    public Slider oxygen_slider;
    public TextMeshProUGUI drain_display;
    public TextMeshProUGUI score_display;
    public TextMeshProUGUI high_score_display;
    private float previous_ox_time;
    public float ox_time = 20;
    public float ox_max = 20;
    private int breach_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        previous_ox_time = (int)ox_time;
        oxygen_slider.maxValue = ox_max;
        oxygen_slider.value = ox_time;
        drain_display.text = "-" + 1 + "x";
        int intscore = (int)score;
        score_display.text = "Score: " + intscore;
        high_score_display.text = "High: " + Player_Data.high_score;
    }

    // Update is called once per frame
    void Update()
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
            float drain = 1 + ((float)breach_count) * 2;
            ox_time -= drain * Time.deltaTime;
            //UI
            drain_display.text = "O2 Loss: " + Math.Round(drain, 2) + "x";
            oxygen_slider.value = ox_time;
            int intscore = (int)score;
            score_display.text = "Score: " + intscore;
        }
        else
        {
            gameover_screen.SetActive(true);
            drain_display.gameObject.SetActive(false);
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
