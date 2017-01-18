using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pocisk : MonoBehaviour
{
    List<Transform> visible;
    public float damage = 10;

    void Start()
    {
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy (gameObject);
	}
}
