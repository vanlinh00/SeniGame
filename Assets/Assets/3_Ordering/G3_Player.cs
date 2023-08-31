using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G3_Player : MonoBehaviour
{
    private Vector2 initialTouchPosition;
    private bool isRotating = false;
    private float rotationSpeed = 10.0f;
    public float smoothFactor = 0.1f; // Độ mượt của góc xoay

    private float currentAngle = 0.0f; // Góc hiện tại

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initialTouchPosition = touch.position;
                    isRotating = true;
                    currentAngle = transform.eulerAngles.z;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        Vector2 currentPosition = touch.position;
                        Vector2 direction = currentPosition - initialTouchPosition;
                        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

                        // Làm mượt góc xoay bằng phép tích hợp
                        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, smoothFactor);

                        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

                        initialTouchPosition = currentPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }

}

