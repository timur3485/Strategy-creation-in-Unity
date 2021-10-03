using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class AttackUnitCommand : IAttackCommand
{
    public IAttackable Target => throw new System.NotImplementedException();

    public void Attack()
    {
        Debug.Log("I am Attack");
    }
}
