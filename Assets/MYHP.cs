using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MYHP : MonoBehaviour
{
    public GameObject Player;   //�v���C���[�̃I�u�W�F�N�g��ǂݍ���
    public GameObject GameOverText;

    public static int kaihukukazu;

    Slider HP;
    

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();    //UI�̍��W�����炤
        HP = GetComponent<Slider>();    //�X���C�_�[�̏����擾����
    }

    // Update is called once per frame
    void Update()
    {
        
        //RectTransform(1f, 1f, 1f);
    }

    public static int getH()
    {
        return kaihukukazu;
    }

    public void MYdame()
    {
        HP.value -= 50; //HP�̒l���Q�O�Â���

        if (HP.value <= 0)//HP���O�ɂȂ����Ƃ��̏���
        {
            Debug.Log("�Q�[���I�[�o�[");   //�Q�[���I�[�o�[�̏���

            GameOverText.GetComponent<GameOver>().GameOverText();   //�Q�[���I�[�o�[�̃e�L�X�g��\�������邽�߂�UiScript�ɃQ�[���I�[�o�[�̊֐����o�����鏈��

            

        }
    }
    public void kaihuku()
    {
        kaihukukazu = Random.Range(5, 50 + 1);//1kara50madenoRandomkaihukusuruyatu
        HP.value += kaihukukazu;
        //Debug.Log("");
        //�񕜉��o
    }
}
