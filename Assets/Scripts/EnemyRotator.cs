using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public float tumble;

	void Start ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * tumble;
	}
}
