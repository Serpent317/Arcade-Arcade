using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPrefsDelete : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] prefs = GameObject.FindGameObjectsWithTag("PlayerPrefsDelete");
        if (prefs.Count() > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
