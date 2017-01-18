using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rifle : MonoBehaviour
{
    public Transform barrel;

    //Preafbs
    public GameObject pociskPre;

    GameObject player;

    public bool hasOwner;

    public int ammoInMag;
    public int ammo;
    public int magSize;

    public float bulletSpeed;
    public float fireRate;
    public float reloadTime;
    public int damage;

    public bool rapidFire = true;
    public bool rdyNextFire = true;

    public Player.typesOfGuns typeOfGun;
    public List<Collider2D> colls = new List<Collider2D>();

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ammoInMag = magSize;
        ammo -= magSize;

        colls.AddRange(gameObject.GetComponents<Collider2D>());
    }

    // Use this for initialization
    void Start ()
    {
	    if(transform.parent == null)
        {
            hasOwner = false;
            gameObject.layer = 12;

            foreach (Collider2D coll in colls)
            {
                coll.isTrigger = true;
            }
        }
        else
        {
            hasOwner = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!hasOwner)
        {
            gameObject.GetComponent<MovingUpDown>().Floating();
        }
	}

    public void shot()
    {
        if (rdyNextFire)
        {
            if (player.GetComponent<Player>().praweWyciagniecieBroni)
            {
                if (player.GetComponent<Player>().GetFacing())
                {
                    GameObject pociskClone = (GameObject)Instantiate(pociskPre, barrel.position, barrel.rotation);
                    Rigidbody2D rbp = pociskClone.GetComponent<Rigidbody2D>();
                    pociskClone.GetComponent<Pocisk>().damage = damage;
                    rbp.velocity = pociskClone.transform.right * bulletSpeed;
                }
                else
                {
                    GameObject pociskClone = (GameObject)Instantiate(pociskPre, barrel.position, Quaternion.Inverse(barrel.rotation));
                    Rigidbody2D rbp = pociskClone.GetComponent<Rigidbody2D>();
                    pociskClone.GetComponent<Pocisk>().damage = damage;
                    Vector3 tScale = pociskClone.transform.localScale;
                    tScale.x *= -1;
                    pociskClone.transform.localScale = tScale;
                    rbp.velocity = -pociskClone.transform.right * bulletSpeed;
                }
            }
            else if (!player.GetComponent<Player>().praweWyciagniecieBroni)
            {
                if (player.GetComponent<Player>().GetFacing())
                {
                    GameObject pociskClone = (GameObject)Instantiate(pociskPre, barrel.position, barrel.rotation);
                    Rigidbody2D rbp = pociskClone.GetComponent<Rigidbody2D>();
                    pociskClone.GetComponent<Pocisk>().damage = damage;
                    Vector3 tScale = pociskClone.transform.localScale;
                    tScale.x *= -1;
                    pociskClone.transform.localScale = tScale;
                    rbp.velocity = -pociskClone.transform.right * bulletSpeed;
                }
                else
                {
                    GameObject pociskClone = (GameObject)Instantiate(pociskPre, barrel.position, Quaternion.Inverse(barrel.rotation));
                    Rigidbody2D rbp = pociskClone.GetComponent<Rigidbody2D>();
                    pociskClone.GetComponent<Pocisk>().damage = damage;
                    rbp.velocity = pociskClone.transform.right * bulletSpeed;
                }
            }
            rdyNextFire = false;
            removeAmmo();
            StartCoroutine(shotingDelay());
        }
    }

    IEnumerator shotingDelay()
    {
        yield return new WaitForSeconds((fireRate/1000));
        rdyNextFire = true;
    }

    void removeAmmo()
    {
        ammoInMag--;
    }

    public void ReloadFun(float times)
    {
        if (ammo > 0)
            StartCoroutine(Reload(times));
    }

    IEnumerator Reload(float time)
    {
        yield return new WaitForSeconds(time);

        int lackAmmo = magSize - ammoInMag;
        ammo -= lackAmmo;
        ammoInMag += lackAmmo;
    }

    public string showAmmo()
    {
        return ammoInMag.ToString() + "/" + ammo.ToString();
    }
}
