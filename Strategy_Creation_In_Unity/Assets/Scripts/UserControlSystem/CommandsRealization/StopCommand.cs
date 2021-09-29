using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class StopCommand : IStopCommand
{
    public void Stop()
    {
        Debug.Log("I am Stoped");
    }
}
