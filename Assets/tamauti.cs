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
    AudioSource audioSource;//���֌W

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();//���𗬂�����������
        if (tamakantuu == true)//�ђʂ���ꍇ�̂��܂̃e�N�X�`��
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
        
        transform.Translate(0, -0.03f, 0);//���̑��x�œ�������
        if (transform.position.x > 20)//��ʊO�ɍs���Ə�������
        {
            Destroy(gameObject);
        }
    }

    public void tamakantuuSkill()   //���܊ђʂ̃X�L�����󂯎�����Ƃ��̏���
    {
        if (kantuumati != true) //����false�Ȃ̂ł���if������true������ʂ�
        {
            tamakantuu = true;  //�e���ђʂł���悤�ɂȂ鏈��
            kantuumati = true;  //�҂����[�h��ON�ɂȂ�
            Invoke("SkillTime", 20);
        }
        else
        {
            kantuunokori++;     //�ђʃ��[�h��ON�ł���Εϐ����P+����
        }
    }
    public void SkillTime()//�Q�O�b�Ԃ܂��Ď~�߂鏈��������
    {
        if (kantuunokori > 0)//�X�L���̑҂���1�ł��c���Ă���������Q�O�b�ǉ����鏈��
        {
            kantuunokori--;
            Debug.Log("�ђʃX�L�������A�c��" + kantuunokori);
            Invoke("SkillTime", 20);
        }
        else//�O�ł���ΏI���̏���������
        {
            tamakantuu = false; //�e�ђʂ��I����Ԃɂ���
            kantuumati = false; //�X�L���҂���OFF�ɂ���
            Debug.Log("�ђʃX�L���̏I��");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D coll)  //�r�[�����G�ɂ����������ɓ���������̃I�u�W�F�N�g��coll�ƌ������O�ɂ���
    {
        //Debug.Log("�Փ˂��ꂽ�I�u�W�F�N�g�F" + coll.gameObject.name);
        if (coll.gameObject.name == "teki1Prefab(Clone)" || coll.gameObject.name == "teki2Prefab(Clone)" || coll.gameObject.name == "teki3Prefab(Clone)")  //�G�ꂽ�����G�������ꍇ�̏���
        {
            

            //Debug.Log("AAAAAAAAAAA");
            GameObject.Find("Canvas").GetComponent<UiScript>().AddScore();  //����̏ꏊ���w�肵�Ă��̒��ɂ���AddScore�̊֐����Ăяo��
            GameObject.Find("PlayerSkill").GetComponent<MYSKILL>().SkillPoint();    //�X�L���̃|�C���g�����܂�֐����Ăяo��

            Destroy(coll.gameObject);   //�G�ꂽ���葤�̃I�u�W�F�N�g���폜����

            if (tamakantuu == false)    //���܊ђʋ@�\��OFF�̂Ƃ��̏���
            {
                GameObject.Find("SE").GetComponent<SE>().NomarDAME();//SE�I�u�W�F�N�g��SE�X�N���v�g�̒��ɂ���NomarDAME�̊֐��𓮂���
                Destroy(gameObject);    //�������̃I�u�W�F�N�g���폜����
            }
            else
            {
                audioSource.PlayOneShot(sound1);//�ђʎ��̌��ʉ�
            }
            
        }
        else if (coll.gameObject.name == "Boss")    //�{�X�L�����ɒe�������������̏���
        {
            if (tamakantuu == true)
            {
                Debug.Log("aaaaaaaaa");
                Destroy(gameObject);
                GameObject.Find("BossHP").GetComponent<BossHP>().KantuuAuti();    //�N���e�B�J���_���[�W�̏����𑗂�
            }
            else//�ђ�OFF�̎��̃_���[�W����
            {
                Destroy(gameObject);//�����̃I�u�W�F�N�g���폜����

                                    //�{�X�̃_���[�W����������
                GameObject.Find("BossHP").GetComponent<BossHP>().Auti();//�ʏ�_���[�W�����𑗂�
            }
        }
    }
}
