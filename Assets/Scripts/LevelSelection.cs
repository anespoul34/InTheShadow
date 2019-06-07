using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour {

	[SerializeField] private int level;
	[SerializeField] private GameObject valid;
	[SerializeField] private string lvlName;
	[SerializeField] private Text text;

	public bool isAvailable;

	private Quaternion startRot;
	private bool hasExit;

	void Awake () {
		startRot = transform.rotation;
	}

	void Start () {
		if (level < PlayerPrefs.GetInt("lvl"))
		{
			isAvailable = true;
		} else {
			isAvailable = false;
		}
	}

	void Update () {

		if (isAvailable)
		{
			gameObject.SetActive(false);
			valid.SetActive(true);
		} else if (level == PlayerPrefs.GetInt("lvl")) {
			text.fontSize = 80;
			text.text = lvlName; 
		} else {
			text.fontSize = 270;
			text.text = "?";
		}

		if (hasExit && transform.rotation != startRot)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, startRot, Time.deltaTime * 2f);
			if (transform.rotation == startRot)
			{
				hasExit = false;
			}
		}
	}

	void OnMouseOver()
	{
		hasExit = false;
		if (level <= PlayerPrefs.GetInt("lvl") || isAvailable)
		{
			transform.Rotate(Vector3.forward * 2f);		
			if (Input.GetMouseButton(0))
			{
				if (!EventSystem.current.IsPointerOverGameObject())
					SceneManager.LoadScene(level + 1);
			}
		}
	}

	void OnMouseExit()
	{
		hasExit = true;
	}
}