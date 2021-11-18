using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private float _movementSpeed;
    public float MovementSpeed {
        get => _movementSpeed; set => _movementSpeed = value;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector2 temp = transform.position;

        transform.position = new Vector2(temp.x + 0.1f, temp.y);
    }
}
