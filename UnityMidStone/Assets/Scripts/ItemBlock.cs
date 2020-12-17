using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Car_Item>().HeldItem == -1 && other.GetComponent<Car_Item>().CanPickup)
            {
                other.GetComponent<Car_Item>().StartPickup();
                Destroy(this.gameObject);
            }
        }
    }
}
