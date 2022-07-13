using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    [SerializeField] private AudioSource a1;//敵のダメージ用
    [SerializeField] private AudioSource a2;//ゲームクリアやゲームオーバー用

    public AudioClip sound2;//通常の敵に対してのダメージ
    public AudioClip sound3;//ゲームクリア時の効果音
    public AudioClip sound4;//ゲームオーバー時の効果音

    //AudioSource audioSource;//なんか必要なプログラム


    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //オーディオ再生のプロパティと関連付ける
    }

    public void NomarDAME()
    {
        a1.PlayOneShot(sound2);//割り当てたサウンド２を鳴らす
    }
    public void BossDed()
    {
        a2.PlayOneShot(sound3);//流している音を消す
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
