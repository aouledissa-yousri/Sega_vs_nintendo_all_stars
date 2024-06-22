using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterThumbnailGameObject : MonoBehaviour {

    [SerializeField] Button characterThumbnail;
    [SerializeField] string characterName;
    [SerializeField] Sprite characterAppearance;
    [SerializeField] Sprite characterThumbnailImage;

    [SerializeField] CharacterPrefabGameObject characterPrefab;

    public string GetName() {
        return characterName;
    }

    public Sprite GetAppearance() {
        return characterAppearance;
    }

    public CharacterPrefabGameObject GetCharacterPrefab() {
        return characterPrefab;
    }
    
    public void SelectCharacter() {
        ColorBlock colors = characterThumbnail.colors;
        ColorUtility.TryParseHtmlString( "#29CD31" , out Color selectCharacter);
        colors.normalColor = selectCharacter;
        colors.highlightedColor = selectCharacter;
        characterThumbnail.colors = colors;
    }

    public void UnselectCharacter() {
        ColorBlock colors = characterThumbnail.colors;
        ColorUtility.TryParseHtmlString( "#FFFFFF" , out Color normalColor);
        ColorUtility.TryParseHtmlString( "#CD2828" , out Color highlightColor);
        colors.normalColor = normalColor;
        colors.highlightedColor = highlightColor;
        characterThumbnail.colors = colors;
    }

    public void Disable(){
        characterThumbnail.interactable = false;
    }

    public void Enable(){
        characterThumbnail.interactable = true;
    }

    public void Focus(){
        characterThumbnail.Select();
    }


}
