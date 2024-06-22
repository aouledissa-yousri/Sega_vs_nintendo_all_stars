using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StageSelectBackButtonGameObject : MonoBehaviour
{
    [SerializeField] Button backButton;

    void Start() {
        backButton.onClick.AddListener(() => Back());
    }

    void Back() {
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
