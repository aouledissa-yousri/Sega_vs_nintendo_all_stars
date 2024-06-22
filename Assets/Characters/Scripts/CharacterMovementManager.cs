using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour {

    private bool faceRight;
    private bool moving;
    private bool running;
    private bool jumping;
    private bool crouching = false;
    private bool poweringUp = false;
    public float speed;

    private bool idleAttacking = false;
    private bool crouchAttacking = false;
    private bool runAttacking = false;

    [SerializeField] GameObject character;
    [SerializeField] CharacterPrefabGameObject characterPrefab;
    [SerializeField] CharacterCollisionDetector characterCollisionDetector;
    [SerializeField] CharacterAnimationManager animationManager;
    [SerializeField] CharacterAudioManager characterAudioManager;

    private void Start() {
        SetFacingDirection();
    }

    private void FixedUpdate() {
        if(FightTextGameObject.FightBegan()){
            MoveSideways();
            Jump();
            Crouch();
            Run();
            PowerUp();
            IdleAttack();
            CrouchAttack();
            RunAttack();
        }
    }

    private void MoveSideways() {
        
        
        bool enterCondition1 = (characterPrefab.GetPlayer() == 1 && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)));
        bool enterCondition2 = (characterPrefab.GetPlayer() == 2 && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)));

        if(!crouching && !running && (enterCondition1 || enterCondition2)) {
            float horizontalInput = Input.GetAxis("Horizontal");
            moving = (horizontalInput != 0);
            ReverseFacingDirection(horizontalInput);
            animationManager.PlayMoveAnimation(moving);

            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            GetComponent<CharacterController>().Move(movement * Time.deltaTime * speed);
        }

        if(
            ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) && characterPrefab.GetPlayer() == 1) ||
            ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && characterPrefab.GetPlayer() == 2)
        ) {
            moving = false;
            animationManager.PlayMoveAnimation(moving);
        }
        
        
    }

    private void Run() {

        float horizontalInput = Input.GetAxis("Horizontal");
        
        if((characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.V)) || (characterPrefab.GetPlayer() == 2  && Input.GetKey(KeyCode.P))) running = (moving && horizontalInput != 0 );
        else running = false;

        animationManager.PlayRunAnimation(running);

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(running) {
            GetComponent<CharacterController>().Move(movement * Time.deltaTime * speed * 5f);
            if(Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.P)) characterAudioManager.PlayRunSound();
        }

        if(Input.GetKeyUp(KeyCode.V) || Input.GetKeyUp(KeyCode.P)) characterAudioManager.StopRunSound();

    }

    private void Jump(){

        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0, 0);
        if(verticalInput > 0) movement = new Vector2(Input.GetAxis("Horizontal"), 1f);
        else movement = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if((characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.UpArrow)) || (characterPrefab.GetPlayer() == 2  && Input.GetKey(KeyCode.W))) jumping = (verticalInput > 0 && characterCollisionDetector.IsGrounded());
        else jumping = false;

        animationManager.PlayJumpAnimation(jumping);

        if(jumping) {
            GetComponent<CharacterController>().Move(movement * 7f * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) characterAudioManager.PlayJumpSound();
        }


    }

    private void Crouch(){
        if((characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.DownArrow)) || (characterPrefab.GetPlayer() == 2  && Input.GetKey(KeyCode.S))) crouching = (Input.GetAxis("Vertical") < 0 && characterCollisionDetector.IsGrounded() && !poweringUp);
        else crouching = false;

        GetComponent<CharacterController>().enabled = !crouching && !poweringUp;
        animationManager.PlayCrouchAnimation(crouching);


    }

    private void PowerUp() {

        if((characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.Z)) || (characterPrefab.GetPlayer() == 2  && Input.GetKey(KeyCode.U))) poweringUp = (characterCollisionDetector.IsGrounded() && !moving && !jumping && !crouching);
        else poweringUp = false;

        GetComponent<CharacterController>().enabled = !poweringUp && !crouching;
        animationManager.PlayPowerUpAnimation(poweringUp);
        if(poweringUp && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.U))) characterAudioManager.PlayPowerUpSound();
        if(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.U)) characterAudioManager.StopPowerUpSound();


    }

    private void IdleAttack() {
        if((characterPrefab.GetPlayer() == 1 && Input.GetKeyDown(KeyCode.X)) || (characterPrefab.GetPlayer() == 2 && Input.GetKeyDown(KeyCode.I))) idleAttacking = (characterCollisionDetector.IsGrounded() && !moving && !jumping && !crouching);
        else idleAttacking = false;

        animationManager.PlayIdleAttackAnimation(idleAttacking);

        if(idleAttacking) characterAudioManager.PlayIdleAttackSound();
    }

    private void CrouchAttack() {
        if(characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.DownArrow)) {
            crouchAttacking = (characterCollisionDetector.IsGrounded() && !moving && !jumping && crouching);
            animationManager.PlayCrouchAttackAnimaton(crouchAttacking && Input.GetKeyDown(KeyCode.X));
        } else if(characterPrefab.GetPlayer() == 2 && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.S)) {
            crouchAttacking = (characterCollisionDetector.IsGrounded() && !moving && !jumping && crouching);
            animationManager.PlayCrouchAttackAnimaton(crouchAttacking && Input.GetKeyDown(KeyCode.I));
        }
        
        else crouchAttacking = false;

        if(crouchAttacking) characterAudioManager.PlayCrouchAttackSound();
        

    }

    private void RunAttack() {
        if(characterPrefab.GetPlayer() == 1 && Input.GetKey(KeyCode.X) || (characterPrefab.GetPlayer() == 2 && Input.GetKey(KeyCode.I))) runAttacking = moving || running;
        else runAttacking = false;

        animationManager.PlayRunAttackAnimation(runAttacking);

        if(runAttacking) characterAudioManager.PlayRunAttackSound();

    }

    private void SetFacingDirection() {
        if(characterPrefab.GetPlayer() == 1) {
            faceRight = true;
            character.GetComponent<SpriteRenderer>().flipX = faceRight;
        }
    }


    private void ReverseFacingDirection(float horizontalInput){
        if(moving){
            if(horizontalInput > 0) faceRight = true;
            else faceRight = false;
        }

        character.GetComponent<SpriteRenderer>().flipX = faceRight;
    }

    public bool PoweringUp() {
        return poweringUp;
    }

    public bool IsAttacking() {
        return idleAttacking || runAttacking || crouchAttacking;
    }

}
