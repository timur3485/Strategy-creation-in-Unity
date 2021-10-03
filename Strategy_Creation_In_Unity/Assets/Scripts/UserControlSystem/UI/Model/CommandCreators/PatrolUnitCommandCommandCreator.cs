using Abstractions.Commands.CommandsInterfaces;
using System;
using Utils;
using Zenject;

public class PatrolUnitCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
{
	[Inject] private AssetsContext _context;

	protected override void classSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
	{
		creationCallback?.Invoke(_context.Inject(new PatrolCommand()));
	}
}
