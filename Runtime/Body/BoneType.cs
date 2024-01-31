// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll.Bones
{
	public enum BoneType
	{
		[InspectorName("Pelvis")] PELVIS,
		[InspectorName("Left Hips")] LEFT_HIPS,
		[InspectorName("Left Knee")] LEFT_KNEE,
		[InspectorName("Left Foot")] LEFT_FOOT,
		[InspectorName("Right Hips")] RIGHT_HIPS,
		[InspectorName("Right Knee")] RIGHT_KNEE,
		[InspectorName("Right Foot")] RIGHT_FOOT,
		[InspectorName("Left Arm")] LEFT_ARM,
		[InspectorName("Left Elbow")] LEFT_ELBOW,
		[InspectorName("Right Arm")] RIGHT_ARM,
		[InspectorName("Right Elbow")] RIGHT_ELBOW,
		[InspectorName("Middle Hips")] MIDDLE_SPINE,
		[InspectorName("Head")] HEAD,
	}
}