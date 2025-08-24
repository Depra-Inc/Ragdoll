// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	public enum HumanoidBoneType
	{
		[InspectorName("Head")] HEAD,
		[InspectorName("Torso")] TORSO,
		[InspectorName("Pelvis")] PELVIS,

		[InspectorName("Left Hips")] LEFT_HIP,
		[InspectorName("Left Knee")] LEFT_KNEE,
		[InspectorName("Left Foot")] LEFT_FOOT,

		[InspectorName("Right Hips")] RIGHT_HIP,
		[InspectorName("Right Knee")] RIGHT_KNEE,
		[InspectorName("Right Foot")] RIGHT_FOOT,

		[InspectorName("Left Arm")] LEFT_ARM,
		[InspectorName("Left Elbow")] LEFT_ELBOW,

		[InspectorName("Right Arm")] RIGHT_ARM,
		[InspectorName("Right Elbow")] RIGHT_ELBOW,
	}
}