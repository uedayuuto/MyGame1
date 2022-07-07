using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�X�N���[���֌W�̏������ł���悤�ɂ���

public class GameOver : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite Over;
    public Sprite Clear;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GameOverText()  //�Q�[���I�[�o�[�ɂȂ����Ƃ��ɃQ�[���I�[�o�[�̃e�L�X�g���o��
    {
        spriteRenderer.sprite = Over;
        //�摜���I�[�o�[�ɕς���
        gameObject.SetActive(true);
        Player.GetComponent<Player>().PlayerCrystal();//�v���C���[����������
        Invoke("SceneChange", 2);
    }
    public void GameClear()
    {
        spriteRenderer.sprite = Clear;      //�N���A�摜�����
        //�摜���N���A�e�L�X�g�ɕς���
        gameObject.SetActive(true);
        Player.GetComponent<Player>().PlayerCrystal();//�v���C���[����������
        Invoke("SceneChange", 2);
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("GameEnd");//�Q�[���G���h�̃V�[���ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
