using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.drag = 0.5f;
    }
}
