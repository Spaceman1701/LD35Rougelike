using UnityEngine;
using System.Collections;
using System;

public class ArmAnimation : MonoBehaviour, Animate {

    public float frameTime;

    public bool positiveFirst;

    public int frame;
    public int numFrames;

    public float totalMovement;

    private float perFrameMove;

    public bool running = false;

    public bool movingNeg;
    public bool movingPos;

    public void Start()
    {

        perFrameMove = totalMovement / numFrames;
    }

    public void StartAnimate()
    {
        if (!running)
        {
            running = true;

            InvokeRepeating("NextFrame", 0.0f, frameTime);
        }
    }

    private void NextFrame()
    {
        if (frame < numFrames/4 || frame > 3*numFrames/4)
        {
            if (positiveFirst)
            {
                MovePositive();
            } else
            {
                MoveNegative();
            }

        }
        else if (frame > numFrames / 4 && frame < 3 * numFrames / 4)
        {
            if (positiveFirst)
            {
                MoveNegative();
            } else
            {
                MovePositive();
            }
        }

        if (frame == numFrames)
        {
            frame = 0;
            transform.localPosition = new Vector3(0, 0, 0);
        }

        frame++;
    }

    private void MovePositive()
    {
        transform.localPosition += new Vector3(0, perFrameMove, 0);
        movingNeg = false;
        movingPos = true;
    }

    private void MoveNegative()
    {
        transform.localPosition -= new Vector3(0, perFrameMove, 0);
        movingNeg = true;
        movingPos = false;
    }

    public void StopAnimate()
    {
        if (running)
        {
            CancelInvoke("NextFrame");
            running = false;
        }
    }
}
