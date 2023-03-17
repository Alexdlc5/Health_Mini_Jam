using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship_Manager : MonoBehaviour
{
    public Slider oxygen_slider;
    public TextMeshProUGUI oxygen_time;
    private float previous_ox_time;
    private float ox_time = 20;

    // Start is called before the first frame update
    void Start()
    {
        previous_ox_time = (int)ox_time;
        oxygen_slider.maxValue = ox_time;
        oxygen_slider.value = ox_time;
        oxygen_time.text = (int)ox_time + " sec";
    }

    // Update is called once per frame
    void Update()
    {
        ox_time -= Time.deltaTime;
        if (previous_ox_time < ox_time)
        {
            oxygen_slider.maxValue = ox_time;
        }
        oxygen_slider.value = ox_time;
        oxygen_time.text = (int)ox_time + " sec";
    }
}
