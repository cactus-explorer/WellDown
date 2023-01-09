using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	private PlayerScript player;
	Text text;
	bool paused;
	public GameObject pauseMenu;


	public void ResumeGame()
	{
		paused = false;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void GoToMainMenu()
	{
		Destroy(player.gameObject.transform.parent.gameObject);
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");

	}
	public void QuitGame()
	{
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		paused = false;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find("Player").GetComponent<PlayerScript>();
		//print(player.bulletCounter);
		text.text = ("Health: " + player.health + "/" + player.maxHealth +
            "\nAmmo Count: " + player.bulletCounter + "/" + player.bulletMax +
            "\nCombo: " + player.combo +
            "\nGems: " + player.gems +
			"\nBonus Health: " + player.bonusHealth + "/4" +
			"\nLevel " + player.area + "-" + player.level +
            "\nGun: " + player.currentGun);
        //print(text.text);
		if(Input.GetKeyDown(KeyCode.Escape))
        {
			paused = !paused;
			if (!paused)
			{
				Time.timeScale = 1;
				pauseMenu.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			if (paused)
			{
				Time.timeScale = 0;
				pauseMenu.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}
}
