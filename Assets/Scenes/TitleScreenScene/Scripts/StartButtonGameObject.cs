using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonGameObject : MonoBehaviour {

    public float timer = 0.0f;
    public bool isFading = true;
    public float blinkInterval = 1.0f;
    public float fadeDuration = 1f;

    
    // Update is called once per frame
    void Update() {

        Fade();
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) StartGame();
       
        
    }

    private void Fade(){
        timer += Time.deltaTime;
        if(timer >= blinkInterval) {
            isFading = !isFading;
            timer = 0.0f;
        } 

        float alpha = isFading ? Mathf.Lerp(0.0f, 1.0f, timer / fadeDuration) : Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, alpha);
    }

    private void StartGame() {
        blinkInterval = 0.1f;
        Invoke("LoadScene", 2.0f);
    }

    private void LoadScene(){
        SceneManager.LoadScene("MainMenuScene");
    }

   
}
