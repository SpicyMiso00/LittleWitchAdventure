using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName="Action", menuName = "SO/Action")]
public class ActionSO : ScriptableObject
{

    public string ActionName;
    public ActorSO Actor;
    public ActionType Type;
    
    [Header("For Chat Type")] 
    public string Content;
    
    [Header("For Question Type")] 
    public string QuestionContent;

    public Choice[] ChoiceContent;
}


public enum ActionType
{
    Chat,
    Question
}


[System.Serializable]
public struct Choice
{
    public string Content;
    public int Score;
    public string QuestionReaction;
}