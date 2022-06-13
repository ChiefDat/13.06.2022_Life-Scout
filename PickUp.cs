using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Item;
    public bool CanPickUp;
    public int sticks;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        sticks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(Item);
                Item = null;
                sticks += 1;
            }
        }

        if(CanPickUp == true)
        {
            Canvas.SetActive(true);
        }
        else
        {
            Canvas.SetActive(false);
        }

    }  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {

            Item = other.gameObject;
            CanPickUp = true;

        }
        Item = other.gameObject;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            Item = null;
            CanPickUp = false;
        }


    }

}
