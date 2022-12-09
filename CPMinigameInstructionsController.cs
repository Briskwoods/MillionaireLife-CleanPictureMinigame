using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPMinigameInstructionsController : MonoBehaviour
{
    public GameObject Instructions;

    public void ShowInstructions()
    {
        Instructions.SetActive(true);
    }
}
