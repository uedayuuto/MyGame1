using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    int s;//��ʂɏo���X�R�A�̕ϐ�
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        s = UiScript.getA();
        text.text = "�X�R�A:" + s.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
