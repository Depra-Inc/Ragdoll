// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Generic Ragdoll Armature", DEFAULT_ORDER)]
	internal sealed class GenericRagdollArmature : RagdollArmature
	{
		[SerializeField] private RagdollBone[] _bones;

		public override ReadOnlySpan<RagdollBone> GatherBones() =>
			_bones ??= GetComponentsInChildren<RagdollBone>();

		[ContextMenu(nameof(GatherBones))]
		private void GatherBonesFromChildren() => _bones = GetComponentsInChildren<RagdollBone>();
	}
}