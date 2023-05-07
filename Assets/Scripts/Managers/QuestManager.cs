using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestSO _questData;

    
    
    [Header("Actor GO")] 
    [SerializeField] private TextMeshProUGUI _actorNameTxt;
    [SerializeField] private Image _actorImg;

    [Header("Dependecies")] 
    [SerializeField] private SceneTransitionManager _sceneTransitionManager;
    
    [Header("Other GO")]
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _choice1Btn;
    [SerializeField] private Button _choice2Btn;
    [SerializeField] private Button _quitButtonWin;
    [SerializeField] private Button _quitButtonLose;
    [SerializeField] private Button _restartButton;


    [SerializeField] private TextMeshProUGUI _contentTxt;
    [SerializeField] private TextMeshProUGUI _questionContentTxt;
    [SerializeField] private TextMeshProUGUI _choice1Txt;
    [SerializeField] private TextMeshProUGUI _choice2Txt;

    [SerializeField] private GameObject _chatGO;
    [SerializeField] private GameObject _questionGO;
    [SerializeField] private GameObject _questGO;
    [SerializeField] private GameObject _winGO;
    [SerializeField] private GameObject _loseGo;


    [SerializeField] private Slider _slider;
    
    private int _currentActionIndex;

    private void Awake()
    {
        _nextBtn.onClick.RemoveAllListeners();
        _nextBtn.onClick.AddListener(NextAction);

        _quitButtonLose.onClick.RemoveAllListeners();
        _quitButtonLose.onClick.AddListener(Quit);
        
        _quitButtonWin.onClick.RemoveAllListeners();
        _quitButtonWin.onClick.AddListener(Quit);

        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(Restart);

        
        
    }

    public void StartExecute()
    {
        Debug.Log(StaticVar.Score);
        
        if (StaticVar.Score < 0)
        {
            StaticVar.Score = StaticVar.INITIALSCORE;
            Debug.Log("Masuk" + StaticVar.Score);
            _slider.value = StaticVar.Score; 
        }
        
        
        else
        {
            _slider.value = StaticVar.Score; 
        }
        _questGO.SetActive(true);
        _currentActionIndex = 0;
        ExecuteContent();
    }

    private void Quit()
    {
        _sceneTransitionManager.SwitchSceneHandler(-1);
    }

    private void Restart()
    {
        StaticVar.LevelIndex = 1;
        _sceneTransitionManager.SwitchSceneHandler(1);
    }
    
    

    private void ExecuteContent()
    {
        _actorImg.sprite = _questData.ActionList[_currentActionIndex].Actor.Photo;
        _actorNameTxt.SetText(_questData.ActionList[_currentActionIndex].Actor.Name);
        
        switch (_questData.ActionList[_currentActionIndex].Type)
        {
            case ActionType.Chat:
                Chat(_questData.ActionList[_currentActionIndex].Content);
                break;
            case ActionType.Question:
                Question(_questData.ActionList[_currentActionIndex]);
                break;
        }
    }

    private void Chat(string content)
    {
        _chatGO.SetActive(true);
        _questionGO.SetActive(false);
        
        _contentTxt.SetText(content);
        
    }

    private void Question(ActionSO data)
    {
        _chatGO.SetActive(false);
        _questionGO.SetActive(true);
        
        _questionContentTxt.SetText(data.QuestionContent);
        _choice1Txt.SetText(data.ChoiceContent[0].Content);
        _choice2Txt.SetText(data.ChoiceContent[1].Content);
        
        _choice1Btn.onClick.RemoveAllListeners();
        _choice1Btn.onClick.AddListener(()=>OnAnswerClicked(0));

        _choice2Btn.onClick.RemoveAllListeners();
        _choice2Btn.onClick.AddListener(()=>OnAnswerClicked(1));
        
    }

    private void OnAnswerClicked(int choice)
    {
        Chat(_questData.ActionList[_currentActionIndex].ChoiceContent[choice].QuestionReaction);
        UpdateScore(_questData.ActionList[_currentActionIndex].ChoiceContent[choice].Score);
    }

    private void UpdateScore(int score)
    {
        StaticVar.Score += score;
        
        if (StaticVar.Score > 100)
        {
            StaticVar.Score = 100;
        }
        else if (StaticVar.Score < 0)
        {
            StaticVar.Score = 0;
        }
        _slider.value = StaticVar.Score;
    }

    private void NextAction()
    {
        _currentActionIndex += 1;
        if (_currentActionIndex < _questData.ActionList.Length)
        {
            ExecuteContent();
        }

        else
        
        {
            _nextBtn.interactable = false;
            StaticVar.LevelIndex += 1;
            if (StaticVar.LevelIndex < StaticVar.TOTALSCENE)
            {
                Debug.Log (StaticVar.LevelIndex + "CurrentLevelIndex");
                _sceneTransitionManager.SwitchSceneHandler(StaticVar.LevelIndex);
            }
            else
            {
                Debug.Log(StaticVar.Score + " " + StaticVar.MINIMUMSCORE);
                if (StaticVar.Score < StaticVar.MINIMUMSCORE)
                {
                    Lose();
                }
                else
                {
                    Win();
                }

                StaticVar.Score = -1;
                StaticVar.LevelIndex = 0;
                Debug.Log(StaticVar.Score + " " + StaticVar.MINIMUMSCORE);
            }
            
            
        }
        
    }

    private void Win()
    {
        
        _winGO.SetActive(true);
    }

    private void Lose()
    {
        _loseGo.SetActive(true); 
    }




}
