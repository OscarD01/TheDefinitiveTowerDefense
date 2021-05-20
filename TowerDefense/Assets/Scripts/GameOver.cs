using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour{

    public SceneFader sceneFader;
    void Start(){
        
    }
    void Update(){
        
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
