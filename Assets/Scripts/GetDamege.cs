using UnityEngine;
using System.Collections;

public class GetDamege : MonoBehaviour
{
    GameObject owner;

    void Awake()
    {
        owner = transform.gameObject;
    }

    public void Damage(float damage)
    {
        if(owner.tag == "Player")
        {
            owner.GetComponent<Player>().GetDamege(damage);
        }
        if (owner.tag == "Zombie")
        {
            owner.GetComponent<Zombie>().GetDamege(damage);
        }
    }
}
