// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ragdoll.Armature;
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
	[AddComponentMenu(menuName: MENU_PATH + nameof(RagdollBody), DEFAULT_ORDER)]
	public sealed class RagdollBody : MonoBehaviour
	{
		[SerializeField] private RagdollArmatureBaker _armature;

		private IStateMachine _stateMachine;
		private RagdollArmature _bakedArmature;

		private void Start() => Activate();

		private IStateMachine StateMachine => _stateMachine ??= new StateMachine(new EmptyRagdollState());
		private RagdollArmature BakedArmature => _bakedArmature ??= _armature.Bake();

		[ContextMenu(nameof(Activate))]
		public void Activate()
		{
			StateMachine.SwitchState(new ActiveRagdollState(BakedArmature));
#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}

		[ContextMenu(nameof(Deactivate))]
		public void Deactivate()
		{
			StateMachine.SwitchState(new EmptyRagdollState());
#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}
	}
}