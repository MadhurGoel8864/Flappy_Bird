using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    private Vector3 direction;
    public Sprite[] sprites;
    private int spriteIndex;
    public GameManager abc;

    public float gravity = -9.8f;
    private SpriteRenderer spriteRenderer;
    
    public float strength= 5f;

    [SerializeField] Text Score_Text;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ) || Input.GetMouseButtonDown(0))
        {
            //direction.y += strength* Time.deltaTime;

            direction = Vector3.up * strength;
            print('a');
        }    
        if(Input.touchCount > 0)
        {
        Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
            direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;


    }

    private void OnEnable()
    {
        Vector3 postion = transform.position;
        postion.y = 0f;
        transform.position = postion;
        direction = Vector3.zero;
    }





    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag=="Obstacle") {
            FindObjectOfType<GameManager>().gameEnd();
                }
        else if( collision.gameObject.tag=="Scoring") {


            FindObjectOfType<GameManager>().IncreaseScore();
            Score_Text.text = "Score: " + abc.score;
                }

    }
}
