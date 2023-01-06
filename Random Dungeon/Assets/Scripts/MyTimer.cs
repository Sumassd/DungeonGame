using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 计时器类
/// </summary>
public class MyTimer
{
    ///计时器状态
    public enum STATE
    {
        PAUSE, RUN, FINISH
    }
    public STATE timerState;
    public float duration;//计时时段
    public float elapsedTime;
    private bool isFinish;

    public bool IsFinish { get { if (timerState == STATE.FINISH) return true; return false; } }

    ///初始化
    public MyTimer(float dura)
    {
        duration = dura;
        timerState = STATE.PAUSE;
    }
    ///实时嘀嗒
    public void Tick()
    {
        switch (timerState)
        {
            case STATE.PAUSE:

                break;
            case STATE.RUN:
                if (elapsedTime < duration)
                {
                    elapsedTime += Time.deltaTime;
                }
                else
                {
                    timerState = STATE.FINISH;
                }
                break;
            case STATE.FINISH:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 开始计时
    /// </summary>
    public void Go()
    {
        isFinish = false;
        elapsedTime = 0;
        timerState = STATE.RUN;
    }
    ///开始计时(更改时段)
    public void Go(float duration)
    {
        isFinish = false;
        this.duration = duration;
        elapsedTime = 0;
        timerState = STATE.RUN;
    }

}
