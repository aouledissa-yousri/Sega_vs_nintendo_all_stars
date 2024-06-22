using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageThumbnailGameObject : MonoBehaviour {


    public static GameplayStagePrefabGameObject selectedStagePrefab;
    [SerializeField] GameplayStagePrefabGameObject stagePrefab;

    public void DisplayStage(StageDisplayGameObject stageDisplayGameObject) {
        stageDisplayGameObject.DisplayStage(stagePrefab);
    }

    public void LoadStagePrefab(){
        StageThumbnailGameObject.selectedStagePrefab = stagePrefab;
    }

    public void StartFight(){
        LoadStagePrefab();
        SceneManager.LoadScene("GameplayScene");
    }
    
}
