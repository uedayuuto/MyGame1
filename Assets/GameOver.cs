using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//スクリーン関係の処理をできるようにする

public class GameOver : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite Over;
    public Sprite Clear;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GameOverText()  //ゲームオーバーになったときにゲームオーバーのテキストを出す
    {
        spriteRenderer.sprite = Over;
        //画像をオーバーに変える
        gameObject.SetActive(true);
        Player.GetComponent<Player>().PlayerCrystal();//プレイヤーを消す処理
        Invoke("SceneChange", 2);
    }
    public void GameClear()
    {
        spriteRenderer.sprite = Clear;      //クリア画像を作る
        //画像をクリアテキストに変える
        gameObject.SetActive(true);
        Player.GetComponent<Player>().PlayerCrystal();//プレイヤーを消す処理
        Invoke("SceneChange", 2);
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("GameEnd");//ゲームエンドのシーンにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
