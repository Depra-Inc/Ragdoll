// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEditor;
using UnityEngine;

namespace Depra.Ragdoll.Editor
{
	[CustomEditor(typeof(HumanoidArmaturePreset))]
	internal sealed class HumanoidArmaturePresetEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (target == null)
			{
				return;
			}

			if (GUILayout.Button("▶ Play Sandbox"))
			{
				RagdollSandboxWindow.ShowWindow((HumanoidArmaturePreset)target);
			}
		}
	}
}