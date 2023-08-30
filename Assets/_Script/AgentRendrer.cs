using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRendrer : MonoBehaviour
{
    protected SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerinput)
    {
        var direction = (Vector3)pointerinput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if (result.z > 0)
        {
            sr.flipX = true;
        }
        else if(result.z < 0)
        {
            sr.flipX = false;
        }
    }
}
