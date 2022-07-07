using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int GameLevel = 0;    //共有可能な変数（ゲームlevel）
    //LevelLabel.text = "1 level";

    public Text LevelLabel;

    public static int getL()//levelの変数を公開する処理
    {
        return GameLevel;
    }

    public void OnClick()
    {
        GameLevel += 1;
        if (GameLevel > 2) GameLevel = 0;//levelのループ選択処理

        if (GameLevel == 0)
        {
            //level１の処理
            LevelLabel.text = "1 Level";
        }
        if (GameLevel == 1)
        {
            //level２の処理
            LevelLabel.text = "2 Level";
        }
        if (GameLevel == 2)
        {
            //level３の処理
            LevelLabel.text = "3 Level";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelLabel.text = "1 Level";
        GameLevel = 0;//初期化処理
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
