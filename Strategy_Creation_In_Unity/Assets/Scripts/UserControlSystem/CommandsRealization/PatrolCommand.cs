using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class PatrolCommand : IPatrolCommand
{
    public void Patrol()
    {
        Debug.Log("I am Patroling");
    }
}
