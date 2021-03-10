using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameEvent _event;
    //y+-100,x+-90
    const float cheeseH = 1.5f, cheeseW = 1.5f;
    int life = 0, hitStop = 5, delayTime = 0, atacckPoint = 0, scorePoint = 0;
    private static GameObject _cheese = null;
    Vector2 chz , selfPosition, velocity;
    float dir = 0.0f, spd = 0.0f;
    private Rigidbody2D _rigidbody2D;
    bool _isHitStop = false,_isAtacck = false;
    public void Start()
    {
        if (_cheese == null)
        {
            _cheese = GameObject.FindWithTag("Goal");
        }
        chz = _cheese.transform.position;
        selfPosition = gameObject.transform.position;
 
        dir = Mathf.Atan2((chz.y - selfPosition.y), (chz.x - selfPosition.x)) *Mathf.Rad2Deg;
        velocity.x = Mathf.Cos(Mathf.Deg2Rad * dir)*spd;
        velocity.y = Mathf.Sin(Mathf.Deg2Rad * dir)*spd;

        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = this.velocity;

    }

    public void Update()
    {
        selfPosition = gameObject.transform.position;
        if (_isHitStop)
        {
            _rigidbody2D.velocity = Vector2.zero;
            hitStop -= 1;
            if (hitStop <= 0)
            {
                _isHitStop = false;
                hitStop = 5;
                _rigidbody2D.velocity = this.velocity;
            }
        }
        check();
    }
    void check()
    {
        if (_isAtacck)
        {
            delayTime -= 1;
            if (delayTime <= 0)
            {
                _cheese.GetComponent<Player>().Damage(atacckPoint);
                Destroy(gameObject);
            }
        }

    }

    public void OnMouseDown()
    {
        life -= 1;
        if (life <= 0)
        {
            GameEvent.addScore(scorePoint);
            Destroy(gameObject);
        }
        else
        {
            _isHitStop = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            _rigidbody2D.velocity = Vector2.zero;
            this.velocity = Vector2.zero;
            _isAtacck = true;
            delayTime = 30;
            Debug.Log("atacck");
        }
    }

    public int Life
    {
        set { life = value; }
        get { return life; }
    }
    public float Spd
    {
        set { spd = value; }
    }
    public int AtacckPoint
    {
        set { atacckPoint = value; }
    }
    public int ScorePoint
    {
        set { scorePoint = value; }
    }
}
