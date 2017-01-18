using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float dieTime = 3f;

    public int health = 100;
    int armor = 0;
    public float damage;
    public float attackRate;

    bool facingRight = true;
    public bool grounded;
    bool canAttack = false;
    bool invoked = false;

    Rigidbody2D rb;
    //Animator anim;

    public GameObject target;

    public Rigidbody2D[] partOfBody;
    
    // Use this for initialization
    void Start ()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        partOfBody = GetComponentsInChildren<Rigidbody2D>();

        health = 100;
        armor = 0;

        FoundTarget();
        ShowHP();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(health > 0)
            Move();

        if (health < 0)
            Die();

        if(canAttack && !invoked)
        {
            Invoke("TakeDamage", attackRate);
            invoked = true;
        }
	}

    void LateUpdate()
    {
        ShowHP();
    }

    void FoundTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");         
    }

    void Move()
    {
        float x = 0;

        if (transform.position.x < target.transform.position.x - 0.1f)
            x = 1;
        else if (transform.position.x > target.transform.position.x + 0.1f)
            x = -1;

        if (x > 0 && !facingRight)
		{
			Flip ();
		}
		else if (x < 0 && facingRight)
		{
			Flip ();
		}

        rb.velocity = new Vector2(x * MovementSpeed * Time.deltaTime, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void ShowHP()
    {
        gameObject.GetComponent<HealthBar>().health = (health/100f);
        gameObject.GetComponent<HealthBar>().armor = (armor/100f);
    }

    public void GetDamege(float damage)
    {
        health -= (int)damage;
    }

    void TakeDamage()
    {
        target.GetComponent<GetDamege>().Damage(damage);
        invoked = false;
    }

    void Die()
    {
        //foreach (Rigidbody2D rbb in partOfBody)
        //{
            //rb.isKinematic = false;
        //}
        rb.velocity = Vector2.zero;
        DestroyObject();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
            canAttack = true;
    }

    void DestroyObject()
    {
        Destroy(gameObject, dieTime);
    }
}
