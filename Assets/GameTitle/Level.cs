using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int GameLevel = 0;    //���L�\�ȕϐ��i�Q�[��level�j
    //LevelLabel.text = "1 level";

    public Text LevelLabel;

    public static int getL()//level�̕ϐ������J���鏈��
    {
        return GameLevel;
    }

    public void OnClick()
    {
        GameLevel += 1;
        if (GameLevel > 2) GameLevel = 0;//level�̃��[�v�I������

        if (GameLevel == 0)
        {
            //level�P�̏���
            LevelLabel.text = "1 Level";
        }
        if (GameLevel == 1)
        {
            //level�Q�̏���
            LevelLabel.text = "2 Level";
        }
        if (GameLevel == 2)
        {
            //level�R�̏���
            LevelLabel.text = "3 Level";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelLabel.text = "1 Level";
        GameLevel = 0;//����������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
