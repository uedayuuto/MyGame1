using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGuide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//�����Ȃ��悤�ɂ���
    }

    public void DasuYO()
    {
        gameObject.SetActive(true);
        Invoke("KesuYO", 3);//3�a��ɏ������
    }

    public void KesuYO()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
