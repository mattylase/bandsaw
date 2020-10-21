using UnityEngine;
using System;

[Serializable]
public class Log
{
    [SerializeField]
    public string tag;
    [SerializeField]
    public string content;
    [SerializeField]
    public LogLevel level;


    public Log(LogLevel level, string tag, string content)
    {
        this.tag = tag;
        this.content = content;
        this.level = level;
    }
}
