using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MYSKILL : MonoBehaviour
{
    public GameObject SkillImage;
    Slider Skill;

    // Start is called before the first frame update
    void Start()
    {
        Skill = GetComponent<Slider>();
        Skill.value = 0;

        //SkillImage.GetComponent<SkillMov>().SkillSelect();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillPoint()    //�X�L���|�C���g���󂯎�����Ƃ��̏���
    {
        //Skill = GetComponent<Slider>();
        Skill.value += 2;
        if (Skill.value >= 100)
        {
            Debug.Log("�X�L�������܂�����");
            Skill.value = 0;
            SkillImage.GetComponent<SkillMov>().SkillSelect(); //�X�L���̒��I�����ɓ���X�N���v�g�ɓn��
        }
        
    }
}
