using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPMinigameController : MonoBehaviour
{
    public bool isMaleMillionaire;

    public GameObject maleMillionaire;
    public GameObject femaleMillionaire;

    public List<CPZoneController> zones = new List<CPZoneController>();
    public Transform MoneySpawnPoint;
    public Animator FrameAnim;
    bool CallOnce = false;

    public CPHandController handController;

    // Start is called before the first frame update
    void Start()
    {
        CheckPresident();
    }


    public void CheckPresident()
    {
        // Get var saved in code controller
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();

        // Check if male or female and basically change based on answer
        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaire.SetActive(true);
                femaleMillionaire.SetActive(false);
                break;
            case false:
                femaleMillionaire.SetActive(true);
                maleMillionaire.SetActive(false);
                break;
        }
    }

    public void CheckIfDone()
    {
        foreach (CPZoneController zone in zones)
        {
            switch (zone.isTaken)
            {
                case true:
                    zones.Remove(zone);

                    // Haptic Feedback
                    Vibration.VibratePop();

                    break;
                case false: break;
            }
        }


        switch (zones.Count == 0 && !CallOnce)
        {
            case true:
                Invoke("PutFrameBack", 2f);
                CallOnce = true;
                CodeManager.Instance.CashManager_Script.IncreaseCash(200000);
                break;
            case false: break;
        }
    }

    public void PutFrameBack()
    {
        FrameAnim.SetTrigger("Back");

        handController.enabled = false;

        //Invoke("NextLevel", 3f);
        NextLevel(3f); 
    }

    public void NextLevel(float delay)
    {
        //End Of level, display inter

        //TTPManager.Instance.ShowInterstitialAd("AfterCleanPicture", () =>
        //{

            CodeManager.Instance.LevelManager_Script.EndLevel(delay);

        //});
    }

}
