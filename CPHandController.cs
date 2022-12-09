using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CPHandController : MonoBehaviour
{
    // Raycast Control Variable
    [SerializeField] private Camera m_mainCamera;

    // Hand Control Variables
    [SerializeField] private GameObject m_rightHand;

    [Range(1, 100)]
    [SerializeField] private int m_handSpeed = 75;

    private Vector3 m_originalPosition;


    public CPMinigameTouchController touchController;
    public CPMinigameController minigameController;

    void Start()
    {
        m_originalPosition = transform.position;
        m_rightHand.transform.position = m_originalPosition;

    }

    // Update is called once per frame
    void Update()
    {
        // Hand Follows Mouse Movement
        Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
        switch (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            case true:
                m_rightHand.transform.position = Vector3.MoveTowards(m_rightHand.transform.position, raycastHit.point, m_handSpeed);

                switch (raycastHit.collider.tag == "CPZoneBlock")
                {
                    case true:
                        switch (touchController.m_isDragging)
                        {
                            case true:
                                if (!raycastHit.collider.gameObject.GetComponent<CPZoneController>().isTaken)
                                {
                                    raycastHit.collider.gameObject.GetComponent<CPZoneController>().isTaken = true;
                                }
                                try
                                {
                                    minigameController.CheckIfDone();
                                }
                                catch (Exception e) { }
                                break;
                            case false: break;
                        }
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }
    }
}
