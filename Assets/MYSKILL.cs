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

    public void SkillPoint()    //スキルポイントを受け取ったときの処理
    {
        //Skill = GetComponent<Slider>();
        Skill.value += 2;
        if (Skill.value >= 100)
        {
            Debug.Log("スキルが溜まったよ");
            Skill.value = 0;
            SkillImage.GetComponent<SkillMov>().SkillSelect(); //スキルの抽選処理に入るスクリプトに渡す
        }
        
    }
}
