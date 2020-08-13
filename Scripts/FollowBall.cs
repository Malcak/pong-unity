using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{

    public Transform ball;
    public float speed;

    SpriteRenderer enemySpriteRender;

    float LimitDown()
    {
        return -CameraBounds().y + enemySpriteRender.bounds.extents.y;
    }

    float LimitUp()
    {
        return CameraBounds().y - enemySpriteRender.bounds.extents.y;
    }

    Vector2 CameraBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<BallBehaviour>().gameStarted)
        {
            float yOffset = 0f;
            if(transform.position.y < ball.position.y)
            {
                yOffset = transform.position.y + speed * Time.deltaTime;
            } else if(transform.position.y > ball.position.y)
            {
                yOffset = transform.position.y - speed * Time.deltaTime;
            }
            transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Clamp(yOffset,LimitDown(), LimitUp()),
                    transform.position.z);
        }
    }
}
