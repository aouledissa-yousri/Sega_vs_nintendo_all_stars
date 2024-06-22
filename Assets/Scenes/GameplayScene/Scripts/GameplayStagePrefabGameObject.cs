using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStagePrefabGameObject : MonoBehaviour {

    [SerializeField] string stageName;
    [SerializeField] Sprite backgroundImage;
    [SerializeField] AudioClip backgroundMusic;


    public string GetStageName(){
        return stageName;
    }

    public Sprite GetBackgroundImage(){
        return backgroundImage;
    }

    public AudioClip GetBackgroundMusic(){
        return backgroundMusic;
    }

    
}
