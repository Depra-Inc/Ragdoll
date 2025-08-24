using Depra.Ragdoll.Armature;
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