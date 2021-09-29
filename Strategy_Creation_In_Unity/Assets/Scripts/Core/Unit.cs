using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Collections.Generic;
using UnityEngine;

public class Unit : CommandExecutorBase<IAttackCommand>, ISelectable
{
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;



    [SerializeField] private float _maxHealth = 500;
    [SerializeField] private Sprite _icon;

    private float _health = 500;

    public override void ExecuteSpecificCommand(IAttackCommand command)  
    {
        command.Attack();
    }


    
}
