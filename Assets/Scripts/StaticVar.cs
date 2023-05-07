using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVar
{
    public static int LevelIndex = 0;
    public const string MAINMENUSCENE = "MainMenu";
    public static int Score = -1;
    public const int MINIMUMSCORE = 15;
    public const int INITIALSCORE = 10;
    
    //isi sendiri
    public const string SCENE0 = "CutScene"; //CutScene
    public const string SCENE1 = "MagicShop"; //MagicShop
    public const string SCENE2 = "HutanPinus"; //HutanPinus
    public const string SCENE3 = "DesaPoppy"; //DesaPoppy
    

    public const int TOTALSCENE = 4;
}
