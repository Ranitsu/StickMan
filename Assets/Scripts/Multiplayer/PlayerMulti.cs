using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMulti : NetworkBehaviour
{
    GameObject gameManager;

    public float MovementSpeed = 10f;
    public float jumpForce = 200.0f;
    public float angle;


    int health;
    int armor;

    //Ammo
    public int ammoInCurrentGun;
    public int currentGunAmmo;

    bool facingRight = true;
    public bool grounded = false;

    public bool praweWyciagniecieBroni;

    public enum typesOfGuns
    {
        lack,
        Pistol,
        Rifle
    }

    public typesOfGuns currentGunType;

    Rigidbody2D rb;
    public GameObject PRamie;
    public GameObject LRamie;
    public GameObject PReka;
    public GameObject LReka;
    public GameObject PDlon;

    GameObject gun;
    public Transform inventory;

    public GameObject pistol;
    public GameObject rifle;

    Animator anim;
    bool idle;
    bool running;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("Idle", true);

        health = 100;
        armor = 0;

        inventory = transform.Find("Inventory").gameObject.transform;
        foreach (Transform gm in inventory.transform)
        {
            if (gm.tag == "Pistol")
            {
                pistol = gm.gameObject;
                pistol.SetActive(false);
            }
            if (gm.tag == "Rifle")
            {
                rifle = gm.gameObject;
                rifle.SetActive(false);
            }
            else
            {
                Debug.Log("Brak broni w ekwipunku");
            }
        }

        if (currentGunType == typesOfGuns.lack && pistol != null)
        {
            PullPistol();
        }
    }

    void Awake()
    {


    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (health >= 0)
        {
            Aimming();

            SwitchWeapon();

            if (Input.GetButtonDown("Jump") && grounded)
                Jump();

            if (Input.GetButtonDown("Reload"))
            {
                Debug.Log("Reloading...");
                if (currentGunType == typesOfGuns.Pistol)
                    gun.GetComponent<Pistol>().ReloadFun(gun.GetComponent<Pistol>().reloadTime);
                if (currentGunType == typesOfGuns.Rifle)
                    gun.GetComponent<Rifle>().ReloadFun(gun.GetComponent<Rifle>().reloadTime);
            }

            if (Input.GetButton("Fire1"))
            {
                if (currentGunType == typesOfGuns.Pistol && gun.GetComponent<Pistol>().ammoInMag > 0)
                    gun.GetComponent<Pistol>().shot();
                if (currentGunType == typesOfGuns.Rifle && gun.GetComponent<Rifle>().ammoInMag > 0)
                    gun.GetComponent<Rifle>().shot();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if (currentGunType == typesOfGuns.Pistol && gun.GetComponent<Pistol>().ammoInMag > 0)
                    gun.GetComponent<Pistol>().readyForNextShot = true; ;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                dropWeapon();
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Running();
    }

    void Running()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * MovementSpeed * Time.deltaTime, rb.velocity.y);

        /*if (x > 0 && !facingRight)
        {
            Flip ();
        }
        else if (x < 0 && facingRight)
        {
            Flip ();
        } */

        if (x <= -0.1f || x >= 0.1f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
    }

    //Wyciagniecie Broni
    void SwitchWeapon()
    {
        if (Input.GetKeyDown("2") && pistol != null)
        {
            PullPistol();
        }
        if (Input.GetKeyDown("3") && rifle != null)
        {
            PullRifle();
        }
    }

    // Wyciagniecie Pistoletu
    void PullPistol()
    {
        if (currentGunType != typesOfGuns.Pistol)
        {
            if (currentGunType != typesOfGuns.lack)
            {
                gun.transform.parent = inventory;
                gun.SetActive(false);
            }
            pistol.SetActive(true);
            gun = pistol;
            gun.transform.parent = PDlon.transform;

            if (!facingRight && gun.transform.localScale.x < 0)
            {
                Vector3 tScale = gun.transform.localScale;
                tScale.x *= -1;
                gun.transform.localScale = tScale;
                gun.transform.localRotation = Quaternion.Euler(0, 0, 95);
                praweWyciagniecieBroni = false;
            }
            else
            {
                gun.transform.localRotation = Quaternion.Euler(0, 0, 265);
                praweWyciagniecieBroni = true;
            }

            gun.transform.localPosition = new Vector3(0.02f, -0.05f, 0);

            PRamie.transform.localRotation = Quaternion.Euler(0, 0, 173);
            PReka.transform.localRotation = Quaternion.Euler(0, 0, 283);

            LRamie.transform.localRotation = Quaternion.Euler(0, 0, 155);
            LReka.transform.localRotation = Quaternion.Euler(0, 0, 308);

            gun.GetComponent<Pistol>().ReloadFun(0f);
            currentGunType = typesOfGuns.Pistol;
        }
    }

    void PullRifle()
    {
        if (currentGunType != typesOfGuns.Rifle)
        {
            if (currentGunType != typesOfGuns.lack)
            {
                gun.transform.parent = inventory;
                gun.SetActive(false);
            }
            rifle.SetActive(true);
            gun = rifle;
            gun.transform.parent = PDlon.transform;

            if (!facingRight && gun.transform.localScale.x < 0)
            {
                Vector3 tScale = gun.transform.localScale;
                tScale.x *= -1;
                gun.transform.localScale = tScale;
                gun.transform.localRotation = Quaternion.Euler(0, 0, 218);
                praweWyciagniecieBroni = false;
            }
            else
            {
                gun.transform.localRotation = Quaternion.Euler(0, 0, 217);
                praweWyciagniecieBroni = true;
            }

            gun.transform.localPosition = new Vector3(-0.155f, -0.083f, 0);

            PRamie.transform.localRotation = Quaternion.Euler(0, 0, 114);
            PReka.transform.localRotation = Quaternion.Euler(0, 0, 20.25f);

            LRamie.transform.localRotation = Quaternion.Euler(0, 0, 173);
            LReka.transform.localRotation = Quaternion.Euler(0, 0, 290);

            gun.GetComponent<Rifle>().ReloadFun(0f);

            currentGunType = typesOfGuns.Rifle;
        }
    }

    void Aimming()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 relative = mousePos - PRamie.transform.position;
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;

        if (mousePos.x > (PRamie.transform.position.x - 0.0005985945f))
        {
            if (!facingRight)
            {
                Flip();
            }
            if (currentGunType == typesOfGuns.Pistol)
            {
                PRamie.transform.rotation = Quaternion.Euler(0, 0, -angle - 102.5f);
                LRamie.transform.rotation = Quaternion.Euler(0, 0, -angle - 120f);
            }
            if (currentGunType == typesOfGuns.Rifle)
            {
                PRamie.transform.rotation = Quaternion.Euler(0, 0, -angle - 148f);
                LRamie.transform.rotation = Quaternion.Euler(0, 0, -angle - 98f);
            }

        }
        else if (mousePos.x < (PRamie.transform.position.x + 0.0005985945f))
        {
            if (facingRight)
            {
                Flip();
            }
            if (currentGunType == typesOfGuns.Pistol)
            {
                PRamie.transform.rotation = Quaternion.Euler(0, 0, angle - 92.3f);
                LRamie.transform.rotation = Quaternion.Euler(0, 0, angle - 110f);
            }
            if (currentGunType == typesOfGuns.Rifle)
            {
                PRamie.transform.rotation = Quaternion.Euler(0, 0, angle - 148f);
                LRamie.transform.rotation = Quaternion.Euler(0, 0, angle - 98f);
            }
        }
    }

    public string GetHealth()
    {
        if (health > 0)
            return health.ToString();
        else
            return "0";
    }

    public string GetArmor()
    {
        return armor.ToString();
    }

    public string GetAmmo()
    {
        if (currentGunType == typesOfGuns.Pistol)
        {
            return gun.GetComponent<Pistol>().showAmmo();
        }
        if (currentGunType == typesOfGuns.Rifle)
        {
            return gun.GetComponent<Rifle>().showAmmo();
        }
        else
        {
            return "0/0";
        }
    }

    public bool GetFacing()
    {
        return facingRight;
    }

    public void GetDamege(float damage)
    {
        health -= (int)damage;
    }

    void dropWeapon()
    {
        gun.transform.parent = null;
        if (facingRight)
            gun.transform.localPosition += new Vector3(0.5f, 0, 0);
        else
            gun.transform.localPosition += new Vector3(-0.5f, 0, 0);
        if (gun.transform.localScale.x < 0)
        {
            Vector3 tScale = gun.transform.localScale;
            tScale.x *= -1;
            gun.transform.localScale = tScale;
        }
        gun.transform.rotation = Quaternion.Euler(0, 0, 0);
        gun.GetComponent<Dropped>().Drop();
        gun = null;
        currentGunType = typesOfGuns.lack;
    }
}