// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ragdoll.Bones;
using UnityEngine;
using static Depra.Ragdoll.Module;
#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#endif

namespace Depra.Ragdoll.Armature
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(DebugRagdollArmatureBaker), DEFAULT_ORDER)]
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