using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_and_Destroy : MonoBehaviour
{
    public float clip_length = 0.406f;
    private void Update()
    {
        if (clip_length > 0)
        {
            clip_length -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
}
