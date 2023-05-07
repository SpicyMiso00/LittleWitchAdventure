using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneTransitionManager _sceneTransitionManager;
    
   public void PlayGame ()
    {
        _sceneTransitionManager.SwitchSceneHandler(StaticVar.LevelIndex);
    }


   public void QuitGame()
    {
        Application.Quit();
    }
}