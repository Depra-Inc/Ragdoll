using Depra.Ragdoll.Body;
using Depra.Ragdoll.Bones;
using UnityEngine;
#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#endif

namespace Depra.Ragdoll.Armature
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RagdollBody))]
	internal sealed class DebugRagdollArmatureBaker : RagdollArmatureBaker
	{
#if UNITY_EDITOR
		[SerializeField] [SuppressMessage("ReSharper", "NotAccessedField.Local")]
		private List<RagdollBone> _bones;
#endif

		[ContextMenu(nameof(Bake))]
		public override RagdollArmature Bake()
		{
			var bones = GetComponentsInChildren<RagdollBone>();
#if UNITY_EDITOR
			_bones = new List<RagdollBone>(bones);
#endif
			return new RagdollArmature(bones);
		}
	}
}