using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float strength,gravity;
    private Rigidbody2D directionRb;
    private Vector3 direction;
    //private Vector3 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
       void Start()
    {
        InvokeRepeating(nameof(AnimatedSprite), 0.15f, 0.15f);
        gravity = -9.5f;
        strength = 5f;
       // directionRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
           // transform.position += Vector3.up * strength * Time.deltaTime;
            direction = Vector3.up * strength;
        }
       transform.position += direction * Time.deltaTime;
       // y = gravity * Time.deltaTime;
        direction.y += gravity * Time.deltaTime;
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
}