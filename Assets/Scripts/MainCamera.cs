using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Player player;

    public float start;
    public float end;

    public float top;
    public float bottom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float player_x = player.transform.position.x;
        float camera_x = transform.position.x;

        float player_y = player.transform.position.y;
        float camera_y = transform.position.y;

        //Vector3 camera_position = transform.position;


        if (player_x > start && player_x < end)
        {
            camera_x = player_x;
        }
        else
        {
            if (player_x < start)
            {
                camera_x = start;
            }
            if (player_x > end)
            {
                camera_x = end;
            }
        }

        if (player_y < top && player_y > bottom)
        {
            camera_y = player_y;
        }
        else
        {
            if (player_y < bottom)
            {
                camera_y = bottom;
            }
            if (player_y > top)
            {
                camera_y = top;
            }

        }

        transform.position = new Vector3(camera_x, camera_y, transform.position.z);
    }
}
