
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    //speed of camera
    public float sSpeed = 10.0f;
    public Transform lookTarget;

    void FixedUpdate()
    {
        //offsets the camera
        Vector3 dPos = cameraTarget.position;
        //makes camera movement smooth
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        // the transform is placed in front of the car 
        transform.LookAt(lookTarget.position);
    }
}
