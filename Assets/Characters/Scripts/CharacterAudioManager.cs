using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource voiceAudioSource;
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] AudioSource runAudio;
    [SerializeField] AudioSource powerUpAudio;
    [SerializeField] AudioSource idleAttackAudio;
    [SerializeField] AudioSource crouchAttackAudio;
    [SerializeField] AudioSource runAttackAudio;


    public void PlayJumpSound() {
        StopAllSounds();
        jumpAudio.Play();
    }

    public void PlayRunSound() {
        StopAllSounds();
        runAudio.Play();
    }

    public void PlayPowerUpSound() {
        StopAllSounds();
        powerUpAudio.Play();
    }

    public void PlayIdleAttackSound() {
        StopAllSounds();
        idleAttackAudio.Play();
    }

    public void PlayCrouchAttackSound() {
        StopAllSounds();
        crouchAttackAudio.Play();
    }

    public void PlayRunAttackSound() {
        if(!runAttackAudio.isPlaying) {
            StopAllSounds();
            runAttackAudio.Play();
        }
    }

    private void StopJumpSound() {
        jumpAudio.Stop();
    }

    public void StopRunSound() {
        runAudio.Stop();
    }

    public void StopPowerUpSound() {
        powerUpAudio.Stop();
    }

    public void StopIdleAttackSound() {
        idleAttackAudio.Stop();
    }

    public void StopCrouchAttackSound() {
        crouchAttackAudio.Stop();
    }

    public void StopRunAttackSound() {
        runAttackAudio.Stop();
    }

    private void StopAllSounds() {
        StopJumpSound();
        StopPowerUpSound();
        StopRunSound();
        StopIdleAttackSound();
        StopCrouchAttackSound();
        StopRunAttackSound();
    }

}
