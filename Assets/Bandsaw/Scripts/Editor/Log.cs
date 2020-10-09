using UnityEngine;
using System;

[Serializable]
public class Log
{
    [SerializeField]
    public string tag;
    [SerializeField]
    public string content;

    public Log(string tag, string content)
    {
        this.tag = tag;
        this.content = content;
    }
}
