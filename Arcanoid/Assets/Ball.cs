using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float Speed;
    public GameObject Paddle;

    public GameObject HitItem1;
    public GameObject HitItem2;
    public GameObject BackBoard;

    public Text GameText;

    public Text ScoreText;

    public int Score = 0;

    public Color _newColour;
    public GameObject WantedSprite;

    // Use this for initialization
    void Start()
    {
        int direction = Random.Range(1, 3);
        Debug.Log(direction);
        if (direction == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * Speed;
        }
        else if (direction == 2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * Speed;
        }

    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth)
    {

        return (ballPos.x - racketPos.x) / racketWidth;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + Score;
        GameText.text = "";
        if (Score == 1000)
        {
            GameText.text = "You Win";
        }

        SpriteRenderer component = WantedSprite.GetComponent<SpriteRenderer>();

        _newColour.r = Random.Range(0, 1.0f);
        _newColour.g = Random.Range(0, 1.0f);
        _newColour.b = Random.Range(0, 1.0f);
        _newColour.a = 1;

        Debug.Log("Colour set to " + component.color.ToString());

        component.color = _newColour;

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject == Paddle)
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * Speed;
        }

        if (col.gameObject == HitItem1 || col.gameObject== HitItem2)
        {
            if (col.gameObject == HitItem1)
            {
                
            }
            if (col.gameObject == HitItem2)
            {
                
            }
            Score += 250;
            

            if (col.gameObject == BackBoard)
            {
                Destroy(this.gameObject);
                GameText.text = "You Lose";
            }


        }
    }
}