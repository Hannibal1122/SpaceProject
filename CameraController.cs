using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    private Vector3 distance = new Vector3(0f, 0f, -10f);
    /* private Vector3 offset; */            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        /* offset = transform.position - target.transform.position; */
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate () 
    {
        Vector3 cameraFollowPosition = new Vector3(0, 100);
        /* if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.transform.position);
            Vector3 delta = target.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        } */
        Vector3 wantedPosition = target.transform.position + distance;
        Vector3 currentPosition = Vector3.Lerp(transform.position, wantedPosition, 2f * Time.deltaTime);
        transform.position = currentPosition;

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        /* transform.position = target.transform.position + offset; */
        /* background.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z); */
    }
}
