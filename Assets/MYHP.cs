using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MYHP : MonoBehaviour
{
    public GameObject Player;   //プレイヤーのオブジェクトを読み込む
    public GameObject GameOverText;

    public static int kaihukukazu;

    Slider HP;
    

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();    //UIの座標をもらう
        HP = GetComponent<Slider>();    //スライダーの情報を取得する
    }

    // Update is called once per frame
    void Update()
    {
        
        //RectTransform(1f, 1f, 1f);
    }

    public static int getH()
    {
        return kaihukukazu;
    }

    public void MYdame()
    {
        HP.value -= 50; //HPの値を２０づつ引く

        if (HP.value <= 0)//HPが０になったときの処理
        {
            Debug.Log("ゲームオーバー");   //ゲームオーバーの処理

            GameOverText.GetComponent<GameOver>().GameOverText();   //ゲームオーバーのテキストを表示させるためにUiScriptにゲームオーバーの関数を出させる処理

            

        }
    }
    public void kaihuku()
    {
        kaihukukazu = Random.Range(5, 50 + 1);//1kara50madenoRandomkaihukusuruyatu
        HP.value += kaihukukazu;
        //Debug.Log("");
        //回復演出
    }
}
