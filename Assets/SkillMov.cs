using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMov : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;  //�\������摜�����ׂē����

    public GameObject tamauti;
    public GameObject Player;
    public GameObject PlayerHP;

    public GameObject SkillGuide;//sukirugagagagadgfaikfaik

    public int Randomsuuji = 1;
    public int SkillName;           //�X�L���̎�ނ𔻕ʂ����߂̏���

    public float time;

    public bool Roulette = false;//���[���b�g�̏����֌W�̕ϐ�

    bool Skillmati = false;//�X�L���̃��[���b�g�҂��̏�Ԃ��̔���
    int Skillnokori = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//�����Ȃ��悤�ɂ���
        spriteRenderer.sprite = sprite1;    //�ꉞ����������
        Skillnokori = 0;
        Skillmati = false;
        //InvokeRepeating("SkillRoulette", 1, 0.1f);
        //Debug.Log("�Փ˂��ꂽ�I�u�W�F�N�g�F" + this.gameObject.name);

        InvokeRepeating("SkillRoulette", 1, 0.1f);//���[���b�g�̏���

        //StartCoroutine(fall());
        //SkillSelect();//�f�o�b�N�p
    }

    public void SkillSelect()//�ǂ̃X�L�����ł邩���[���b�g���鏈��
    {
        gameObject.SetActive(true); //�摜���o��

        if (Skillmati != true)//�X�L���҂��̏�Ԃł͂Ȃ����Ȃ烋�[���b�g�̏���������
        {
            Roulette = true;
            Skillmati = true;//�X�L���҂���Ԃɂ���
            Invoke("fall", Random.Range(3f, 6f));
            //���ԑ҂������ɔ�΂�
        }
        else//�X�L���҂��̎��̂����
        {
            Skillnokori += 1;//�O�̏������I����Ă���񂷏���
        }
    }

    public void fall()
    {

        //CancelInvoke(); //�^�C�}�[���~�߂�i�X���b�g���~�܂�j
        Debug.Log("�X���b�g�͎~�܂�����");
        //�^�C�}�[���~�܂������Ƃ̏���
        Roulette = false;

        if (SkillName == 1)
        {
            Debug.Log("�ђʃX�L���̔���");
            tamauti.GetComponent<tamauti>().tamakantuuSkill();//���܂��ђʂ����鏈����������
            SkillGuide.GetComponent<SkillGuide>().Skill1();//
        }
        else if (SkillName == 2)
        {
            Debug.Log("�����X�L��");
            Player.GetComponent<Player>().tamazousyoku();//���ܑ��B�̃X�L������
            SkillGuide.GetComponent<SkillGuide>().Skill2();
        }
        else if (SkillName == 3)
        {
            Debug.Log("�񕜃X�L��");
            PlayerHP.GetComponent<MYHP>().kaihuku();//�񕜃X�L���̏����֔�΂�
            SkillGuide.GetComponent<SkillGuide>().Skill3();
        }
        
        Invoke("owari", 1);//�P�b��ɏ�������

    }
    public void owari()
    {
        if (Skillnokori > 0)//�X�L�����������ׂďI����ċ��Ȃ��Ƃ��͕ϐ����P�����Ă�����x�񂷏���
        {
            Skillnokori -= 1;

            Roulette = true;
            Invoke("fall", Random.Range(3f, 6f));
        }
        else//�����Ȃ����͂��̂܂܃��[���b�g���I��������i�B���j
        {
            Skillmati = false;
            gameObject.SetActive(false);//���[���b�g������
        }
        
    }
    

    void SkillRoulette()//���[���b�g�̒��g
    {
        //Randomsuuji = Random.Range(1, 3);
        //Debug.Log("ugogogo" + Randomsuuji);
        if (Roulette == true)
        {
            if (Randomsuuji == 3)//3�̉摜�\��
            {
                spriteRenderer.sprite = sprite3;
                SkillName = 3;
            }
            else if (Randomsuuji == 2)//2�̉摜
            {
                spriteRenderer.sprite = sprite2;
                SkillName = 2;
            }
            else if (Randomsuuji == 1)//1�̉摜
            {
                spriteRenderer.sprite = sprite1;
                SkillName = 1;
            }

            Randomsuuji++;//������l���P���₷
            if (Randomsuuji > 3) Randomsuuji = 1;//�R�𒴂����ꍇ�ɂP�ɖ߂�����
        }
    }

    // Update is called once per frame
    void Update()
    {
        //time += 0.1f;
        //Debug.Log(time);
    }
}
