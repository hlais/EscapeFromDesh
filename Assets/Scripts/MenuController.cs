using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuController : MonoBehaviour
{

	public GameObject audioOnIcon;// this is so we can drag audio icon(from hirachy) to this feild
	public GameObject audioOffIcon;// this is so we can drag audio icon to this filed 
	public Text txtBestScore;//we need a reference to the best score filed / then we would use the playerprefs class to store the best score. 

	// Use this for initialization
	void Start()
	{
		SetSoundState(); // putting this code at the beging basically remembers from the previous play if the volume is off or on 
		txtBestScore.text = PlayerPrefs.GetFloat("BestScore", 0).ToString("0.0"); /// we used ToString function. casted it. 0.0 would make it a float

	

	}

	// Update is called once per frame
	void Update()
	{
			if (Input.GetKey("escape")) // if input key code is escape. it would releaod screen from title screeen 
		{
			Application.Quit();
			Debug.Log("quite game");
       
		}

	}
	public void StartGame()
	{
		SceneManager.LoadScene("Game"); //this would reload the screen. This script is assigned to an object. // on unity we pressed on the OnCLick the + to add button. 
	}

	public void ToggleSounds() // we going to get the current state of the toggleSounds
	{
		//logic beloow if not muted
		if (PlayerPrefs.GetInt("Muted", 0) == 0) // player pref basiclly remembers the player setting and keeps them throught the game. eg mute sounds
		{
			PlayerPrefs.SetInt("Muted", 1); // we will set muted to 1
		}
		else
		{
			PlayerPrefs.SetInt("Muted", 0); //if its already set we would set player preferense to 0
		}

		SetSoundState();/// toggle the state of the music and remember it for future use // acutually turing the sound on and off
	}

	private void SetSoundState()
	{
		if (PlayerPrefs.GetInt("Muted", 0) == 0)
		{
			AudioListener.volume = 1; //this access the audio class. and ==1 turns it on
			audioOnIcon.SetActive(true);
			audioOffIcon.SetActive(false);
		}
		else
		{
			AudioListener.volume = 0; //this access the audio class. and ==1 turns it on
			audioOnIcon.SetActive(false); // this is changing the state of the image
			audioOffIcon.SetActive(true);
		}

	}
}

		
	