using Depra.Ragdoll.Armature;
using Depra.Stateful.Abstract;
using Depra.Stateful.Finite;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Depra.Ragdoll.Body
{
	[DisallowMultipleComponent]
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