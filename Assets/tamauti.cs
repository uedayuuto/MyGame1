using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamauti : MonoBehaviour
{
    public GameObject PlayerSkill;
    public GameObject Test;
    public GameObject BossHPLabel;

    public SpriteRenderer spriteRenderer;
    public Sprite hutuuTama;
    public Sprite kantuuTama;

    bool kantuumati = false;
    int kantuunokori = 0;

    public bool tamakantuu = false;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;//音関係

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();//音を流す処理をする
        if (tamakantuu == true)//貫通する場合のたまのテクスチャ
        {
            spriteRenderer.sprite = kantuuTama;
        }
        else
        {
            spriteRenderer.sprite = hutuuTama;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Translate(0, -0.03f, 0);//一定の速度で動く処理
        if (transform.position.x > 20)//画面外に行くと消す処理
        {
            Destroy(gameObject);
        }
    }

    public void tamakantuuSkill()   //たま貫通のスキルを受け取ったときの処理
    {
        if (kantuumati != true) //初回falseなのでこのif処理はtrue処理を通る
        {
            tamakantuu = true;  //弾が貫通できるようになる処理
            kantuumati = true;  //待ちモードがONになる
            Invoke("SkillTime", 20);
        }
        else
        {
            kantuunokori++;     //貫通モードがONであれば変数を１+する
        }
    }
    public void SkillTime()//２０秒間まって止める処理をする
    {
        if (kantuunokori > 0)//スキルの待ちが1つでも残っていたらもう２０秒追加する処理
        {
            kantuunokori--;
            Debug.Log("貫通スキル延長、残り" + kantuunokori);
            Invoke("SkillTime", 20);
        }
        else//０であれば終了の処理をする
        {
            tamakantuu = false; //弾貫通を終了状態にする
            kantuumati = false; //スキル待ちをOFFにする
            Debug.Log("貫通スキルの終了");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D coll)  //ビームが敵にあたった時に当たったやつのオブジェクトをcollと言う名前にする
    {
        //Debug.Log("衝突されたオブジェクト：" + coll.gameObject.name);
        if (coll.gameObject.name == "teki1Prefab(Clone)" || coll.gameObject.name == "teki2Prefab(Clone)" || coll.gameObject.name == "teki3Prefab(Clone)")  //触れた物が敵だった場合の処理
        {
            

            //Debug.Log("AAAAAAAAAAA");
            GameObject.Find("Canvas").GetComponent<UiScript>().AddScore();  //特定の場所を指定してその中にあるAddScoreの関数を呼び出す
            GameObject.Find("PlayerSkill").GetComponent<MYSKILL>().SkillPoint();    //スキルのポイントが貯まる関数を呼び出す

            Destroy(coll.gameObject);   //触れた相手側のオブジェクトを削除する

            if (tamakantuu == false)    //たま貫通機能がOFFのときの処理
            {
                GameObject.Find("SE").GetComponent<SE>().NomarDAME();//SEオブジェクトのSEスクリプトの中にあるNomarDAMEの関数を動かす
                Destroy(gameObject);    //自分側のオブジェクトも削除する
            }
            else
            {
                audioSource.PlayOneShot(sound1);//貫通時の効果音
            }
            
        }
        else if (coll.gameObject.name == "Boss")    //ボスキャラに弾が当たった時の処理
        {
            if (tamakantuu == true)
            {
                Debug.Log("aaaaaaaaa");
                Destroy(gameObject);
                GameObject.Find("BossHP").GetComponent<BossHP>().KantuuAuti();    //クリティカルダメージの処理を送る
            }
            else//貫通OFFの時のダメージ判定
            {
                Destroy(gameObject);//自分のオブジェクトを削除する

                                    //ボスのダメージ処理をする
                GameObject.Find("BossHP").GetComponent<BossHP>().Auti();//通常ダメージ処理を送る
            }
        }
    }
}
