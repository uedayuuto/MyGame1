using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMov : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;  //表示する画像をすべて入れる

    public GameObject tamauti;
    public GameObject Player;
    public GameObject PlayerHP;

    public GameObject SkillGuide;

    public int Randomsuuji = 1;
    public int SkillName;           //スキルの種類を判別すための処理

    public float time;

    public bool Roulette = false;//ルーレットの処理関係の変数

    bool Skillmati = false;//スキルのルーレット待ちの状態かの判定
    int Skillnokori = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//見えないようにする
        spriteRenderer.sprite = sprite1;    //一応初期化する
        Skillnokori = 0;
        Skillmati = false;
        //InvokeRepeating("SkillRoulette", 1, 0.1f);
        //Debug.Log("衝突されたオブジェクト：" + this.gameObject.name);

        InvokeRepeating("SkillRoulette", 1, 0.1f);//ルーレットの処理

        //StartCoroutine(fall());
        //SkillSelect();//デバック用
    }

    public void SkillSelect()//どのスキルがでるかルーレットする処理
    {
        gameObject.SetActive(true); //画像を出す

        if (Skillmati != true)//スキル待ちの状態ではない時ならルーレットの処理をする
        {
            Roulette = true;
            Skillmati = true;//スキル待ち状態にする
            Invoke("fall", Random.Range(3f, 6f));
            //時間待ち処理に飛ばす
        }
        else//スキル待ちの時のしょり
        {
            Skillnokori += 1;//前の処理が終わってから回す処理
        }
    }

    public void fall()
    {

        Debug.Log("スロットは止まったよ");
        //タイマーが止まったあとの処理
        Roulette = false;

        if (SkillName == 1)
        {
            Debug.Log("貫通スキルの発動");
            tamauti.GetComponent<tamauti>().tamakantuuSkill();//弾を貫通させるスキル発動
            SkillGuide.GetComponent<SkillGuide>().Skill1();//
        }
        else if (SkillName == 2)
        {
            Debug.Log("複製スキル");
            Player.GetComponent<Player>().tamazousyoku();//弾増殖のスキル発動
            SkillGuide.GetComponent<SkillGuide>().Skill2();
        }
        else if (SkillName == 3)
        {
            Debug.Log("回復スキル");
            PlayerHP.GetComponent<MYHP>().kaihuku();//回復スキルの処理へ飛ばす
            SkillGuide.GetComponent<SkillGuide>().Skill3();
        }
        
        Invoke("owari", 1);//１秒後にルーレットのストックを全部使い切ったか判断する処理へ

    }
    public void owari()
    {
        if (Skillnokori > 0)//スキル処理がすべて終わって居ないときは変数を１引いてもう一度回す処理
        {
            Skillnokori -= 1;//スキルのストックを１引く（0になったら終了falseへ）

            Roulette = true;
            Invoke("fall", Random.Range(3f, 6f));
        }
        else//何もない時はそのままルーレットを終了させる（隠す）
        {
            Skillmati = false;
            gameObject.SetActive(false);//ルーレットを消す
        }
        
    }
    

    void SkillRoulette()//ルーレットの中身
    {
        if (Roulette == true)
        {
            if (Randomsuuji == 3)//3の画像表示
            {
                spriteRenderer.sprite = sprite3;
                SkillName = 3;
            }
            else if (Randomsuuji == 2)//2の画像
            {
                spriteRenderer.sprite = sprite2;
                SkillName = 2;
            }
            else if (Randomsuuji == 1)//1の画像
            {
                spriteRenderer.sprite = sprite1;
                SkillName = 1;
            }

            Randomsuuji++;//見せる値を１増やす
            if (Randomsuuji > 3) Randomsuuji = 1;//３を超えた場合に１に戻す処理（バグ対策用）
        }
    }

    // Update is called once per frame
    void Update()
    {
        //time += 0.1f;
        //Debug.Log(time);
    }
}
