using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCameraPos : MonoBehaviour {

	private int lvl;
	private int maxLvl;

	void Awake () {
		maxLvl = 3;
		lvl = PlayerPrefs.GetInt("lvl");
	}
	
	void Start () {
		if (lvl > maxLvl)
			lvl = maxLvl;
		transform.position = new Vector3(((lvl - 1) * 3) - 6, transform.position.y, transform.position.z);
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.A))
		{
			if (transform.position.x > -6) {
				transform.position = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
			}
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			if (transform.position.x < 3) {
				transform.position = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
			}
		}
	}
}
