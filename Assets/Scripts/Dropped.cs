using UnityEngine;
using System.Collections;

public class Dropped : MonoBehaviour
{
    public void Drop()
    {
        gameObject.GetComponent<Gun>().hasOwner = false;
        gameObject.layer = 12;
        foreach (Collider2D col in gameObject.GetComponent<Gun>().colls)
        {
            col.isTrigger = true;
        }
        
        /*
        if (gameObject.tag == "Rifle")
        {
            gameObject.GetComponent<Rifle>().hasOwner = false;
            gameObject.layer = 12;
            foreach (Collider2D col in gameObject.GetComponent<Rifle>().colls)
            {
                col.isTrigger = true;
            }
        }
        if (gameObject.tag == "Pistol")
        {
            gameObject.GetComponent<Pistol>().hasOwner = false;
            gameObject.layer = 12;
            foreach (Collider2D col in gameObject.GetComponent<Pistol>().colls)
            {
                col.isTrigger = true;
            }   
        }
        */
    }
}
