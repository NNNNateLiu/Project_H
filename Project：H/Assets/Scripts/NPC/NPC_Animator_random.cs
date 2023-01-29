using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animator_random : MonoBehaviour
{
    private Animator animator;

    public enum State
    {
        Idle,
        Npc7_Talk,
        Npc7_Laugh,
    }
    public string[] NPC7AnimationList;
    public string Idle;
    public string Npc7_Talk;
    public string Npc7_Laugh;

    public State CurrentState = State.Idle;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }


    void Update()
    {
    }
}
