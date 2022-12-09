using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPFrameAnimationEvent : MonoBehaviour
{

    public CPMinigameInstructionsController instructionsController;
    public CPMinigameTouchController touchController;
    public CPHandController handController;

    public void OnFrameMoved()
    {
        instructionsController.ShowInstructions();
        touchController.enabled = true;
        handController.enabled = true;
    }
}
