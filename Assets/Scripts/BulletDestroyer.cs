using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet")
		{
			Destroy (coll.gameObject);
		}
	}
}
