using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config reference
    [SerializeField] Paddle paddle0;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] float randomVelocity = 0.2f;

    //variables
    Vector2 paddleToBallVector;
    bool gameStarted = false;

    //Reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle0.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            StickToPaddle();
            LaunchBall();
        } 
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(2f, 15f);
            gameStarted = true;
        }
    }

    void StickToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle0.transform.position.x, paddle0.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityChange = new Vector2(UnityEngine.Random.Range(0f, randomVelocity), UnityEngine.Random.Range(0f, randomVelocity));
        if(gameStarted)
        {
            AudioClip sound = sounds[UnityEngine.Random.Range(0, sounds.Length)];
            myAudioSource.PlayOneShot(sound);
            myRigidBody.velocity += velocityChange;
        }  
    }
}
