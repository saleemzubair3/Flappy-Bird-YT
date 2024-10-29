using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float strength,gravity,up,down,x,amp,y,c,r;
    private Rigidbody2D directionRb;
    private Vector3 direction,a,b, currentRotation;
    private bool isRotated = false;
    public bool isGameStart = false;
    public AudioSource audioSourceWin,audioSourceLose;
    public GameObject pipeStart;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
       void Start()
    {
        InvokeRepeating(nameof(AnimatedSprite), 0.15f, 0.15f);
        
        gravity = -11.5f;
        strength = 3f;
       
       // directionRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGameStart)
        {
           
            x = 0;
            if (Input.touchCount>0||Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isRotated = false;
                // transform.position += Vector3.up * strength * Time.deltaTime;
                direction = Vector3.up * strength;
                if (!isRotated)
                {
                    x = 35;
                    // Rotate the object to 45 degrees around the Y-axis
                    transform.rotation = Quaternion.Euler(0, 0,35);
                    isRotated = true;
                }

                /*else
                {
                    // Reset the rotation back to 0 degrees
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }*/

                // Toggle the rotation state
               // isRotated = !isRotated;

            }

            transform.position += direction * Time.deltaTime;

            // y = gravity * Time.deltaTime;
            direction.y += gravity * Time.deltaTime;
            if (direction.y+3 < 0 && isRotated)
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, 270, ref r, 0.2f);
                Debug.Log(angle);
                transform.rotation = Quaternion.Euler(0, 0, angle);
                if (angle == 270)
                {
                    isRotated = false;
                    Debug.Log("90angle");
                }
                
                //transform.rotation = Quaternion.FromToRotation(a,b);
                /*if (direction.y < 0 && transform.position.y < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    isRotated = false;
                }*/
            }


        }

        else
        {
            UpsAndDown();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isGameStart = true;
                pipeStart.SetActive(true);
            }
        }
        
    }
    private void UpsAndDown()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(8*Time.time) * 0.1f, 0);
        
    }
   
    private void AnimatedSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obsacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            audioSourceLose.Play();
        }
        else if (collision.gameObject.tag == "score")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            audioSourceWin.Play();
        }
    }
}