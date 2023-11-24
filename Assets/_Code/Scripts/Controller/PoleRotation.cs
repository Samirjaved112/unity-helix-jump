using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleRotation : MonoBehaviour
{
    private Vector2 touchStartPos;
    private bool isSwiping = false;

    void Update()
    {
        if (!BallBehaviour.isGameOver)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Check for the start of a touch
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                    isSwiping = true;
                }

                // Check if the finger is still swiping
                if (isSwiping && touch.phase == TouchPhase.Moved)
                {
                    // Calculate swipe direction
                    Vector2 swipeDelta = touch.position - touchStartPos;

                    // Calculate rotation based on swipe distance
                    float rotationAmount = -swipeDelta.x / Screen.width * 360f;

                    // Apply rotation to the pole
                    transform.Rotate(Vector3.up, rotationAmount);

                    // Update touch start position for the next frame
                    touchStartPos = touch.position;
                }

                // Check for the end of touch
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isSwiping = false;
                }
            }
        }
    }

}
