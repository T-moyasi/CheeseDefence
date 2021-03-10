using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerHP;
    bool _isZero = false;
    SpriteRenderer _renderer;
    public GameObject playerLife1, playerLife2, playerLife3, playerLife4, playerLife5;
    void Start()
    {
        playerHP = 5;
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Damage(int atacckPoint)
    {
        playerHP -= atacckPoint;
        if (playerHP < 0)
            playerHP = 0;

        switch (playerHP)
        {
            case 4:
                _renderer.sprite = Resources.Load<Sprite>("Images/part1");
                playerLife5.SetActive(false);
                break;
            case 3:
                _renderer.sprite = Resources.Load<Sprite>("Images/part1");
                _renderer.sprite = Resources.Load<Sprite>("Images/part2");
                playerLife5.SetActive(false);
                playerLife4.SetActive(false);
                break;
            case 2:
                _renderer.sprite = Resources.Load<Sprite>("Images/part1");
                _renderer.sprite = Resources.Load<Sprite>("Images/part2");
                _renderer.sprite = Resources.Load<Sprite>("Images/part3");
                playerLife5.SetActive(false);
                playerLife4.SetActive(false);
                playerLife3.SetActive(false);
                break;
            case 1:
                _renderer.sprite = Resources.Load<Sprite>("Images/part1");
                _renderer.sprite = Resources.Load<Sprite>("Images/part2");
                _renderer.sprite = Resources.Load<Sprite>("Images/part3");
                _renderer.sprite = Resources.Load<Sprite>("Images/part4");
                playerLife5.SetActive(false);
                playerLife4.SetActive(false);
                playerLife3.SetActive(false);
                playerLife2.SetActive(false);
                break;
            case 0:
                _renderer.sprite = Resources.Load<Sprite>("Images/part1");
                _renderer.sprite = Resources.Load<Sprite>("Images/part2");
                _renderer.sprite = Resources.Load<Sprite>("Images/part3");
                _renderer.sprite = Resources.Load<Sprite>("Images/part4");
                _isZero = true;
                gameObject.SetActive(false);
                playerLife5.SetActive(false);
                playerLife4.SetActive(false);
                playerLife3.SetActive(false);
                playerLife2.SetActive(false);
                playerLife1.SetActive(false);
                break;
            default:
                break;
        }
    }
    public bool _isGameOver()
    {
        if (_isZero)
            return true;
        return false;
    }
    public int getleftHP()
    {
        return playerHP;
    }
}
