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

    public void Skill1()//�X�L�����Ƃ̃A���B
    {
        //�ђ�
        text.text = "�ђʃX�L�������I";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }
    public void Skill2()
    {
        //����
        text.text = "�����X�L�������I";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }
    public void Skill3()
    {
        kaihukuHP = MYHP.getH();//�񕜂��������𓾂�
        //��
        text.text = kaihukuHP + "HP �񕜂����I";
        gameObject.SetActive(true);
        Invoke("TextKesu", 2);
    }

    public void TextKesu()//���x���\����������
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
