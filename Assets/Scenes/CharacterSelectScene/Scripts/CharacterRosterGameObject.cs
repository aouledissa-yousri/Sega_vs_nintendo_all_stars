using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterRosterGameObject : MonoBehaviour {

    [SerializeField] CharacterThumbnailGameObject[] characterThumbnailGameObjects;
    [SerializeField] PlayerGameObject player1;
    [SerializeField] PlayerGameObject player2;
    [SerializeField] StartFightGameObject startFight;


    public static CharacterPrefabGameObject selectedCharacterPlayer1;
    public static CharacterPrefabGameObject selectedCharacterPlayer2;

    private float lastEnterPress = 0f;

    private void DetectDoubleEnterKeyPress(){
        if(Input.GetKeyDown(KeyCode.Return)){
            float currentEnterPress = Time.time;
            float timeSinceLastEnterPress = currentEnterPress - lastEnterPress;

            if(timeSinceLastEnterPress <= 0.2f) GoToStageSelect();
            lastEnterPress = currentEnterPress;
        }
        

    }

    public void SelectCharacter(int index){
        if(!player1.IsCharacterSelected()) {
            player1.DisplaySelectedCharacter(characterThumbnailGameObjects[index]);
            selectedCharacterPlayer1 = characterThumbnailGameObjects[index].GetCharacterPrefab();
        }else if(!player2.IsCharacterSelected()) {
            player2.DisplaySelectedCharacter(characterThumbnailGameObjects[index]);
            selectedCharacterPlayer2 = characterThumbnailGameObjects[index].GetCharacterPrefab();
        }
    }

    public void UnselectCharacter() {
        if(Input.GetKeyDown(KeyCode.C)) {
            if(player2.IsCharacterSelected()) player2.RemoveSelectedCharacter();
            else if(player1.IsCharacterSelected()) player1.RemoveSelectedCharacter();
        }
    }

    private void DisableCharacterSelect() {
        if(player1.IsCharacterSelected() && player2.IsCharacterSelected()) foreach(CharacterThumbnailGameObject characterThumbnailGameObject in characterThumbnailGameObjects) characterThumbnailGameObject.Disable();
    }

    
    private void EnableCharacterSelect() {
        if(!player1.IsCharacterSelected() || !player2.IsCharacterSelected()) foreach(CharacterThumbnailGameObject characterThumbnailGameObject in characterThumbnailGameObjects) characterThumbnailGameObject.Enable();
    }

    private void ReactivateCharacterMenu() {
        if(Input.GetKeyDown(KeyCode.C) && player1.IsCharacterSelected() && player2.IsCharacterSelected()) characterThumbnailGameObjects[0].Focus();
    }

    private void DisplayStartFight() {
        if(player1.IsCharacterSelected() && player2.IsCharacterSelected()) startFight.Display();
    }

    private void HideStartFight(){
        if(!player1.IsCharacterSelected() || !player2.IsCharacterSelected()) startFight.Hide();
    }

    private void GoToStageSelect(){
        if(startFight.IsDisplayed()) SceneManager.LoadScene("StageSelectScene");
    }

    void Update(){
        ReactivateCharacterMenu();
        UnselectCharacter();
        DisableCharacterSelect();
        EnableCharacterSelect();
        DisplayStartFight();
        HideStartFight();
        DetectDoubleEnterKeyPress();
    }

    

}
