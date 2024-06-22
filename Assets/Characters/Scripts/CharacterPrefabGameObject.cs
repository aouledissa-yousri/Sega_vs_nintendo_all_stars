using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterPrefabGameObject : MonoBehaviour {
   private bool facingRight;
   private int player;

   [SerializeField] Sprite characterThumbnail;
   [SerializeField] CharacterMovementManager movementManager;
   [SerializeField] string characterName;

   private Image healthBar;
   private Image manaBar;

   private float health = 100;
   private float mana = 0;
   private int rage = 0;


   private void Start(){
    LoadPrefab();
   }

   private void Update() {
      PowerUp();
   }

   public Sprite GetCharacterThumbnail() {
      return characterThumbnail;
   }

   private void LoadPrefab(){
    SetFacingDirection(true);
   }

   private void SetFacingDirection(bool rightDirection){
    facingRight = rightDirection;
   }

   private void PowerUp(){
      if(movementManager.PoweringUp() && mana < 100) {
         mana++;
         manaBar.fillAmount = mana/100;
      }
   }

   public void ReduceHealth() {
      if(health <= 0) SceneManager.LoadScene("MainMenuScene");
         
      health -= 0.1f;
      healthBar.fillAmount = health/100;

   }

   public void SetPlayer(int player) {
      this.player = player;
   }

   public int GetPlayer() {
      return player;
   }


   public void InitializeBars(Image healthBar, Image manaBar) {
      this.healthBar = healthBar;
      this.manaBar = manaBar;
   }



}
