using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    float moveSpeed = 3;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool speedUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += getMove();

        pos = setBoundaries(pos);

        transform.position = pos;
    }

    private Vector2 getMove()
    {

        float moveAmount = moveSpeed * Time.deltaTime;

        if (speedUp)
        {
            moveAmount *= 3;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        return move;
    }

    private Vector2 setBoundaries(Vector2 pos)
    {
        if (pos.x < -7.8f)
        {
            pos.x = -7.8f;
        }

        if (pos.x > 8.9f)
        {
            pos.x = 8.9f;
        }

        if (pos.y < -3.3f)
        {
            pos.y = -3.3f;
        }

        if (pos.y > 5.6f)
        {
            pos.y = 5.6f;
        }

        return pos;
    }
}
