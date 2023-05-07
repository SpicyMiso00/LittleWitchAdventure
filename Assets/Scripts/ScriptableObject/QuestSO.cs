using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName="Quest", menuName = "SO/Quest")]
public class QuestSO : ScriptableObject
{


    public string QuestName;
    public int InitialScore;
    public int MinimumScore;
    
    public ActionSO[] ActionList;

}
