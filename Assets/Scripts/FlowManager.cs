using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager : MonoBehaviour
{
   [SerializeField] private GameObject flowManager;

   public static FlowManager Instance {get; private set;}

   private string sceneName;

   private void Awake()
   {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
   }

    public void SetSceneToLoad(string scene){
        sceneName = scene;
    }

    public string GetSceneToLoad(){
        return sceneName;
    }

    public void LoadLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

   public void GotoInit()
   {
    LoadLoadingScreen();
    SceneManager.LoadScene("Init");
   }

    public void GotoMenu()
   {
    LoadLoadingScreen();
    SceneManager.LoadScene("Menu");
   }

    public void GotoInGame()
   {
    LoadLoadingScreen();
    SceneManager.LoadScene("InGame");
   }

}
