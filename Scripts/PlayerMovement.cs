using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    SpriteRenderer playerSpriteRender;
    float LimitDown()
    {
        return -CameraBounds().y + playerSpriteRender.bounds.extents.y;
    }

    float LimitUp()
    {
        return CameraBounds().y - playerSpriteRender.bounds.extents.y;
    }

    Vector2 CameraBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = transform.position.x;
        mousePosition.y = Mathf.Clamp(mousePosition.y, LimitDown(), LimitUp());
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }

}
