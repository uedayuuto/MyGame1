using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public GameObject BossDA;
    //public GameObject BossLabel;
    public GameObject GameOver;
    public GameObject Canvas;
    public GameObject gameGuide;
    public GameObject koukaon;

    int BossMaxHP;//MAX HP
    float Critical;

    public AudioClip BossDed;
    AudioSource audioSource;

    Slider HP;//�{�X��HP�֌W

    // Start is called before the first frame update
    void Start()
    {
        BossMaxHP = Level.getL();   //���x���̌�����擾����V�B��
        HP = GetComponent<Slider>();    //�X���C�_�[�̏����擾����

        //���x�����Ƃ�BOSS�̍ő�HP��ݒ肷�鏈��
        if (BossMaxHP == 0) HP.maxValue = 1000;
        if (BossMaxHP == 1) HP.maxValue = 1500;
        if (BossMaxHP == 2) HP.maxValue = 2500;
        HP.value = HP.maxValue;     //�ő�HP�ɉ񕜂����Ă���
        gameObject.SetActive(false);//�����Ȃ��悤�ɂ���
    }

    public void HPhyouji()//�{�X��������HP�o�[��Xr�t
    {
        gameObject.SetActive(true);//������
        //gaidididjodfikoksd
        gameGuide.GetComponent<GameGuide>().DasuYO();
    }

    public void Auti()//�v���C���[�̒e��H������Ƃ��̏����@���ʒe
    {
        Critical = Random.Range(1f, 5f + 1f);    //1-5�̃����_�������@�T���̂P�ŃN���e�B�J������
        if (Critical < 5)
        {
            HP.value -= 10; //�ʏ�
            Canvas.GetComponent<UiScript>().AddScoreBoss(); //�X�R�A���Z
        }
        else
        {
            //Debug.Log("KUKUK");
            HP.value -= 20; //�N���e�B�J��
            Canvas.GetComponent<UiScript>().AddScoreBossPlas(); //�X�R�A���Z����
        }

        if (HP.value <= 0)//HP���Ȃ��Ȃ����Ƃ�
        {
            Debug.Log("Boss is Ded");
            Canvas.GetComponent<UiScript>().BossDedPoint(); //�{�X��|�������J���@�X�R�A���Z
            BossDA.GetComponent<Boss>().BossOwari();//�{�X����������
            //�X�R�A��ʂɈړ������鏈��������
            GameOver.GetComponent<GameOver>().GameClear();//�Q�[���N���A����������

            gameObject.SetActive(false);//HP������
        }
    }
    public void KantuuAuti()//�ђʒe��Ԃœ����������̃_���[�W����
    {
        HP.value -= 20; //�ђʒe�Ȃ��ɃN���e�B�J�����
        Canvas.GetComponent<UiScript>().AddScoreBossPlas(); //�X�R�A���Z����

        //Debug.Log("itaiyooo");
        if (HP.value <= 0)//HP���Ȃ��Ȃ����Ƃ�
        {
            Debug.Log("Boss is Ded");
            koukaon.GetComponent<SE>().BossDed();    //�Q�[���N���A�̉��𗬂�������
            Canvas.GetComponent<UiScript>().BossDedPoint(); //�{�X��|�������J���@�X�R�A���Z
            BossDA.GetComponent<Boss>().BossOwari();//�{�X����������
            //�X�R�A��ʂɈړ������鏈��������
            GameOver.GetComponent<GameOver>().GameClear();//�Q�[���N���A����������

            gameObject.SetActive(false);//HP������
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
