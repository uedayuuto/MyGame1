using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    [SerializeField] private AudioSource a1;//�G�̃_���[�W�p
    [SerializeField] private AudioSource a2;//�Q�[���N���A��Q�[���I�[�o�[�p

    public AudioClip sound2;//�ʏ�̓G�ɑ΂��Ẵ_���[�W
    public AudioClip sound3;//�Q�[���N���A���̌��ʉ�
    public AudioClip sound4;//�Q�[���I�[�o�[���̌��ʉ�

    //AudioSource audioSource;//�Ȃ񂩕K�v�ȃv���O����


    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //�I�[�f�B�I�Đ��̃v���p�e�B�Ɗ֘A�t����
    }

    public void NomarDAME()
    {
        a1.PlayOneShot(sound2);//���蓖�Ă��T�E���h�Q��炷
    }
    public void BossDed()
    {
        a2.PlayOneShot(sound3);//�N���A
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
