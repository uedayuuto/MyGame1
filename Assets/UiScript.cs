using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI�n���擾���邽�߂ɕK�v

public class UiScript : MonoBehaviour
{
    public static int score = 0;//���L�\�ȕϐ��𐶐�����

    GameObject scoreText;
    GameObject GameOverText;
    //GameObject Skill;
    

    //Slider SkillPoint;

    
    public static int getA()
    {
        return score;
    }

    public void GameOver()  //�Q�[���I�[�o�[�̊֐����󂯎�����Ƃ��Ƀe�L�X�g�����߂��ׂ�ɂ���
    {
        this.GameOverText.GetComponent<Text>().text = "GameOver";
        
    }
    public void AddScore()  //�X�R�A�����Z�����Ƃ��Ɏg����֐��𐶐�
    {
        score += 10;//�X�R�A���v���X����

        
    }
    public void AddScoreBoss()//�{�X�̃X�R�A���i�ʏ�j
    {
        score += 20;
    }
    public void AddScoreBossPlas()//�{�X�̃X�R�A���i�N���e�B�J���j
    {
        score += 40;
    }
    public void BossDedPoint()//�{�X��|�����Ƃ��̃{�[�i�X�X�R�A
    {
        score += 1000;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.GameOverText = GameObject.Find("GameOver");
        //SkillPoint = GetComponent<"">();
        //GameObject SkillPoint = GameObject.Find("PlayerSkill");//�v���C���[�̃X�L���o�[���擾����
        //Slider SkillPoint;
        score = 0;//�X�R�A�̃��Z�b�g����
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");  //�e�L�X�g�iScore�j+�X�R�A��\������
    }
}
