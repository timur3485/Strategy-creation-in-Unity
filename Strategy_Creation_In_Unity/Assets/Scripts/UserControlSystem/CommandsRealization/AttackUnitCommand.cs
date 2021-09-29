using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class AttackUnitCommand : IAttackCommand
{
    public void Attack()
    {
        Debug.Log("I am Attack");
    }
}
