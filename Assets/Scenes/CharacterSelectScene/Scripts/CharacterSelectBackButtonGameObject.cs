using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelectBackButtonGameObject : MonoBehaviour {
    
    [SerializeField] Button backButton;

    void Start() {
        backButton.onClick.AddListener(() => Back());
    }

    void Back() {
        SceneManager.LoadScene("MainMenuScene");
    }

    
    
}
