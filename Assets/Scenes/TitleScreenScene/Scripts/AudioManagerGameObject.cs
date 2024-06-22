using UnityEngine;

public class AudioManagerGameObject : MonoBehaviour {
    [Header("---------Audio Source--------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip soundEffect;

    private void Start() {
        StartBackgroundMusic();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) LaunchClickSfx();
    }


    private void LaunchClickSfx() {
        sfx.clip = soundEffect;
        sfx.Play();
    }

    private void StartBackgroundMusic() {
        music.clip = background;
        music.Play();
    }
}
