using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGuide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//å©Ç¶Ç»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
    }

    public void DasuYO()
    {
        gameObject.SetActive(true);
        Invoke("KesuYO", 3);//3ïaå„Ç…è¡Ç∑Ç‚Ç¬
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
