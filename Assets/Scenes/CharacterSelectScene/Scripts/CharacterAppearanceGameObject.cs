using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterAppearanceGameObject : MonoBehaviour {

    [SerializeField] TMP_Text characterName;
    [SerializeField] Image characterImage;

    private void Start() {
        IntializeCharacterAppearanceGameObject();
    }

    private void IntializeCharacterAppearanceGameObject() {
        characterName.text = "";
    }

    public void DisplaySelectedCharacter(CharacterThumbnailGameObject characterThumbnailGameObject) {
        characterName.text = characterThumbnailGameObject.GetName();
        characterImage.sprite = characterThumbnailGameObject.GetAppearance();
        characterImage.color = Color.white;
    }

    public void RemoveDisplayedCharacter(){
        characterName.text = "";
        characterImage.sprite = null;
        characterImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public bool IsCharacterSelected(){
        return characterName.text != "";
    }
    
}
