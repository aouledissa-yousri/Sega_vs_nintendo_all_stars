using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameObject : MonoBehaviour {
    [SerializeField] CharacterAppearanceGameObject selectedCharacterAppearance;
    private CharacterThumbnailGameObject selectedCharacter;

    public void DisplaySelectedCharacter(CharacterThumbnailGameObject characterThumbnailGameObject) {
        selectedCharacterAppearance.DisplaySelectedCharacter(characterThumbnailGameObject);
        selectedCharacter = characterThumbnailGameObject;
        selectedCharacter.SelectCharacter();
    }

    public void RemoveSelectedCharacter() {
        selectedCharacterAppearance.RemoveDisplayedCharacter();
        selectedCharacter.UnselectCharacter();
        selectedCharacter = null;
    }

    public bool IsCharacterSelected(){
        return selectedCharacterAppearance.IsCharacterSelected();
    }
}
