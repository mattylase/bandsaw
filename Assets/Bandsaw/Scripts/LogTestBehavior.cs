using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bandsaw;

public class LogTestBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Saw.Log("LogTestBehavior", "Test log STRANGGGG!");
        Saw.Warn("LogTestBehavior", "It's a warning bro!");
        Saw.Error("LogTestBehavior", "It's a BIG ERROR!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
