using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, height, startpos_x, startpos_y;
    public float parallaxFactor;
    public GameObject cam;
    public float PixelsPerUnit;

    // Start is called before the first frame update
    void Start()
    {
        startpos_x = transform.position.x;
        startpos_y = transform.position.y;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {

        float temp_x = cam.transform.position.x * (1 - parallaxFactor);
        float distance_x = cam.transform.position.x * parallaxFactor;

        float temp_y = cam.transform.position.y * (1 - parallaxFactor);
        float distance_y = cam.transform.position.y * parallaxFactor;

        Vector3 newPosition = new Vector3(startpos_x + distance_x, startpos_y + distance_y, transform.position.z);

        transform.position = newPosition;
        //transform.position = PixelPerfectClamp(newPosition, PixelsPerUnit);

        if (temp_x > startpos_x + (length / 2)) startpos_x += length;
        else if (temp_x < startpos_x - (length / 2)) startpos_x -= length;

        //if (temp_y > startpos_y + (height / 2)) startpos_y += height;
        //else if (temp_y < startpos_y - (height / 2)) startpos_y -= height;
    }

    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(Mathf.CeilToInt(locationVector.x * pixelsPerUnit), Mathf.CeilToInt(locationVector.y * pixelsPerUnit), Mathf.CeilToInt(locationVector.z * pixelsPerUnit));
        return vectorInPixels / pixelsPerUnit;
    }

    

}


