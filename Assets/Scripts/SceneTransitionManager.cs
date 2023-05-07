
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    private string _nextSceneName;

    private void HandleChangeScene(string name)
    {
        _nextSceneName = name;
        _animator.SetBool("Fade To Black", true);
    }
    
    //called by animation event
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(_nextSceneName);
    }
    
    
    public void SwitchSceneHandler(int index)
    {
        switch (index)
        {

            case -1:
                HandleChangeScene(StaticVar.MAINMENUSCENE);
                break;
            case 0:
                HandleChangeScene(StaticVar.SCENE0);
                break;
            case 1:
                HandleChangeScene(StaticVar.SCENE1);
                break;
            case 2:
                HandleChangeScene(StaticVar.SCENE2);
                break;
            case 3:
                HandleChangeScene(StaticVar.SCENE3);
                break;

        }
        
        
    }
    
    public void HandleFirstScene()
    {
        StaticVar.LevelIndex = 1;
        SwitchSceneHandler(StaticVar.LevelIndex);
    }
    
    
    
}
