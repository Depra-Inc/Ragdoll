// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Collections.Generic;
using Depra.Ragdoll.Parts;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Armature
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(DebugRagdollArmature), DEFAULT_ORDER)]
	internal sealed class DebugRagdollArmature : RagdollArmature
	{
		[SerializeField] private RagdollBone[] _bones;

		[ContextMenu(nameof(GatherBones))]
		public override IEnumerable<RagdollBone> GatherBones() =>
			_bones ??= GetComponentsInChildren<RagdollBone>();
	}
}