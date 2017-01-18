using UnityEngine;
using System.Collections;

public class GetHit : MonoBehaviour
{
    public float multiplier = 1f;
    public GameObject owner;

    void Awake()
    {
        owner = transform.root.gameObject;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("COLISION!");
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log(coll.gameObject.name);
            float damage = coll.gameObject.GetComponent<Pocisk>().damage * multiplier;
            owner.GetComponent<GetDamege>().Damage(damage);
        }
    }

}
