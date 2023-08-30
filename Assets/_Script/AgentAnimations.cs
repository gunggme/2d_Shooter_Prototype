using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator agentAnimator;

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnimator(bool val)
    {
        agentAnimator.SetBool("Walk", val);
    }

    public void AnimatePlayer(float velocity)
    {
        if (velocity > 0)
        {
            SetWalkAnimator(true);
        }
        else
        {
            SetWalkAnimator(false);
        }
    }
}
