using UnityEngine;
using System.Collections;

public class GroundColliderMulti : MonoBehaviour
{
	public GameObject player;
    public bool grounded = false;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        if(GameObject.FindGameObjectWithTag("Player"))
            player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectWithTag("PlayerMulti"))
            player = player = GameObject.FindGameObjectWithTag("PlayerMulti");

        Debug.Log("This Collider2D can be triggered");
    }

    /*void OnTriggerEnter2D()
	{
		player.GetComponent<PlayerMovement>().grounded = true;
		grounded = true;
	}*/

    void OnTriggerStay2D()
    {
        player.GetComponent<PlayerMulti>().grounded = true;
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        player.GetComponent<PlayerMulti>().grounded = false;
        grounded = false;
    }
}

