using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGuide : MonoBehaviour
{
    public Text text;

    int kaihukuHP;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Skill1()//スキルごとのアレ。
    {
        //貫通
        text.text = "貫通スキル発動！";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }
    public void Skill2()
    {
        //複製
        text.text = "複製スキル発動！";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }
    public void Skill3()
    {
        kaihukuHP = MYHP.getH();//回復した数字を得る
        //回復
        text.text = kaihukuHP + "HP 回復した！";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }

    public void TextKesu()//ラベル表示後消すやつ
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
