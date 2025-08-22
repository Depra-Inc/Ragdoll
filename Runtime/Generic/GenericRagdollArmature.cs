// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System.Collections.Generic;
using Depra.Ragdoll.Parts;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Armature
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Generic Ragdoll Armature", DEFAULT_ORDER)]
	internal sealed class GenericRagdollArmature : RagdollArmature
	{
		[SerializeField] private RagdollBone[] _bones;

		[ContextMenu(nameof(GatherBones))]
		public override IEnumerable<RagdollBone> GatherBones() =>
			_bones ??= GetComponentsInChildren<RagdollBone>();
	}
}