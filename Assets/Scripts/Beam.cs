using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public bool inMenu = false;
    public Vector2 beam_origin = new Vector2(0, 0);
    private Ship_Manager ship;
    public float beam_sensitivity;
    private LineRenderer line;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship_Manager>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        line.enabled = false;
        if (!ship.gameover)
        {
            if (!inMenu && Input.GetMouseButton(0))
            {
                //find closest cargo
                GameObject closest_cargo = null;
                GameObject[] cargo = GameObject.FindGameObjectsWithTag("Cargo");
                Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                foreach (GameObject c in cargo)
                {
                    if (closest_cargo == null && Vector2.Distance(mouse_position, c.transform.position) < beam_sensitivity)
                    {
                        closest_cargo = c;
                    }
                    else if (c != null && closest_cargo != null && Vector2.Distance(mouse_position, closest_cargo.transform.position) > Vector2.Distance(c.transform.position, mouse_position) && Vector2.Distance(mouse_position, c.transform.position) < beam_sensitivity)
                    {
                        closest_cargo = c;
                    }
                }
                if (closest_cargo != null)
                {
                    closest_cargo.transform.position = mouse_position;
                    line.enabled = true;
                    line.SetPosition(0, closest_cargo.transform.position);
                    line.SetPosition(1, beam_origin);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                GameObject cargo = GameObject.FindGameObjectWithTag("Cargo");
                Vector2 mouse_position = ship.gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                cargo.transform.position = mouse_position;
                line.enabled = true;
                line.SetPosition(0, cargo.transform.position);
                line.SetPosition(1, beam_origin);
            }

        }
            //with player input, find nearest piece of cargo and use tractor beam on it
            //if (Input.GetMouseButton(0))
            //{
            //GameObject[] nearby_cargo = GameObject.FindGameObjectsWithTag("Cargo");
            //GameObject closest_cargo = null;
            //foreach (GameObject cargo in nearby_cargo)
            //{
            //    if (closest_cargo == null)
            //    {
            //        closest_cargo = cargo;
            //    }
            //    else if (Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), cargo.transform.position) < Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), closest_cargo.transform.position))
            //    {
            //        closest_cargo = cargo;
            //    }
            //}
            ////move cargo
            //closest_cargo.transform.position = Vector3.MoveTowards(closest_cargo.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), beam_strength * Time.fixedDeltaTime);
            //closest_cargo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //find distance between two vectors
            //private float Distance(Vector3 pointa, Vector3 pointb)
            //{
            //    return Mathf.Sqrt(Mathf.Pow(pointb.x - pointa.x, 2) + Mathf.Pow(pointb.y - pointa.y, 2));
            //}
        
    }
}



