using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGuide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//見えないようにする
    }

    public void DasuYO()
    {
        gameObject.SetActive(true);
        Invoke("KesuYO", 3);//3病後に消すやつ
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
