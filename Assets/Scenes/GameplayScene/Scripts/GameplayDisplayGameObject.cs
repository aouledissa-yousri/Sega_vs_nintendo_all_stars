using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayDisplayGameObject : MonoBehaviour {

    private GameplayStagePrefabGameObject stagePrefab;
    private CharacterPrefabGameObject characterPrefabPlayer1;
    private CharacterPrefabGameObject characterPrefabPlayer2;


    private void Start() {
        LoadStagePrefab();
        LoadCharacterPrefabs();
    }

    private void LoadStagePrefab(){
        stagePrefab = StageThumbnailGameObject.selectedStagePrefab;
        GameplayStagePrefabGameObject selectedStage = Instantiate(stagePrefab, transform.position, transform.rotation);
        selectedStage.transform.SetParent(GameObject.Find("GameplayDisplayGameObject").transform, false);
        selectedStage.transform.SetSiblingIndex(0);
    }


    private void LoadCharacterPrefabs(){
        characterPrefabPlayer1 = CharacterRosterGameObject.selectedCharacterPlayer1;

        characterPrefabPlayer2 = CharacterRosterGameObject.selectedCharacterPlayer2;

        CharacterPrefabGameObject character1 = Instantiate(characterPrefabPlayer1, transform.position, transform.rotation);
        character1.SetPlayer(1);
        character1.InitializeBars(
            GameObject.FindGameObjectWithTag("Player 1 Health Bar").GetComponent<Image>(),
            GameObject.FindGameObjectWithTag("Player 1 Mana Bar").GetComponent<Image>()
        );
        character1.transform.SetParent(GameObject.Find("GameplayDisplayGameObject").transform, false);


        CharacterPrefabGameObject character2 = Instantiate(characterPrefabPlayer2, transform.position, transform.rotation);
        character2.SetPlayer(2);
        character2.InitializeBars(
            GameObject.FindGameObjectWithTag("Player 2 Health Bar").GetComponent<Image>(),
            GameObject.FindGameObjectWithTag("Player 2 Mana Bar").GetComponent<Image>()
        );
        character2.transform.SetParent(GameObject.Find("GameplayDisplayGameObject").transform, false);

    }

    
}
