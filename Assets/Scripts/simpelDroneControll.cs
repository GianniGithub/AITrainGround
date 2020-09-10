using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpelDroneControll : MonoBehaviour
{
    public float speed;
    public Rigidbody2D thisBody;
    void Start()
    {
        thisBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var rotateDir = Input.GetAxis("Horizontal");
        //actionsOut[1] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        var dirToGo = Input.GetAxis("Vertical");

        move(rotateDir, dirToGo);
    }
    public void move(float rotateDir, float dirToGo)
    {
        switch (dirToGo)
        {
            case 1:
                dirToGo = 1;
                break;
            case 2:
                dirToGo = -0.8f;
                break;
        }

        switch (rotateDir)
        {
            case 1:
                rotateDir = 1;
                break;
            case 2:
                rotateDir = -1;
                break;
        }

        var dir = new Vector3(0, 0, rotateDir * Time.deltaTime * 90f);
        transform.Rotate(dir);
        transform.Translate(Vector2.up * speed * dirToGo * Time.deltaTime);
    }
}
