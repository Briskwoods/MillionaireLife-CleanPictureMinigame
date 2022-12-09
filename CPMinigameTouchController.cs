using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPMinigameTouchController : MonoBehaviour
{
    public bool m_isDragging;
    private Vector2 m_startTouch;


    void Update()
    {

        #region PC Controls
        //PC Controls Test Code, uncoomment if you wish to Test with a mouse instead of Unity Remote 5

        switch (Input.GetMouseButtonDown(0))
        {
            case true:
                m_isDragging = true;
                m_startTouch = Input.mousePosition;
                break;
            case false:
                break;
        }

        switch (Input.GetMouseButtonUp(0))
        {
            case true:
                m_isDragging = false;
                Reset();
                break;
            case false:
                break;
        }
        #endregion

        #region Mobile Controls
        switch (Input.touches.Length > 0)
        {
            case true:
                switch (Input.touches[0].phase == TouchPhase.Began)
                {
                    case true:
                        m_isDragging = true;
                        Vibration.VibratePeek();
                        m_startTouch = Input.touches[0].position;
                        break;
                    case false:
                        break;
                }
                switch (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    case true:
                        m_isDragging = false;
                        Reset();
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
        #endregion
    }

    private void Reset()
    {
        m_startTouch = Vector2.zero;
        m_isDragging = false;
    }
}
