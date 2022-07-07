using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRendererTama;//たまを指定する
    public Sprite tama1;
    public Sprite tama2;

    public GameObject tamaPerhab;   //ゲームオブジェクトの値を指定する行を追加する
    public GameObject MYHP;
    public GameObject explosionPrefab;//爆発のエフェクトだ

    public SpriteRenderer spriteRenderer;//必要
    public Sprite Player1;
    public Sprite Player2;
    //表示する画像をすべて入れる

    public bool tamahueSkill = false;

    public bool tajyuutaisaku = false;//多重打ち対策用

    bool hukuseimati = false;//スキルの強制終了対策 
    int hukuseinokori = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Time.captureFramerate = 30;//フレームレート？
        hukuseimati = false;
        hukuseinokori = 0;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "teki1Prefab(Clone)" || coll.gameObject.name == "teki2Prefab(Clone)" || coll.gameObject.name == "teki3Prefab(Clone)")  //触れた物が敵だった場合の処理
        {
            Destroy(coll.gameObject);   //とりあえず当たった相手を消す

            //ここからダメージ判定のプログラムを作る
            Debug.Log("ダメージを受けた");
            MYHP.GetComponent<MYHP>().MYdame();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = tmp.x

     

        if (Input.GetKey(KeyCode.LeftArrow))   //左の矢印キーが押された時の処理
        {
            transform.Translate(-0.015f, 0, 0);   //1フレームの間に-0.1だけX座標が動く
            
        }

        if (Input.GetKey(KeyCode.RightArrow))   //右の矢印キーが押された時の処理
        {
            transform.Translate(0.015f, 0, 0);   //1フレームの間に0.1だけX座標が動く
            
        }

        if (Input.GetKey(KeyCode.UpArrow))     //上の矢印キーが押された時の処理
        {
            transform.Translate(0, 0.015f, 0);   //1フレームの間に0.1だけY座標が動く
            
        }

        if (Input.GetKey(KeyCode.DownArrow))     //下の矢印キーが押された時の処理
        {
            transform.Translate(0, -0.015f, 0);   //1フレームの間に-0.1だけY座標が動く
            
        }


        if (transform.position.x <= -10)            //場外移動対策
        {
            transform.Translate(0.015f, 0, 0);
        }
        if (transform.position.x >= 10)
        {
            transform.Translate(-0.015f, 0, 0);
        }
        if (transform.position.y >= 4)
        {
            transform.Translate(0, -0.015f, 0);
        }
        if (transform.position.y <= -4)
        {
            transform.Translate(0, 0.015f, 0);
        }                                           //場外移動対策


        if (Input.GetKeyDown(KeyCode.Space) && tajyuutaisaku == false)    //スペースキーを押したときにインスタンスが生成されてtamaが指定の動作で動く
        {
            tajyuutaisaku = true;
            spriteRenderer.sprite = Player2;//撃ったときの画像にする
            //Debug.Log("tamauuuu");
            //if ()

            Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 90));   //インスタンスtamaPerhabの部分を新しく作りこのオブジェクトと同じ座標に作成する

            if (tamahueSkill == true)//スキルがONのときの処理
            {
                Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 100));
                Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 80));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))      //スペースキーが離されたときの処理
        {
            tajyuutaisaku = false;
            spriteRenderer.sprite = Player1;//キーを離したときにもとに戻す
        }
    }

    public void tamazousyoku()
    {
        if (hukuseimati != true)
        {
            hukuseimati = true;
            tamahueSkill = true;
            Invoke("SkillTime", 10);
        }
        else
        {
            hukuseinokori++;
        }
    }
    public void SkillTime()
    {
        if (hukuseinokori > 0)//0より上なラヴァ
        {
            Debug.Log("複製スキル延長、残り" + hukuseinokori);
            hukuseinokori--;    //1減らす
            Invoke("SkillTime", 10);
        }
        else
        {
            hukuseimati = false;
            tamahueSkill = false;
            Debug.Log("複製スキル終わり");
        }
        
    }

    public void PlayerCrystal()//プレイヤーの削除処理
    {

        gameObject.SetActive(false);
    }
}
