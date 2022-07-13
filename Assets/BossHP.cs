using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public GameObject BossDA;
    //public GameObject BossLabel;
    public GameObject GameOver;
    public GameObject Canvas;
    public GameObject gameGuide;
    public GameObject koukaon;

    int BossMaxHP;//ボスの最大HPを定義する変数
    float Critical;

    public AudioClip BossDed;
    AudioSource audioSource;

    Slider HP;//ボスのHP関係

    // Start is called before the first frame update
    void Start()
    {
        BossMaxHP = Level.getL();   //タイトル画面の難易度から現在のレベルを取得する
        HP = GetComponent<Slider>();    //スライダーの情報を取得する

        //レベルごとのBOSSの最大HPを設定する処理
        if (BossMaxHP == 0) HP.maxValue = 1000;
        if (BossMaxHP == 1) HP.maxValue = 1500;
        if (BossMaxHP == 2) HP.maxValue = 2500;
        HP.value = HP.maxValue;     //最大HPに回復させておく（初期化設定）
        gameObject.SetActive(false);//見えないようにする
    }

    public void HPhyouji()//ボス召喚時にHPバーを表示させる処理
    {
        gameObject.SetActive(true);//見える
        gameGuide.GetComponent<GameGuide>().DasuYO();
    }

    public void Auti()//プレイヤーの弾を食らったときの処理　普通弾の場合
    {
        Critical = Random.Range(1f, 5f + 1f);    //1～5のランダム生成　５分の１でクリティカル発動
        if (Critical < 5)
        {
            HP.value -= 10; //通常
            Canvas.GetComponent<UiScript>().AddScoreBoss(); //スコア加算
        }
        else
        {
            //Debug.Log("KUKUK");
            HP.value -= 20; //クリティカル
            Canvas.GetComponent<UiScript>().AddScoreBossPlas(); //スコア加算
        }

        if (HP.value <= 0)//HPがなくなったとき
        {
            Debug.Log("Boss is Ded");
            Canvas.GetComponent<UiScript>().BossDedPoint(); //ボスを倒したご褒美　スコア加算
            BossDA.GetComponent<Boss>().BossOwari();//ボスを消す処理
            //スコア画面に移動させる処理をする
            GameOver.GetComponent<GameOver>().GameClear();//ゲームクリア処理をする

            gameObject.SetActive(false);//HPを消す
        }
    }
    public void KantuuAuti()//貫通弾状態で当たった時のダメージ処理
    {
        HP.value -= 20; //貫通弾なら常にクリティカル状態
        Canvas.GetComponent<UiScript>().AddScoreBossPlas(); //スコア加算

        //Debug.Log("itaiyooo");
        if (HP.value <= 0)//HPがなくなったとき
        {
            Debug.Log("Boss is Ded");
            koukaon.GetComponent<SE>().BossDed();    //ゲームクリアの音を流す処理へ
            Canvas.GetComponent<UiScript>().BossDedPoint(); //ボスを倒したご褒美　スコア加算
            BossDA.GetComponent<Boss>().BossOwari();//ボスを消す処理

            //スコア画面に移動させる処理をする
            GameOver.GetComponent<GameOver>().GameClear();//ゲームクリア処理をする

            gameObject.SetActive(false);//HPを消す
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
