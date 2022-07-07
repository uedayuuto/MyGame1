using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekiseisei : MonoBehaviour
{

    public GameObject teki1Prefab;
    public GameObject teki2Prefab;
    public GameObject teki3Prefab;  //登場させる的の型を入れるオブジェクトプロパティを作成する

    public int seiseiTime;
    public int Randomsuuji;

    int muzukasisa;//敵の生成速度に関係する変数を作る

    float Power;

    // Start is called before the first frame update
    void Start()
    {
        muzukasisa = Level.getL();  //int 0-2 まで
        //Levelのスクリプトファイルで書いた変数を取得してmizukasisaの変数に挿入する
        if (muzukasisa == 0) Power = 0.3f;
        if (muzukasisa == 1) Power = 0.2f;
        if (muzukasisa == 2) Power = 0.15f;

        InvokeRepeating("GenRock", 1, Power);   //自動でGenRock関数を動かすタイマーを作る(関数の名前,　生成個数,　生成時間間隔)
    }

    void GenRock()
    {
        Randomsuuji = Random.Range(1, 3 + 1);   //１から３までのint型の乱数を生成する

        if (Randomsuuji == 3)      //１のtekiを生成する
        {
            Instantiate(teki1Prefab, new Vector3(           //Prefabを基準にして以下の座標に敵を生成する
                                                12f,                        //X軸の座標
                                                Random.Range(-4.4f, 4.4f),  //Y軸の座標
                                                0),                         //Z軸の座標
                                                Quaternion.identity);
        }
        if (Randomsuuji == 2)  //２のtekiを生成する
        {
            Instantiate(teki2Prefab, new Vector3(           //Prefabを基準にして以下の座標に敵を生成する
                                                12f,                        //X軸の座標
                                                Random.Range(-4.4f, 4.4f),  //Y軸の座標
                                                0),                         //Z軸の座標
                                                Quaternion.identity);
        }
        if (Randomsuuji == 1)  //３のtekiを生成する
        {
            Instantiate(teki3Prefab, new Vector3(           //Prefabを基準にして以下の座標に敵を生成する
                                                12f,                        //X軸の座標
                                                Random.Range(-4.4f, 4.4f),  //Y軸の座標
                                                0),                         //Z軸の座標
                                                Quaternion.identity);
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
