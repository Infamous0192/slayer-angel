using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    public BoxCollider2D box;
    public Player player;
    public float depth = 1f;

    private float length;

    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start() {
        box = GetComponent<BoxCollider2D>();
        length = box.size.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float realVelocity = player.MovementSpeed / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (transform.position.x < -length) pos.x = length;

        transform.position = pos;
    }
}
