using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float MovementSpeed = 1f;
    public KeyCode RightButton = KeyCode.RightArrow;
    public KeyCode LeftButton = KeyCode.LeftArrow;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(RightButton)) {
            MovementSpeed += 0.2f;
        }

        if (Input.GetKey(LeftButton)) {
            MovementSpeed -= 0.2f;
        }
    }
}
