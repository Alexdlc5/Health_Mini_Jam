using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    //Shaking IEnumerator Credit: Thomas Friday https://www.youtube.com/watch?v=BQGTdRhGmE4&t=157s
    public bool start = false;
    public float dampen = 1;
    public AnimationCurve curve;
    public float duration = 1;
    private void Start()
    {
        start = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
        else if (!start)
        {
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength / dampen;
            yield return null;
        }
        transform.position = startPosition;
    }
}
