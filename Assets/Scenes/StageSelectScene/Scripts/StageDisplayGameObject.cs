using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class StageDisplayGameObject : MonoBehaviour {
    
    [SerializeField] Image stageBackground;
    [SerializeField] TMP_Text stageName;

    public void DisplayStage(GameplayStagePrefabGameObject stagePrefab) {
        stageName.text = stagePrefab.GetStageName();
        stageBackground.sprite = stagePrefab.GetBackgroundImage();
    }

}
