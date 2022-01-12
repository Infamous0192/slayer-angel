using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
  public float depth = 1f;

  private RectTransform rt;
  private Player player;
  private float length;

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    rt = GetComponent<RectTransform>();
    length = rt.rect.width;
  }

  private void FixedUpdate() {
    float realVelocity = player.MovementSpeed / (depth * 100);
    Vector2 pos = transform.position;

    pos.x -= realVelocity * Time.fixedDeltaTime;

    if (transform.position.x < -length) pos.x = length;

    transform.position = pos;
  }
}
