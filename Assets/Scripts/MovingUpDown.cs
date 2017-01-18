using UnityEngine;
using System.Collections;

public class MovingUpDown : MonoBehaviour
{
    public float speed = 0.2f;
    public float wait = 1;
    bool floatup;

	// Use this for initialization
	void Start ()
    {
        floatup = false;
	}

    // Update is called once per frame
    void Update()
    {
         //Floating();
	}

    public void Floating()
    {
        if (floatup)
        {
            StartCoroutine(FloatingUp());
        }
        else if (!floatup)
        {
            StartCoroutine(FloatingDown());
        }
    }

    IEnumerator FloatingUp()
    {
        transform.position += new Vector3(0, (speed * Time.deltaTime), 0);
        yield return new WaitForSeconds(wait);
        floatup = false;
    }

    IEnumerator FloatingDown()
    {
        transform.position -= new Vector3(0, (speed * Time.deltaTime), 0);
        yield return new WaitForSeconds(wait);
        floatup = true;
    }
}
