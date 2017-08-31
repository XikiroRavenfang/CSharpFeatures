using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    private AudioSource sound;

    // Use this for initialization
    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision ball)
    {
        if(ball.gameObject.tag == "Ball")
        {
            sound.Play();
            score++;
            Destroy(ball.gameObject);
        }
    }
}
