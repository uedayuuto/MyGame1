using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject BossHP;//�{�X��HP�o�[
    public GameObject BossLabel;//�{�X�̃��x������
    public GameObject explosionPrefab;//�����̃G�t�F�N�g��

    bool ugoki;

    float UpDownMove;
    bool UDsyori;
    bool modori;
    bool mati;
    int Random1;
    int Bosstairyoku;//�{�X�̗̑�

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//�����Ȃ��悤�ɂ���

        mati = false;
        ugoki = false;
        //Bosstoujyou();      //�f�o�b�N�p�@���{�X�o��
        Invoke("Bosstoujyou", Random.Range(60f, 90f));     //1������1�����̂܂������ƂɃ{�X�L�������o��
        //Debug.Log("MyName�F" + this.gameObject.name);
        UDsyori = true;//true�͏�ɍs���@false�͉��ɍs��
        modori = false;//�O�ɂ��邽�߂̏���
    }
    public void Bosstoujyou()
    {
        Debug.Log("boos��������������");
        gameObject.SetActive(true);//������悤�ɂ���
        ugoki = true;
        BossHP.GetComponent<BossHP>().HPhyouji();   //BossHP��\��������
        BossLabel.GetComponent<BossLabelText>().LabelHyouji();//bosuno Label wodasuyo!
    }
    public void BossOwari()//�{�X�폜
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);//�����̍��W�̔��j�̃A�����\�������
        ugoki = false;
        gameObject.SetActive(false);//BOss���B������
        BossLabel.GetComponent<BossLabelText>().LabelKesu();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (modori == false && mati == false)
        {
            //Debug.Log("bbbb");
            if (ugoki == true)  //�{�X�̓��������
            {
                //transform.Translate(0, 0, 0, Space.World);
                //Debug.Log("aaaa");

                if (UDsyori == true)//��
                {
                    transform.Translate(0, 0.02f, 0, Space.World);
                    UpDownMove++;
                    if (UpDownMove >= 200)
                    {
                        modori = true;//�߂菈���̔����I
                                      //UpDownMove = 0;//0�ɂ��ǂ�����K�{�����Ђ��������Ђ���
                        UDsyori = false;
                        mati = true;
                        Invoke("uesitamati", Random.Range(0f, 3f));
                    }

                }
                else//��
                {
                    //Debug.Log("ssss");
                    transform.Translate(0, -0.02f, 0, Space.World);
                    UpDownMove--;
                    if (UpDownMove <= -200)
                    {
                        modori = true;//�߂菈���̔����I
                                      //UpDownMove = 0;
                        UDsyori = true;
                        mati = true;
                        Invoke("uesitamati", Random.Range(0f, 3f));
                    }
                }
            }
        }
        

        if (modori == true && mati == false)//�߂��������K�v���ǂ����̂��
        {
            if (UDsyori != true)//���Ɍ����ď����i��ɗ����j 80
            {
                transform.Translate(0, -0.02f, 0, Space.World);
                UpDownMove--;
                if (UpDownMove <= 0)//�O�ɂȂ�����
                {
                    mati = true;
                    modori = false;
                    Invoke("Ymodoshi", Random.Range(0f, 3f));
                }
            }
            else//��ɂނ��ď����i���ɗ����j -80
            {
                //Debug.Log("dd");
                transform.Translate(0, 0.02f, 0, Space.World);
                UpDownMove++;
                if (UpDownMove >= 0)
                {
                    mati = true;
                    modori = false;
                    Invoke("Ymodoshi", Random.Range(0f, 3f));
                }
            }
        }
    }
    public void uesitamati()//��Ɖ��̑҂�����
    {
        mati = false;
    }
    public void Ymodoshi()//���������W�����Ƃɖ߂�����
    {
        Random1 = Random.Range(0, 2);
        if (Random1 == 0)
        {
            UDsyori = false; 
        }
        else
        {
            UDsyori = true;
        }
        mati = false;
    }
}
