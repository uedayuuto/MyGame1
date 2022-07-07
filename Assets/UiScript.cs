using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI系を取得するために必要

public class UiScript : MonoBehaviour
{
    public static int score = 0;//共有可能な変数を生成する

    GameObject scoreText;
    GameObject GameOverText;
    //GameObject Skill;
    

    //Slider SkillPoint;

    
    public static int getA()
    {
        return score;
    }

    public void GameOver()  //ゲームオーバーの関数を受け取ったときにテキストをがめおべらにする
    {
        this.GameOverText.GetComponent<Text>().text = "GameOver";
        
    }
    public void AddScore()  //スコアが加算されるときに使われる関数を生成
    {
        score += 10;//スコアをプラスする

        
    }
    public void AddScoreBoss()//ボスのスコア分（通常）
    {
        score += 20;
    }
    public void AddScoreBossPlas()//ボスのスコア分（クリティカル）
    {
        score += 40;
    }
    public void BossDedPoint()//ボスを倒したときのボーナススコア
    {
        score += 1000;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.GameOverText = GameObject.Find("GameOver");
        //SkillPoint = GetComponent<"">();
        //GameObject SkillPoint = GameObject.Find("PlayerSkill");//プレイヤーのスキルバーを取得する
        //Slider SkillPoint;
        score = 0;//スコアのリセット処理
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");  //テキスト（Score）+スコアを表示する
    }
}
