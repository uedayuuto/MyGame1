using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�X�N���[���֌W�̏������ł���悤�ɂ���

public class GamesStart : MonoBehaviour
{

    public void OnClick()
    {
        Debug.Log("kuril");
        SceneManager.LoadScene("SampleScene");//�Q�[���X�^�[�g
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
