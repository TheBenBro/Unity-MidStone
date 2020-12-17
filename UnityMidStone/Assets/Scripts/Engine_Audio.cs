using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Audio : MonoBehaviour
{
    public float topSpeed = 50;
    private float currentSpeed = 0;
    private float pitch = 0;
    // Update is called once per frame
    void Update()
    {
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        pitch = currentSpeed / topSpeed;

        transform.GetComponent<AudioSource>().pitch = pitch + 0.5f;
    }
}
