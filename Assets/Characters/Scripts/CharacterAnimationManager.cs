using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour {

    [SerializeField] GameObject character;
    [SerializeField] GameObject aura;

    private void Start() {
        PlayPowerUpAnimation(false);
    }

    public void PlayMoveAnimation(bool status){
        character.GetComponent<Animator>().SetBool("moving", status);

    }

    public void PlayJumpAnimation(bool status){
        character.GetComponent<Animator>().SetBool("jumping", status);
    }

    public void PlayCrouchAnimation(bool status){
        character.GetComponent<Animator>().SetBool("crouching", status);
    }

    public void PlayPowerUpAnimation(bool status) {
        aura.SetActive(status);
        character.GetComponent<Animator>().SetBool("poweringUp", status);

        aura.GetComponent<Transform>().position = new Vector2(character.GetComponent<Transform>().position.x, -1f);
    }

    public void PlayRunAnimation(bool status) {
        character.GetComponent<Animator>().SetBool("running", status);
    }

    public void PlayIdleAttackAnimation(bool status) {
        character.GetComponent<Animator>().SetBool("idleAttacking", status);
    }

    public void PlayCrouchAttackAnimaton(bool status) {
        character.GetComponent<Animator>().SetBool("crouchAttacking", status);
    }

    public void PlayRunAttackAnimation(bool status) {
        character.GetComponent<Animator>().SetBool("runAttacking", status);
    }
    
}
