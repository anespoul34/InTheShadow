using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public List<LevelSelection> levels;
	public Slider volumeSlider;
	public AudioSource volumeAudio;

	[SerializeField] private GameObject mainMenu;

	private bool isActive;

	void Start () {
		volumeAudio.volume = PlayerPrefs.GetFloat("volume");
		volumeSlider.value = volumeAudio.volume;
		isActive = false;
	}
	
	void Update () {

		// Debug.Log("Player = " + PlayerPrefs.GetInt("lvl"));
		// Debug.Log("Mode = " + PlayerPrefs.GetInt("test"));

		if (PlayerPrefs.GetInt("test") == 1)
		{
			foreach (LevelSelection lvl in levels)
			{
				lvl.isAvailable = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuDisplayer();
		}
	}

	public void BackHome() {
		SceneManager.LoadScene("Scenes/Menu");
	}

	public void MenuDisplayer() {
		isActive = isActive ? false : true;
		mainMenu.SetActive(isActive);		
	}

	public void LeaveGame () {
		Application.Quit();
	}

	public void VolumeController(){
		PlayerPrefs.SetFloat("volume", volumeSlider.value);
	 	volumeAudio.volume = volumeSlider.value;
	}	
}
