using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuGameObject : MonoBehaviour {


    private bool paused = false;

    [SerializeField] GameObject pauseMenu;

    private void Start() {
        LoadMenu();
    }

    private void Update() {
        Pause();
    }

    private void LoadMenu() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Pause() {
        if(Input.GetKey(KeyCode.Return) && !paused){
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue(){
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reset() {
        SceneManager.LoadScene("GameplayScene");
        Continue();
    }

    public void GoToCharacterSelect() {
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }

    
    
}
