using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    private int Star = 0;

    public TextMeshProUGUI StarText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "StarX");
        {
            Star++;
            StarText.text = "Star: " + Star.ToString();
            Debug.Log(Star);
            Destroy(other.gameObject);
        }
    }
}
