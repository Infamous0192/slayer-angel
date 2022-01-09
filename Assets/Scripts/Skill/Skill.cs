using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    public string Name = "";
    public float ManaCost = 0;
    public float Cooldown = 0;

    [HideInInspector] public Player player;
    [HideInInspector] public Animator animator;

    public virtual void OnStart() { }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = player.GetComponent<Animator>();
        OnStart();
    }
}
