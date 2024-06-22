using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTextGameObject : MonoBehaviour {

    [SerializeField] GameObject fightText;
    [SerializeField] FightTextAudioManager fightVoiceAudioManager;

    private static bool fightBegan = false;
    private void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;

        InitializeFightText();
        fightVoiceAudioManager.PlayReadyFightSound();
        Invoke("RevealStartFightText", 3.0f);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        FightTextGameObject.fightBegan = false;
    }

    private void InitializeFightText() {
        fightText.SetActive(false);
    }

    public static bool FightBegan() {
        return FightTextGameObject.fightBegan;
    }
    

    private void RevealStartFightText() {
        fightText.SetActive(true);
        FightTextGameObject.fightBegan = true;
        Invoke("HideStartFightText", 1.5f);
    }

    private void HideStartFightText() {
        fightText.SetActive(false);
    }
}
