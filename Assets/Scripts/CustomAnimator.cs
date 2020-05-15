﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] private Animator Torso;
    [SerializeField] private Animator Legs;
    [Space]
    [SerializeField] private SpriteRenderer TorsoRenderer;
    [SerializeField] private SpriteRenderer LegsRenderer;
    [Space]
    [SerializeField] private Mover Mover;

    /// <summary>
    /// Plays idle animations
    /// </summary>
    /// <param name="direction"> the direction the player is looking at</param>
    public void Idle(int direction)
    {
        SetDirection(direction);
        Legs.SetBool("Idle", true);
    }

    /// <summary>
    /// Plays walk animations
    /// </summary>
    /// <param name="direction"></param>
    public void Walk(int direction)
    {
        SetDirection(direction);
        Legs.SetBool("Idle", false);
    }

    /// <summary>
    /// Plays jump animations
    /// </summary>
    public void Jump()
    {
        if (!Torso.GetBool("Melee Attacking"))
        {
            Torso.SetTrigger("Jump");
            Legs.SetTrigger("Jump");
        }
    }

    public void Fall()
    {
        Torso.SetBool("Falling", true);
    }

    /// <summary>
    /// Reverts back to walk/idle animations
    /// </summary>
    public void Land()
    {
        Torso.SetBool("Jumping", false);
        Torso.SetBool("Falling", false);
    }

    public void MeleeAttack()
    {
        Torso.SetTrigger("Melee Attack");
        Torso.SetBool("Melee Attacking", true);
    }

    /// <summary>
    /// Flips the sprite renderer based on the direction the player is looking at
    /// </summary>
    /// <param name="direction"></param>
    private void SetDirection(int direction)
    {
        switch(direction)
        {
            case 1:
                TorsoRenderer.flipX = false;
                LegsRenderer.flipX = false;
                break;
            case -1:
                TorsoRenderer.flipX = true;
                LegsRenderer.flipX = true;
                break;
            default:
                throw new System.Exception("Direction is not an acceptable value");
        }
    }
}