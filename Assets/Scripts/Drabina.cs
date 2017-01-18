using UnityEngine;
using System.Collections;

public class Drabina : MonoBehaviour
{
    public GameObject player;
    //public bool grounded = false;

    GameObject gameManager;
    GameManager.typeOfGame typGry;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        typGry = gameManager.GetComponent<GameManager>().typGry;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().naDrabinie = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().naDrabinie = false;
        }
    }
}
