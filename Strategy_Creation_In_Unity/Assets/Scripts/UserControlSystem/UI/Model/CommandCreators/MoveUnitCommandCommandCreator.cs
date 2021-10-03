using Abstractions.Commands.CommandsInterfaces;
using System;
using Utils;
using Zenject;


public class MoveUnitCommandCommandCreator : CommandCreatorBase<IMoveCommand>
{
	[Inject] private AssetsContext _context;

	protected override void classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
	{
		creationCallback?.Invoke(_context.Inject(new MoveCommand()));
	}
}
