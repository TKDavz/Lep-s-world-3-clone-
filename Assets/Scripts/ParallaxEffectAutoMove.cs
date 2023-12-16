using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectAutoMove : MonoBehaviour
{
    private float length, startpos_x;
    public float parallaxFactor;
    public bool isRight = true;

    public GameObject cam;
    private Vector3 camPositon;
    public float moveSpeed; // The speed at which the sprite moves
    public float PixelsPerUnit;
    private float distance_x = 0;

    // Start is called before the first frame update
    void Start()
    {

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        camPositon = cam.transform.position;
        startpos_x = camPositon.x * (1 - parallaxFactor);

    }

    // Update is called once per frame
    void Update()
    {

        // Calculate the distance the sprite should move horizontally and vertically
        distance_x += moveSpeed * Time.deltaTime * parallaxFactor * (isRight ? 1 : -1);

        // Calculate the new position of the sprite
        Vector3 newPosition = new Vector3(startpos_x + distance_x, transform.position.y, transform.position.z);

        // Update the position of the sprite
        transform.position = newPosition;
        //transform.position = PixelPerfectClamp(newPosition, PixelsPerUnit);

        // Check if the sprite has moved past its length, then reposition it accordingly
        if (newPosition.x > camPositon.x + length / 2) distance_x -= length;
        else if (newPosition.x < camPositon.x - length / 2) distance_x  += length;

    }

    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(Mathf.CeilToInt(locationVector.x * pixelsPerUnit), Mathf.CeilToInt(locationVector.y * pixelsPerUnit), Mathf.CeilToInt(locationVector.z * pixelsPerUnit));
        return vectorInPixels / pixelsPerUnit;
    }
}
