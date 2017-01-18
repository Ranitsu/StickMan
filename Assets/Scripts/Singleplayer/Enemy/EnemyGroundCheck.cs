using UnityEngine;
using System.Collections;

public class EnemyGroundCheck : MonoBehaviour
{
    public GameObject enemy;
    public bool grounded = false;

    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Player");
    }

    /*void OnTriggerEnter2D()
	{
		player.GetComponent<PlayerMovement>().grounded = true;
		grounded = true;
	}*/

    void OnTriggerStay2D()
    {
        enemy.GetComponent<Zombie>().grounded = true;
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        enemy.GetComponent<Zombie>().grounded = false;
        grounded = false;
    }
}
