using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRendererTama;//���܂��w�肷��
    public Sprite tama1;
    public Sprite tama2;

    public GameObject tamaPerhab;   //�Q�[���I�u�W�F�N�g�̒l���w�肷��s��ǉ�����
    public GameObject MYHP;
    public GameObject explosionPrefab;//�����̃G�t�F�N�g��

    public SpriteRenderer spriteRenderer;//�K�v
    public Sprite Player1;
    public Sprite Player2;
    //�\������摜�����ׂē����

    public bool tamahueSkill = false;

    public bool tajyuutaisaku = false;//���d�ł��΍��p

    bool hukuseimati = false;//�X�L���̋����I���΍� 
    int hukuseinokori = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Time.captureFramerate = 30;//�t���[�����[�g�H
        hukuseimati = false;
        hukuseinokori = 0;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "teki1Prefab(Clone)" || coll.gameObject.name == "teki2Prefab(Clone)" || coll.gameObject.name == "teki3Prefab(Clone)")  //�G�ꂽ�����G�������ꍇ�̏���
        {
            Destroy(coll.gameObject);   //�Ƃ肠���������������������

            //��������_���[�W����̃v���O���������
            Debug.Log("�_���[�W���󂯂�");
            MYHP.GetComponent<MYHP>().MYdame();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = tmp.x

     

        if (Input.GetKey(KeyCode.LeftArrow))   //���̖��L�[�������ꂽ���̏���
        {
            transform.Translate(-0.015f, 0, 0);   //1�t���[���̊Ԃ�-0.1����X���W������
            
        }

        if (Input.GetKey(KeyCode.RightArrow))   //�E�̖��L�[�������ꂽ���̏���
        {
            transform.Translate(0.015f, 0, 0);   //1�t���[���̊Ԃ�0.1����X���W������
            
        }

        if (Input.GetKey(KeyCode.UpArrow))     //��̖��L�[�������ꂽ���̏���
        {
            transform.Translate(0, 0.015f, 0);   //1�t���[���̊Ԃ�0.1����Y���W������
            
        }

        if (Input.GetKey(KeyCode.DownArrow))     //���̖��L�[�������ꂽ���̏���
        {
            transform.Translate(0, -0.015f, 0);   //1�t���[���̊Ԃ�-0.1����Y���W������
            
        }


        if (transform.position.x <= -10)            //��O�ړ��΍�
        {
            transform.Translate(0.015f, 0, 0);
        }
        if (transform.position.x >= 10)
        {
            transform.Translate(-0.015f, 0, 0);
        }
        if (transform.position.y >= 4)
        {
            transform.Translate(0, -0.015f, 0);
        }
        if (transform.position.y <= -4)
        {
            transform.Translate(0, 0.015f, 0);
        }                                           //��O�ړ��΍�


        if (Input.GetKeyDown(KeyCode.Space) && tajyuutaisaku == false)    //�X�y�[�X�L�[���������Ƃ��ɃC���X�^���X�����������tama���w��̓���œ���
        {
            tajyuutaisaku = true;
            spriteRenderer.sprite = Player2;//�������Ƃ��̉摜�ɂ���
            //Debug.Log("tamauuuu");
            //if ()

            Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 90));   //�C���X�^���XtamaPerhab�̕�����V������肱�̃I�u�W�F�N�g�Ɠ������W�ɍ쐬����

            if (tamahueSkill == true)//�X�L����ON�̂Ƃ��̏���
            {
                Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 100));
                Instantiate(tamaPerhab, transform.position, Quaternion.Euler(0, 0, 80));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))      //�X�y�[�X�L�[�������ꂽ�Ƃ��̏���
        {
            tajyuutaisaku = false;
            spriteRenderer.sprite = Player1;//�L�[�𗣂����Ƃ��ɂ��Ƃɖ߂�
        }
    }

    public void tamazousyoku()
    {
        if (hukuseimati != true)
        {
            hukuseimati = true;
            tamahueSkill = true;
            Invoke("SkillTime", 10);
        }
        else
        {
            hukuseinokori++;
        }
    }
    public void SkillTime()
    {
        if (hukuseinokori > 0)//0����ȃ����@
        {
            Debug.Log("�����X�L�������A�c��" + hukuseinokori);
            hukuseinokori--;    //1���炷
            Invoke("SkillTime", 10);
        }
        else
        {
            hukuseimati = false;
            tamahueSkill = false;
            Debug.Log("�����X�L���I���");
        }
        
    }

    public void PlayerCrystal()//�v���C���[�̍폜����
    {

        gameObject.SetActive(false);
    }
}
