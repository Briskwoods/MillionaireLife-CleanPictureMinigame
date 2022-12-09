using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CPMinigameIntroController : MonoBehaviour
{
    public GameObject millionaire;

    public GameObject m_camera;

    public bool isMaleMillionaire = false;

    public Transform cameraPoint1;

    public CPMinigameInstructionsController instructionsController;
    public CPMinigameTouchController touchController;
    public CPHandController handController;

    public GameObject leftHand;

    public Animator frameAnim;

    void Start()
    {
        Invoke("CameraIntroZoom", 1.5f);
        GetMillionaireGender();
    }

    public void GetMillionaireGender()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
    }

    public void CameraIntroZoom()
    {
        m_camera.transform.DORotateQuaternion(cameraPoint1.rotation, 2f);
        m_camera.transform.DOMove(cameraPoint1.position, 2f).OnComplete(BeginLevel);
    }

    public void BeginLevel()
    {
        millionaire.SetActive(false);
        leftHand.SetActive(true);
        frameAnim.SetTrigger("Move");
    }

    public void OnFrameStopMove()
    {
        instructionsController.ShowInstructions();
        touchController.enabled = true;
        handController.enabled = true;
    }
}
