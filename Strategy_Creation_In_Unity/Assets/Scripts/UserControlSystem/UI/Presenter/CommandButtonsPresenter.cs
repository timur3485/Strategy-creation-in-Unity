using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            if (commandExecutor as CommandExecutorBase<IProduceUnitCommand>)
            {
                var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
                if (unitProducer != null)
                {
                    unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                    return;
                }

            }
            else if (commandExecutor as CommandExecutorBase<IAttackCommand>)
            {
                var unitProducer = commandExecutor as CommandExecutorBase<IAttackCommand>;
                if (unitProducer != null)
                {
                    unitProducer.ExecuteSpecificCommand(new AttackUnitCommand());
                    return;
                }
            }else if (commandExecutor as CommandExecutorBase<IMoveCommand>)
            {
                var unitProducer = commandExecutor as CommandExecutorBase<IMoveCommand>;
                if (unitProducer != null)
                {
                    unitProducer.ExecuteSpecificCommand(new MoveCommand());
                    return;
                }
            }else if (commandExecutor as CommandExecutorBase<IPatrolCommand>)
            {
                var unitProducer = commandExecutor as CommandExecutorBase<IPatrolCommand>;
                if (unitProducer != null)
                {
                    unitProducer.ExecuteSpecificCommand(new PatrolCommand());
                    return;
                }
            }else if (commandExecutor as CommandExecutorBase<IStopCommand>)
            {
                var unitProducer = commandExecutor as CommandExecutorBase<IStopCommand>;
                if (unitProducer != null)
                {
                    unitProducer.ExecuteSpecificCommand(new StopCommand());
                    return;
                }
            }

            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}