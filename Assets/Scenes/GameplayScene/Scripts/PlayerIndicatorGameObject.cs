using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicatorGameObject : MonoBehaviour {

    public int player;
    [SerializeField] GameObject characterThumbnail;

    private void Start() {
        LoadCharacterThumbnail();
    }

    private void LoadCharacterThumbnail() {
        if(player == 1) characterThumbnail.GetComponent<SpriteRenderer>().sprite = CharacterRosterGameObject.selectedCharacterPlayer1.GetCharacterThumbnail();
        if(player == 2) characterThumbnail.GetComponent<SpriteRenderer>().sprite = CharacterRosterGameObject.selectedCharacterPlayer2.GetCharacterThumbnail();
    }
    
}
