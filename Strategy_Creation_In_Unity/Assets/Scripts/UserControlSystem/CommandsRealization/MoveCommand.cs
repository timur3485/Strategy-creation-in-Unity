using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class MoveCommand : IMoveCommand
{
    public void Move()
    {
        Debug.Log("I am Moving");
    }
}
