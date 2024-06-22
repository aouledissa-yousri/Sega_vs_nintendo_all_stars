using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayAudioManagerGameObject : MonoBehaviour {

    
    [SerializeField] AudioSource music;

    private GameplayStagePrefabGameObject stagePrefab;
    

    private void Start() {
        LoadStagePrefab();
        StartMusic();
    }

    private void StartMusic(){
        music.clip = stagePrefab.GetBackgroundMusic();
        music.Play();
    }

    public void LoadStagePrefab(){
        stagePrefab = StageThumbnailGameObject.selectedStagePrefab;
    }
}
