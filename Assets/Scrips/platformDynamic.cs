using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformDynamic : MonoBehaviour
{
    
    public float leftPositionX;
    public float rightPositionX;
    public float upPositionY;
    public float downPositionY;
    public float platformSpeedRight=0.03f;
    public float platformSpeedUp=0.03f;

    public bool moveRight;
    public bool moveUp;
    
    
    // Update is called once per frame

    void Update()
    {
        if (transform.localPosition.x < leftPositionX)
        {
            moveRight = true;
        }else if (transform.localPosition.x > rightPositionX)
            moveRight = false;
        
        if (transform.localPosition.y < downPositionY)
        {
            moveUp = true;
        }else if (transform.localPosition.y > upPositionY)
            moveUp = false;
        
        if(moveRight==true)transform.localPosition = new Vector2(transform.localPosition.x + platformSpeedRight, transform.localPosition.y);
        else transform.localPosition = new Vector2(transform.localPosition.x - platformSpeedRight, transform.localPosition.y);
        
        if(moveUp==true)transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + platformSpeedUp);
        else transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y-platformSpeedUp);
    }

    private void OnCollisionEnter2D(Collision2D otherSprite)
    {
        otherSprite.collider.transform.SetParent(transform);
    }
    
    private void OnCollisionExit2D(Collision2D otherSprite)
    {
        otherSprite.collider.transform.SetParent(null);
    }
}
