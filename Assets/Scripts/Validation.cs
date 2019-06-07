using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation : MonoBehaviour {

	[SerializeField] public Vector3 solution;
	[SerializeField] public float range;
	
	public bool isCorrect;

	void Start ()
	{
		isCorrect = false;
	}

	void Update () 
	{
		float x = transform.localRotation.eulerAngles.x;
		float y = transform.localRotation.eulerAngles.y;
		float z = transform.localRotation.eulerAngles.z;

		// Debug.Log("X = " + x);
		// Debug.Log("Y = " + y);
		// Debug.Log("Z = " + z);

		isCorrect = false;
		if (!GameManager.instance.win)
		{
			if ((x >= solution.x - range && x <= solution.x + range) 
			&& (y >= solution.y - range && y <= solution.y + range) 
			&& (z >= solution.z - range && z <= solution.z + range))
			{
				isCorrect = true;
			}
		} else {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(solution), Time.deltaTime * 10);
		}
	}
}