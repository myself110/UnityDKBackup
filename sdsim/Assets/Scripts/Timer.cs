using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMesh currentTotTimeDisp;
    public TextMesh penaltiesDisp;
    public TextMesh lapTimesDisp;
    public TextMesh latestLapTimesDisp;
    public bool enabled_timer = false;
    public string racerName;
    public float penalties = 0.0f; //seconds
    public float currentStart = 0.0f; //seconds
    private bool isFirstLapTimeRemoved = false;

    bool freezed = false;
    private List<float> lapTimes = new List<float>(); // To store lap times
    private float lastLapTime = 0.0f; // To keep track of the last lap time

    void Awake()
    {   
        if(enabled_timer)
        {
            StartTimer();
        }
        else
        {
            DisableTimer();
        }
    }

    public void RecordLapTime()
    {
        float currentTime = GetCurrentTime();
        float lapTime = currentTime - lastLapTime;
        lastLapTime = currentTime;

        // Add the new lap time to the list
        lapTimes.Add(lapTime);

        if (lapTimes.Count > 0 && !isFirstLapTimeRemoved)
        {
            lapTimes.RemoveAt(0); // Removes the first element of the list
            isFirstLapTimeRemoved = true;
        }


        UpdateLapTimesDisplay();

        UpdateLatestLapTimesDisplay();
    }
    void UpdateLapTimesDisplay()
    {
        if (lapTimes.Count > 0)
        {
            float latestLapTime = lapTimes[lapTimes.Count - 1];
            lapTimesDisp.text = $" {latestLapTime.ToString("00.00")}";
        }
    }

    void UpdateLatestLapTimesDisplay()
    {

        // Sort the list of lap times in ascending order (fastest to slowest)
        lapTimes.Sort();

        // Keep only the top 5 fastest lap times
        if (lapTimes.Count > 5)
        {
            lapTimes.RemoveRange(5, lapTimes.Count - 5);
        }
        string displayText = "Latest 5 Lap Times:\n"; // Header for the latest lap times
        int lapCount = lapTimes.Count;
        int startIdx = Mathf.Max(0, lapCount - 5); // Ensure we only get the last 5

        for (int i = startIdx; i < lapCount; i++)
        {
            displayText += $"Lap {i + 1}: {lapTimes[i].ToString("00.00")}s\n";
        }

        latestLapTimesDisp.text = displayText; // Update the new TextMesh component
    }


    public void StartTimer()
    {
        currentTotTimeDisp.gameObject.SetActive(true);
        penaltiesDisp.gameObject.SetActive(true);
        lapTimesDisp.gameObject.SetActive(true);
        latestLapTimesDisp.gameObject.SetActive(true);
        lastLapTime = 0.0f;
        penalties = 0.0f;
        currentStart = GetTime();
        enabled_timer = true;
    }
    
    public void DisableTimer()
    {
        currentTotTimeDisp.gameObject.SetActive(false);
        penaltiesDisp.gameObject.SetActive(false);
        lapTimesDisp.gameObject.SetActive(false);
        latestLapTimesDisp.gameObject.SetActive(false);
        lastLapTime = 0.0f;
        penalties = 0.0f;
        currentStart = 0.0f;
        enabled_timer = false;
        freezed = false;
    }

    public void ResetTimer()
    {
        penalties = 0.0f;
        currentStart = GetTime();
        enabled_timer = true;
    }
    public void SplitTime()
    {
        freezed = true;
    }
    public void ContinueTime()
    {
        freezed = false;
    }


    float GetTime()
    {
        return Time.time;
    }    
    float GetPenalties()
    {
        return penalties;
    }
    float GetCurrentTime()
    {
        return (GetTime() - currentStart) + GetPenalties();
    }

    public void OnCollideChallenge(float penalty)
    {   
        if(enabled_timer == false)
            return;

        penalties += penalty;
        if(penaltiesDisp.gameObject.activeSelf){
            float penalties = GetPenalties();
            penaltiesDisp.text = penalties.ToString("00.00");
            Debug.Log("Added penalty");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(enabled_timer == false)
            return;

        if(currentTotTimeDisp.gameObject.activeSelf & !freezed)
        {
            float currentTime = GetCurrentTime();
            currentTotTimeDisp.text = currentTime.ToString("00.00");
        }
        if(penaltiesDisp.text != penalties.ToString("00.00") & !freezed)
        {
            penaltiesDisp.text = penalties.ToString("00.00");
        }
    }
}
