using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLabelText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//‰B‚·
    }

    public void LabelHyouji()//dasu
    {
        gameObject.SetActive(true);
    }

    public void LabelKesu()//kesu
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
