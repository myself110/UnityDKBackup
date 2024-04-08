using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracks : MonoBehaviour
{
    public GameObject Track40;
    public GameObject Track60;
    public GameObject Track80;
    public GameObject Track100;

    // Start is called before the first frame update

    public void trackToggle40()
    {
        Track40.SetActive(true);
        Track60.SetActive(false);
        Track80.SetActive(false);
        Track100.SetActive(false);
    }
    public void trackToggle60()
    {
        Track40.SetActive(false);
        Track60.SetActive(true);
        Track80.SetActive(false);
        Track100.SetActive(false);
    }
    public void trackToggle80()
    {
        Track40.SetActive(false);
        Track60.SetActive(false);
        Track80.SetActive(true);
        Track100.SetActive(false);
    }
    public void trackToggle100()
    {
        Track40.SetActive(false);
        Track60.SetActive(false);
        Track80.SetActive(false);
        Track100.SetActive(true);
    }
}
