using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki1 : MonoBehaviour
{

    float fallspeed;
    float rotspeed; //�������֌W�̕ϐ��l���쐬
    int Type = 0;   //�G�̓����̃^�C�v�����߂�
    bool UpDownPoint = false;//�A�b�v�̂Ƃ��̃��[�V������true �_�E���̂Ƃ��̃��[�V������false
    int jyougeMAX;

    float modoriTime;    //�߂鋗��
    float modoriCount;   //�߂�܂ł̃J�E���g�_�E��
    bool modori;    //�߂蓮�삪�����������ǂ����̏���

    float Ypoition;//Y���W�𓮂����̂ɕK�v�ȕϐ�

    // Start is called before the first frame update
    void Start()
    {
        this.fallspeed = (Random.Range(0.008f,0.015f));
        //this.rotspeed = 5f + 3F * Random.value;         //�X�N���v�g���������ꂽ�Ƃ��Ƀ����_���ȑ��x�E��]�Ŕ��ł���悤�ɗ��������蓖�Ă�

        //gameObject.tag = "teki";    //�^�O���w�肷��
        Type = Random.Range(1, 4);//1-3�܂ł̃^�C�v�������_���Ō��߂�
        Ypoition = 0;
        jyougeMAX = Random.Range(150, 500);

        modoriTime = Random.Range(50f, 400f);
        modoriCount = Random.Range(800f, 1500f);
        modori = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Type == 1)//�����^
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);     //����������(Y���W�̏ꏊ�������_���ŏo��������̂�Prefab���ŏ��������Ă���)
        }

        if (Type == 2)//���E�ړ��^
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);

            if (UpDownPoint == false)//���̏���
            {
                if (Ypoition >= -jyougeMAX)
                {
                    Ypoition--;
                    transform.Translate(0, -0.008f, 0);
                    //Debug.Log(Ypoition);
                }
                else
                {
                    UpDownPoint = true;//��肽���������������A�b�v�����ɂ܂킷
                    Ypoition = 0;//���Z�b�g
                }
            }

            if (UpDownPoint == true)//��̏���
            {
                if (Ypoition <= jyougeMAX)
                {
                    //Debug.Log("qaqaa " + Ypoition);
                    Ypoition++;
                    transform.Translate(0, +0.008f, 0);
                }
                else
                {
                    UpDownPoint = false;
                    Ypoition = 0;
                }
            }
            
            if (transform.position.y >= 4)
            {
                transform.Translate(0, -0.008f, 0);
            }
            if (transform.position.y <= -4)
            {
                transform.Translate(0, 0.008f, 0);//�I�[�o�[�΍�
            }
        }

        if (Type >= 3)//�����^
        {
            transform.Translate(-fallspeed, 0, 0, Space.World);
            //Debug.Log("333");

            if (modoriCount <= 0 && modori != true)
            {
                //Debug.Log("�͂��܂�");
                //�J�E���g���O�ɂȂ������ɖ߂鏈�����
                if (modoriTime > 0)//0�ɂȂ�܂ŌJ��Ԃ�����
                {
                    modoriTime--;//�߂���P�Ì��炷
                    transform.Translate(fallspeed * 2, 0, 0, Space.World);//�ݒ肳�ꂽ�X�s�[�h�~2�{�œ������x�Ŗ߂鏈���������
                }
                else
                {
                    modori = true;//�߂�̎��Ԃ��I�������瓯����Ƃ��ł����悤�ɂ���
                    //Debug.Log("���ǂ肵��r��");
                }
            }
            else
            {
                if (modori == false)
                {
                    modoriCount--;
                    //Debug.Log("ugogog");
                }
            }
        }
        

        if (transform.localEulerAngles.z <= 0)  //�G�L�����ɋ͂��ȃA�j���[�V������t���Ă��݂�
        {
            transform.Rotate(0, 0, -5f);
        }
        else
        {
            transform.Rotate(0, 0, 5f);
        }
        
        

        if (transform.position.x < -12)     //���׌y���̂��߂Ɍ����Ȃ������܂Ői�ނƍ폜����鏈��
        {
            Destroy(gameObject);
        }
    }
}
