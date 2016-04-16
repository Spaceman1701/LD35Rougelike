using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class HumanAnimation : MonoBehaviour, Animate {

    public Sprite[] frames;

    private int currentFrame = 0;

    public float frameTime;

    public bool running = false;

    public bool startRunning = false;

    public void Start()
    {
        if (startRunning)
        {
            StartAnimate();
        }
    }
    
    
    public void StartAnimate()
    {
        InvokeRepeating("NextFrame", 0.0f, frameTime);
        running = true;
    }

    public void StopAnimate()
    {
        CancelInvoke("NextFrame");
        running = false;
    }

    private void NextFrame()
    {
        if (currentFrame < frames.Length-1)
        {
            currentFrame++;
        } else
        {
            currentFrame = 0;
        }
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.sprite = frames[currentFrame];
    }	
	// Update is called once per frame
	void Update () {
	    
	}
}
