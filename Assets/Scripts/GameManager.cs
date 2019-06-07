using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private int lvl;
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject spotlight;
	[SerializeField] private float yPos;
	[SerializeField] private float distSolution;

	private Light lili;
	private bool isActive;

	public List<Validation> objects;
	public static GameManager instance = null;
	public bool win = false;
	public Slider volumeSlider;
	public AudioSource volumeAudio;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		volumeAudio.volume = PlayerPrefs.GetFloat("volume");
	}

	void Start () {
		volumeSlider.value = volumeAudio.volume;
		isActive = false;
		InitializeObject(lvl);
		lili = spotlight.GetComponent<Light>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuDisplayer();
		}
		if (CheckSolution())
		{
			win = true;
		}
		if (win)
		{
			spotlight.transform.rotation = Quaternion.Slerp(spotlight.transform.rotation, Quaternion.Euler(-5.5f, 90, 0), Time.deltaTime);
			lili.intensity = 2.5f;
			if (lili.spotAngle <= 40)
				lili.spotAngle = lili.spotAngle + Time.deltaTime;			
			StartCoroutine(ActiveMenu());
		}
	}

	bool CheckSolution() {
		if (lvl != 1 && lvl != 2)
		{
			float dist = Vector3.Distance(objects[0].transform.position, objects[1].transform.position);
			// Debug.Log("Distance = " + dist);
			if ( dist > distSolution + 0.0005 || dist < distSolution - 0.0005)
			{
				return false;
			}
		}
		foreach(Validation obj in objects)
		{
			Debug.Log(obj.isCorrect);
			if (!obj.isCorrect)
			{
				return false;
			}
		}
		return true;
	}

	void InitializeObject(int lvl)
	{
		if (lvl == 1)
		{
			objects[0].transform.Rotate(Vector3.up * Random.Range(1, 90), Space.World);
			while ((objects[0].transform.localEulerAngles.x >= objects[0].solution.x - objects[0].range && objects[0].transform.localEulerAngles.x <= objects[0].solution.x + objects[0].range)
				&& (objects[0].transform.localEulerAngles.y >= objects[0].solution.y - objects[0].range && objects[0].transform.localEulerAngles.y <= objects[0].solution.y + objects[0].range)
				&& (objects[0].transform.localEulerAngles.z >= objects[0].solution.z - objects[0].range && objects[0].transform.localEulerAngles.z <= objects[0].solution.z + objects[0].range))
			{
				objects[0].transform.Rotate(Vector3.up * Random.Range(1, 90), Space.World);
			}
		}
		else if (lvl == 2)
		{
			objects[0].transform.Rotate(Vector3.up * Random.Range(1, 90), Space.World);
			objects[0].transform.Rotate(Vector3.left * Random.Range(1, 90), Space.World);
			objects[0].transform.Rotate(Vector3.forward * Random.Range(1, 90), Space.World);
			while ((objects[0].transform.localEulerAngles.x >= objects[0].solution.x - objects[0].range && objects[0].transform.localEulerAngles.x <= objects[0].solution.x + objects[0].range)
				&& (objects[0].transform.localEulerAngles.y >= objects[0].solution.y - objects[0].range && objects[0].transform.localEulerAngles.y <= objects[0].solution.y + objects[0].range)
				&& (objects[0].transform.localEulerAngles.z >= objects[0].solution.z - objects[0].range && objects[0].transform.localEulerAngles.z <= objects[0].solution.z + objects[0].range))
			{
					objects[0].transform.Rotate(Vector3.up * Random.Range(1, 90), Space.World);
					objects[0].transform.Rotate(Vector3.left * Random.Range(1, 90), Space.World);
					objects[0].transform.Rotate(Vector3.forward * Random.Range(1, 90), Space.World);
			}			
		} else {			
			foreach(Validation obj in objects)
			{
				obj.transform.Rotate(Vector3.up * Random.Range(1, 90), Space.World);
				obj.transform.Rotate(Vector3.left * Random.Range(1, 90), Space.World);
				obj.transform.Rotate(Vector3.forward * Random.Range(1, 90), Space.World);				
			}
		}
	}

	public void VolumeController(){
		PlayerPrefs.SetFloat("volume", volumeSlider.value);
	 	volumeAudio.volume = volumeSlider.value;
	}	

	public void MenuDisplayer() {
		isActive = isActive ? false : true;
		mainMenu.SetActive(isActive);		
	}

	public void MenuReload() {
		mainMenu.SetActive(false);
	}

	public void ValidLvl(int lvl)
	{
		PlayerPrefs.SetInt("lvl", lvl);
	}

	IEnumerator ActiveMenu()
	{
		yield return new WaitForSeconds(2);

		while(true)
		{
			menu.SetActive(true);
			break;
		}
	}
}