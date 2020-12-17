using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Item : MonoBehaviour
{
    private Character Car;
    private ItemsHandle handle;

    public float timeBeforePickup = 1;
    public int HeldItem;

    public bool CanPickup;
    private bool useItem;

    public Items itemUse;
    private int remainingUses;
    // Start is called before the first frame update
    void Start()
    {
        handle = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemsHandle>();

        Car = GetComponent<Character>();

        ResetItem();
    }

    public void StartPickup()
    {
        StartCoroutine(Pickup());
    }
    public IEnumerator Pickup()
    {
        if (HeldItem == -1 && CanPickup)
        {
            CanPickup = false;

            yield return new WaitForSeconds(timeBeforePickup);

            int randomItem = Random.Range(0, handle.items.Length);

            itemUse = handle.items[randomItem];

            HeldItem = randomItem;
            remainingUses = itemUse.uses;
        }
    }

    private void Update()
    {
        if(useItem && HeldItem != -1)
        {
            ActivateItem();
        }
    }

    public void ActivateItem()
    {
        remainingUses -= 1;
        if(itemUse.Boost.Length > 0)
        {
            foreach(Boost boost in itemUse.Boost)
            {
                Car.callBoost();
            }

            if(remainingUses <= 0)
            {
                ResetItem();
            }
        }
    }

    public void ResetItem()
    {
        itemUse = null;
        HeldItem = -1;
        CanPickup = true;
    }
}
