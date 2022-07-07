using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//スクリーン関係の処理をできるようにする

public class GamesStart : MonoBehaviour
{

    public void OnClick()
    {
        Debug.Log("kuril");
        SceneManager.LoadScene("SampleScene");//ゲームスタート
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
