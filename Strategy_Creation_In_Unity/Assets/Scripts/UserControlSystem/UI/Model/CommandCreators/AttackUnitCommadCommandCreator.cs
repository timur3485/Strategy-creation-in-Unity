using Abstractions.Commands.CommandsInterfaces;
using System;
using Utils;
using Zenject;

public class AttackUnitCommadCommandCreator : CommandCreatorBase<IAttackCommand>
{
	[Inject] private AssetsContext _context;

	protected override void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
	{
		creationCallback?.Invoke(_context.Inject(new AttackUnitCommand()));
	}
}
