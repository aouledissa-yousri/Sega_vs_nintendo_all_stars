using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetector : MonoBehaviour {

    private bool groundCollision;

    private void OnCollisionEnter2D(Collision2D collision) {
        CheckGroundCollision(collision);
        CheckDamageCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        CheckDamageCollision(collision);
    }

    private void CheckGroundCollision(Collision2D collision) {
        groundCollision = (collision.gameObject.name == "Ground");
    }

    private void CheckDamageCollision(Collision2D collision) {

        if(collision.gameObject.name == "Character") {
            CharacterMovementManager opponent = collision.collider.gameObject.transform.parent.GetComponent<CharacterMovementManager>();
            if(opponent.IsAttacking()) transform.parent.GetComponent<CharacterPrefabGameObject>().ReduceHealth();
        }

    }

    public bool IsGrounded() {
        return groundCollision;
    }
    
}
