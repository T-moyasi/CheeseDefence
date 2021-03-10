using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//敵の生成や終了キーの設定とか
public class GameEvent : MonoBehaviour
{
    public Text text,clearText,scoreText;
    public Player player;
    static int score = 0, leftHP = 0;
    GameObject pR, pY, pB;
    int ntime = 0;
    float time = 0f, clearTime = 30f;
    // Update is called once per frame
    private void Awake()
    {
        pR = (GameObject)Resources.Load("Prefabs/nezumi_red");
        pB = (GameObject)Resources.Load("Prefabs/nezumi_blue");
        pY = (GameObject)Resources.Load("Prefabs/nezumi_yellow");
        ntime = (int)clearTime;
        text.text = ((int)ntime).ToString();
        scoreText.text = score.ToString();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            time -= 1f;
            ntime--; 
            Debug.Log("time:"+ntime);
            text.text = ((int)ntime).ToString();
            EGenerator();
        }
        scoreText.text = score.ToString();
        //終了処理
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
            #endif
        }

        //クリア条件
        if (player._isGameOver())
        {
            GameOver();
        }
        if (ntime <= 0)
        {
            GameClear();
        }
    }
    void EGenerator()
    {
        Quaternion quaternion = Quaternion.identity;
        //時間を見ながらR多くYそれなりB1体生成
        if (ntime % 2 == 1)
        {
            //R
            int inst = RNumGenerator();
            Vector2 rCordinate;
            for (int i = 1; i <= inst; i++)
            {
                //Debug.Log("test " + i);
                rCordinate= RandCoordinate(1);
                Instantiate(pR,rCordinate,quaternion);
            }
        }
        if (ntime % 5 == 2)
        {
            //Y2
            Vector2 yCordinate = RandCoordinate(2);
            Instantiate(pY,yCordinate,quaternion);
        }
        if (ntime  == 5)
        {
            //B
            Instantiate(pB);
        }
        //Debug.Log("ok");
        
        
    }

    int RNumGenerator()
    {       
        int inst= (int)Random.Range(1, 3);
        //Debug.Log(inst);
        return inst;
    }
    Vector2 RandCoordinate(int EType)
    {
        int LoR;
        Vector2 inst;
        LoR = Random.Range(0, 2);
        if (LoR == 0)
        {
            //left
            inst.x = Random.Range(-6, -4);
            inst.y = Random.Range(-4.5f,4.5f);
        }
        else
        {
            //right
            inst.x = Random.Range(4, 6);
            inst.y = Random.Range(-4.5f, 4.5f);
        }
        return inst;
    }

    void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene("clear");
    }
    void GameClear()
    {
        leftHP = player.getleftHP();
        Debug.Log("Clear");
        SceneManager.LoadScene("clear");
    }

    public static void addScore(int point)
    {
        score += point;
    }
    public static int getScore()
    {
        return score;
    }
    public static int getLeftHP()
    {
        return leftHP;
    }
}
