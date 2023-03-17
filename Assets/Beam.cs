using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float beam_strength;
    // Update is called once per frame
    void Update()
    {
        //with player input, find nearest piece of cargo and use tractor beam on it
        if (Input.GetMouseButton(0))
        {
            GameObject[] nearby_cargo = GameObject.FindGameObjectsWithTag("Cargo");
            GameObject closest_cargo = null;
            foreach (GameObject cargo in nearby_cargo)
            {
                if (closest_cargo == null)
                {
                    closest_cargo = cargo;
                }
                else if (Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), cargo.transform.position) < Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), closest_cargo.transform.position))
                {
                    closest_cargo = cargo;
                }
            }
            //move cargo
            closest_cargo.transform.position = Vector3.MoveTowards(closest_cargo.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), beam_strength * Time.deltaTime);
            closest_cargo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    //find distance between two vectors
    private float Distance(Vector3 pointa, Vector3 pointb)
    {
        return Mathf.Sqrt(Mathf.Pow(pointb.x - pointa.x, 2) + Mathf.Pow(pointb.y - pointa.y, 2));
    }
}

