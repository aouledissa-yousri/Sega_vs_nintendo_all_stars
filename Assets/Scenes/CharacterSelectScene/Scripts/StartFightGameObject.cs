using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFightGameObject : MonoBehaviour {
    private float timer = 0.0f;
    private bool isFading = true;
    private readonly float blinkInterval = 1.0f;
    private readonly float fadeDuration = 1f;
    [SerializeField] GameObject imageContainer;
    [SerializeField] Image image;


    public bool IsDisplayed() {
        return imageContainer.activeSelf;
    }




    private void Fade(){
        timer += Time.deltaTime;
        if(timer >= blinkInterval) {
            isFading = !isFading;
            timer = 0.0f;
        } 

        float alpha = isFading ? Mathf.Lerp(0.0f, 1.0f, timer / fadeDuration) : Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
        image.color = new Color(1, 1, 1, alpha);
    }


    public void Display(){
        imageContainer.SetActive(true);
    }

    public void Hide(){
        imageContainer.SetActive(false);
    }

    private void Start() {
        imageContainer.SetActive(false);
    }

    private void Update() {
        if(imageContainer.activeSelf) Fade();
    }
}
