// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Ragdoll.Armature;
using Depra.Ragdoll.Body.States;
using Depra.Stateful.Abstract;
using Depra.Stateful.Finite;
using UnityEngine;
using static Depra.Ragdoll.Module;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Depra.Ragdoll.Body
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(RagdollStateMachine), DEFAULT_ORDER)]
	public sealed class RagdollStateMachine : RagdollBody, IStateMachine
	{
		[SerializeField] private RagdollState _defaultState;
		[SerializeField] private List<RagdollState> _states;

		private readonly Dictionary<Type, IState> _statesMap = new();
		private IStateMachine _stateMachine;
		private RagdollArmature _bakedArmature;

		event StateChangedDelegate IStateMachine<IState>.StateChanged
		{
			add => _stateMachine.StateChanged += value;
			remove => _stateMachine.StateChanged -= value;
		}

		IState IStateMachine<IState>.CurrentState => _stateMachine.CurrentState;

		[ContextMenu(nameof(Enable))]
		public override void Enable()
		{
			SwitchState<ActiveRagdollState>();
#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}

		[ContextMenu(nameof(Disable))]
		public override void Disable()
		{
			SwitchState<EmptyRagdollState>();
#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}

		public void SwitchState<TState>() where TState : RagdollState
		{
			_stateMachine ??= Initialize();
			if (_statesMap.TryGetValue(typeof(TState), out var state))
			{
				_stateMachine.SwitchState(state);
			}
		}

		private IStateMachine Initialize()
		{
			_statesMap.Clear();
			_stateMachine = new StateMachine();
			_statesMap.Add(_defaultState.GetType(), _defaultState);

			foreach (var state in _states)
			{
				if (state.enabled == false)
				{
					continue;
				}

				_stateMachine.SwitchState(state);
				_statesMap.Add(state.GetType(), state);
			}

			_stateMachine.SwitchState(_defaultState);
			return _stateMachine;
		}

		[ContextMenu(nameof(FillStates))]
		private void FillStates()
		{
			_states = GetComponents<RagdollState>().ToList();
			if (_states.Contains(_defaultState))
			{
				_states.Remove(_defaultState);
			}
		}

		void IStateMachine<IState>.SwitchState(IState to) => _stateMachine.SwitchState(to);
	}
}