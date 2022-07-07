using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki1 : MonoBehaviour
{

    float fallspeed;
    float rotspeed; //動かす関係の変数値を作成
    int Type = 0;   //敵の動きのタイプを決める
    bool UpDownPoint = false;//アップのときのモーションはtrue ダウンのときのモーションはfalse
    int jyougeMAX;

    float modoriTime;    //戻る距離
    float modoriCount;   //戻るまでのカウントダウン
    bool modori;    //戻り動作が完了したかどうかの処理

    float Ypoition;//Y座標を動かすのに必要な変数

    // Start is called before the first frame update
    void Start()
    {
        this.fallspeed = (Random.Range(0.008f,0.015f));
        //this.rotspeed = 5f + 3F * Random.value;         //スクリプトが生成されたときにランダムな速度・回転で飛んでくるように乱数を割り当てる

        //gameObject.tag = "teki";    //タグを指定する
        Type = Random.Range(1, 4);//1-3までのタイプをランダムで決める
        Ypoition = 0;
        jyougeMAX = Random.Range(150, 500);

        modoriTime = Random.Range(50f, 400f);
        modoriCount = Random.Range(800f, 1500f);
        modori = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Type == 1)//直線型
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);     //動かす処理(Y座標の場所をランダムで出現させるのはPrefab側で処理をしている)
        }

        if (Type == 2)//左右移動型
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);

            if (UpDownPoint == false)//下の処理
            {
                if (Ypoition >= -jyougeMAX)
                {
                    Ypoition--;
                    transform.Translate(0, -0.008f, 0);
                    //Debug.Log(Ypoition);
                }
                else
                {
                    UpDownPoint = true;//やりたい分だけやったらアップ処理にまわす
                    Ypoition = 0;//リセット
                }
            }

            if (UpDownPoint == true)//上の処理
            {
                if (Ypoition <= jyougeMAX)
                {
                    //Debug.Log("qaqaa " + Ypoition);
                    Ypoition++;
                    transform.Translate(0, +0.008f, 0);
                }
                else
                {
                    UpDownPoint = false;
                    Ypoition = 0;
                }
            }
            
            if (transform.position.y >= 4)
            {
                transform.Translate(0, -0.008f, 0);
            }
            if (transform.position.y <= -4)
            {
                transform.Translate(0, 0.008f, 0);//オーバー対策
            }
        }

        if (Type >= 3)//往復型
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);
            //Debug.Log("333");

            if (modoriCount <= 0 && modori != true)
            {
                //Debug.Log("はじまり");
                //カウントが０になった時に戻る処理作業
                if (modoriTime > 0)//0になるまで繰り返す処理
                {
                    modoriTime--;//戻りを１つづ減らす
                    transform.Translate(fallspeed * 2, 0, 0, Space.World);//設定されたスピード×2倍で同じ速度で戻る処理がされる
                }
                else
                {
                    modori = true;//戻りの時間が終了したら同じ作業ができいようにする
                    //Debug.Log("もどりしゅr帳");
                }
            }
            else
            {
                if (modori == false)
                {
                    modoriCount--;
                    //Debug.Log("ugogog");
                }
            }
        }
        

        if (transform.localEulerAngles.z <= 0)  //敵キャラに僅かなアニメーションを付けていみる
        {
            transform.Rotate(0, 0, -5f);
        }
        else
        {
            transform.Rotate(0, 0, 5f);
        }
        
        

        if (transform.position.x < -12)     //負荷軽減のために見えない部分まで進むと削除される処理
        {
            Destroy(gameObject);
        }
    }
}
