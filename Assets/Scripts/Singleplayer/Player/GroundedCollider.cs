using UnityEngine;
using System.Collections;

public class GroundedCollider : MonoBehaviour
{
	public GameObject player;
	//public bool grounded = false;

    GameObject gameManager;
    GameManager.typeOfGame typGry;

    void Start()
	{
        Debug.Log("This Collider2D can be triggered");
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        typGry = gameManager.GetComponent<GameManager>().typGry;
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void OnTriggerStay2D()
	{
		//player.GetComponent<Player>().grounded = true;
        if (typGry == GameManager.typeOfGame.multi)
            player.GetComponent<PlayerMulti>().grounded = true;
        else
            player.GetComponent<Player>().grounded = true;
    }

	void OnTriggerExit2D()
	{
        //player.GetComponent<Player>().grounded = false;
        if (typGry == GameManager.typeOfGame.multi)
            player.GetComponent<PlayerMulti>().grounded = false;
        else
            player.GetComponent<Player>().grounded = false;
    }
}
