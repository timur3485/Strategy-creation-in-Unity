using Abstractions.Commands.CommandsInterfaces;
using System;
using Utils;
using Zenject;

public class StopUnitCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
	[Inject] private AssetsContext _context;

	protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
	{
		creationCallback?.Invoke(_context.Inject(new StopCommand()));
	}
}
