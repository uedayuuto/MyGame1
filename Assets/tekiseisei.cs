using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekiseisei : MonoBehaviour
{

    public GameObject teki1Prefab;
    public GameObject teki2Prefab;
    public GameObject teki3Prefab;  //�o�ꂳ����I�̌^������I�u�W�F�N�g�v���p�e�B���쐬����

    public int seiseiTime;
    public int Randomsuuji;

    int muzukasisa;//�G�̐������x�Ɋ֌W����ϐ������

    float Power;

    // Start is called before the first frame update
    void Start()
    {
        muzukasisa = Level.getL();  //int 0-2 �܂�
        //Level�̃X�N���v�g�t�@�C���ŏ������ϐ����擾����mizukasisa�̕ϐ��ɑ}������
        if (muzukasisa == 0) Power = 0.3f;
        if (muzukasisa == 1) Power = 0.2f;
        if (muzukasisa == 2) Power = 0.15f;

        InvokeRepeating("GenRock", 1, Power);   //������GenRock�֐��𓮂����^�C�}�[�����(�֐��̖��O,�@������,�@�������ԊԊu)
    }

    void GenRock()
    {
        Randomsuuji = Random.Range(1, 3 + 1);   //�P����R�܂ł�int�^�̗����𐶐�����

        if (Randomsuuji == 3)      //�P��teki�𐶐�����
        {
            Instantiate(teki1Prefab, new Vector3(           //Prefab����ɂ��Ĉȉ��̍��W�ɓG�𐶐�����
                                                12f,                        //X���̍��W
                                                Random.Range(-4.4f, 4.4f),  //Y���̍��W
                                                0),                         //Z���̍��W
                                                Quaternion.identity);
        }
        if (Randomsuuji == 2)  //�Q��teki�𐶐�����
        {
            Instantiate(teki2Prefab, new Vector3(           //Prefab����ɂ��Ĉȉ��̍��W�ɓG�𐶐�����
                                                12f,                        //X���̍��W
                                                Random.Range(-4.4f, 4.4f),  //Y���̍��W
                                                0),                         //Z���̍��W
                                                Quaternion.identity);
        }
        if (Randomsuuji == 1)  //�R��teki�𐶐�����
        {
            Instantiate(teki3Prefab, new Vector3(           //Prefab����ɂ��Ĉȉ��̍��W�ɓG�𐶐�����
                                                12f,                        //X���̍��W
                                                Random.Range(-4.4f, 4.4f),  //Y���̍��W
                                                0),                         //Z���̍��W
                                                Quaternion.identity);
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
