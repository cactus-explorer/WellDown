using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void HandleInputData(int val) {
        if (val == 1) {
            Screen.SetResolution(640, 360, Screen.fullScreen);
        }
        if (val == 2) {
            Screen.SetResolution(854, 480, Screen.fullScreen);
        }
        if (val == 3) {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
        if (val == 4) {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        if (val == 51) {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
        }
        if (val == 6) {
            Screen.SetResolution(3840, 2160, Screen.fullScreen);
        }
    }

    public string underGroundScene;
    public GameObject fullScreenCheck;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(underGroundScene);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void FullScreen(bool Status) {
        Screen.fullScreen = fullScreenCheck.GetComponent<Toggle>().isOn;
    }
}
