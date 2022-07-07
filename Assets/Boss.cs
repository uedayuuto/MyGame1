using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject BossHP;//ボスのHPバー
    public GameObject BossLabel;//ボスのラベルだお
    public GameObject explosionPrefab;//爆発のエフェクトだ

    bool ugoki;

    float UpDownMove;
    bool UDsyori;
    bool modori;
    bool mati;
    int Random1;
    int Bosstairyoku;//ボスの体力

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//見えないようにする

        mati = false;
        ugoki = false;
        //Bosstoujyou();      //デバック用　即ボス出現
        Invoke("Bosstoujyou", Random.Range(60f, 90f));     //1分から1分半のまったあとにボスキャラが出る
        //Debug.Log("MyName：" + this.gameObject.name);
        UDsyori = true;//trueは上に行く　falseは下に行く
        modori = false;//０にするための処理
    }
    public void Bosstoujyou()
    {
        Debug.Log("boosきたたたたたた");
        gameObject.SetActive(true);//見えるようにする
        ugoki = true;
        BossHP.GetComponent<BossHP>().HPhyouji();   //BossHPを表示させる
        BossLabel.GetComponent<BossLabelText>().LabelHyouji();//bosuno Label wodasuyo!
    }
    public void BossOwari()//ボス削除
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);//自分の座標の爆破のアレが表示される
        ugoki = false;
        gameObject.SetActive(false);//BOssを隠す処理
        BossLabel.GetComponent<BossLabelText>().LabelKesu();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (modori == false && mati == false)
        {
            //Debug.Log("bbbb");
            if (ugoki == true)  //ボスの動きを作る
            {
                //transform.Translate(0, 0, 0, Space.World);
                //Debug.Log("aaaa");

                if (UDsyori == true)//上
                {
                    transform.Translate(0, 0.02f, 0, Space.World);
                    UpDownMove++;
                    if (UpDownMove >= 200)
                    {
                        modori = true;//戻り処理の発動！
                                      //UpDownMove = 0;//0にもどす動作必須ｄｆひおあｆｙひおあ
                        UDsyori = false;
                        mati = true;
                        Invoke("uesitamati", Random.Range(0f, 3f));
                    }

                }
                else//下
                {
                    //Debug.Log("ssss");
                    transform.Translate(0, -0.02f, 0, Space.World);
                    UpDownMove--;
                    if (UpDownMove <= -200)
                    {
                        modori = true;//戻り処理の発動！
                                      //UpDownMove = 0;
                        UDsyori = true;
                        mati = true;
                        Invoke("uesitamati", Random.Range(0f, 3f));
                    }
                }
            }
        }
        

        if (modori == true && mati == false)//戻す処理が必要化どうかのやつ
        {
            if (UDsyori != true)//下に向いて処理（上に来た） 80
            {
                transform.Translate(0, -0.02f, 0, Space.World);
                UpDownMove--;
                if (UpDownMove <= 0)//０になったら
                {
                    mati = true;
                    modori = false;
                    Invoke("Ymodoshi", Random.Range(0f, 3f));
                }
            }
            else//上にむいて処理（下に来た） -80
            {
                //Debug.Log("dd");
                transform.Translate(0, 0.02f, 0, Space.World);
                UpDownMove++;
                if (UpDownMove >= 0)
                {
                    mati = true;
                    modori = false;
                    Invoke("Ymodoshi", Random.Range(0f, 3f));
                }
            }
        }
    }
    public void uesitamati()//上と下の待ち時間
    {
        mati = false;
    }
    public void Ymodoshi()//動いた座標をもとに戻す処理
    {
        Random1 = Random.Range(0, 2);
        if (Random1 == 0)
        {
            UDsyori = false; 
        }
        else
        {
            UDsyori = true;
        }
        mati = false;
    }
}
