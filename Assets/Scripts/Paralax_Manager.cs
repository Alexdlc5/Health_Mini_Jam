using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax_Manager : MonoBehaviour
{
    public GameObject close_backround;
    public List<GameObject> close_backround_tiles;
    public GameObject backround;
    public List<GameObject> backround_tiles;
    public GameObject far_backround;
    public List<GameObject> far_backround_tiles;
    public float movement_speed = 1;
    private void Start()
    {
        float current_y = -33.25f;
        for (int i = 0; i < 5; i++)
        {
            close_backround_tiles.Add(Instantiate(close_backround, new Vector2(0, current_y), transform.rotation));
            current_y += 16.45f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject tile in close_backround_tiles)
            {
                if (tile.transform.position.y <= -30f)
                {
                    tile.transform.position = new Vector2(0, tile.transform.position.y+ 16.45f * 4);
                }
                else
                {
                    tile.transform.position -= (Vector3)Vector2.up * movement_speed * Time.deltaTime;
                }
            }
        foreach (GameObject tile in backround_tiles)
        {
            if (tile.transform.position.y <= -30f)
            {
                tile.transform.position = new Vector2(tile.transform.position.x + 16.45f * 4, -2.1f);
            }
            else
            {
                tile.transform.position -= (Vector3)Vector2.right * movement_speed / 2 * Time.deltaTime;
            }
        }
        foreach (GameObject tile in far_backround_tiles)
        {
            if (tile.transform.position.y <= -30f)
            {
                tile.transform.position = new Vector2(tile.transform.position.x + 16.45f * 4, -2.1f);
            }
            else
            {
                tile.transform.position -= (Vector3)Vector2.right * movement_speed / 4 * Time.deltaTime;
            }
        }   
    }
}