using UnityEngine;
using System.Collections;

public class PickUpTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            gameObject.GetComponent<Gun>().hasOwner = true;
            gameObject.transform.parent = coll.transform.Find("Inventory").gameObject.transform;
            gameObject.layer = 9;
            foreach (Collider2D col in gameObject.GetComponent<Gun>().colls)
            {
                col.isTrigger = false;
            }
            if (!coll.GetComponent<Player>().GetFacing())
            {
                Vector3 tScale = transform.localScale;
                tScale.x *= -1;
                transform.localScale = tScale;
                //transform.localRotation = Quaternion.Euler(0, 0, 95);
            }
            gameObject.SetActive(false);

            if (gameObject.tag == "Rifle")
                coll.GetComponent<Player>().rifle = gameObject;
            if (gameObject.tag == "Pistol")
                coll.GetComponent<Player>().pistol = gameObject;

            /*
            if (gameObject.tag == "Rifle")
            {
                gameObject.GetComponent<Rifle>().hasOwner = true;
                gameObject.transform.parent = coll.transform.Find("Inventory").gameObject.transform;
                gameObject.layer = 9;
                foreach (Collider2D col in gameObject.GetComponent<Rifle>().colls)
                {
                    col.isTrigger = false;
                }
                if(!coll.GetComponent<Player>().GetFacing())
                {
                    Vector3 tScale = transform.localScale;
                    tScale.x *= -1;
                    transform.localScale = tScale;
                    //transform.localRotation = Quaternion.Euler(0, 0, 95);
                }       
                gameObject.SetActive(false);
                coll.GetComponent<Player>().rifle = gameObject;
            }
            if (gameObject.tag == "Pistol")
            {
                gameObject.GetComponent<Pistol>().hasOwner = true;
                gameObject.transform.parent = coll.transform.Find("Inventory").gameObject.transform;
                gameObject.layer = 9;
                foreach (Collider2D col in gameObject.GetComponent<Pistol>().colls)
                {
                    col.isTrigger = false;
                }
                if (!coll.GetComponent<Player>().GetFacing())
                {
                    Vector3 tScale = transform.localScale;
                    tScale.x *= -1;
                    transform.localScale = tScale;
                    //transform.localRotation = Quaternion.Euler(0, 0, 95);
                }
                gameObject.SetActive(false);
                coll.GetComponent<Player>().pistol = gameObject;
            }
            */
        }

    }
}
