using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public GameObject Items;
    public bool itemBool = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeToggle()
    {
        if (itemBool == true)
        {
            Items.SetActive (false);
            itemBool = false;
        } else if (itemBool == false){
            Items.SetActive(true);
            itemBool = true;
        }
    }
}
