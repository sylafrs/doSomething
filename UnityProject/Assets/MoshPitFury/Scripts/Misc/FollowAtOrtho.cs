using UnityEngine;
using System.Collections.Generic;

/**
  * @class FollowAtOrtho
  * @brief Description.
  * @author Sylvain Lafon
  * @see MonoBehaviour
  */
public class FollowAtOrtho : MonoBehaviour
{

	private Camera orthoCamera;
	public Transform target;

	public void Update()
	{
		if (orthoCamera == null)
		{
			orthoCamera = GameObject.FindGameObjectWithTag("InterfaceCamera").GetComponent<Camera>();
		}

		if (target)
		{
			Vector3 pos = WorldToNormalizedViewportPoint(
				Camera.main,
				target.transform.position
			);

			this.transform.position = NormalizedViewportToWorldPoint(orthoCamera, pos);
		}
	}

	public static Vector3 WorldToNormalizedViewportPoint(Camera camera, Vector3 point)
	{
		point = camera.WorldToViewportPoint(point);

		if (camera.orthographic)
		{
			point.z = (2 * (point.z - camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane)) - 1f;
		}
		else
		{
			point.z = ((camera.farClipPlane + camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane))
			+ (1 / point.z) * (-2 * camera.farClipPlane * camera.nearClipPlane / (camera.farClipPlane - camera.nearClipPlane));
		}

		return point;
	}

	public static Vector3 NormalizedViewportToWorldPoint(Camera camera, Vector3 point)
	{
		if (camera.orthographic)
		{
			point.z = (point.z + 1f) * (camera.farClipPlane - camera.nearClipPlane) * 0.5f + camera.nearClipPlane;
		}
		else
		{
			point.z = ((-2 * camera.farClipPlane * camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane)) /
			(point.z - ((camera.farClipPlane + camera.nearClipPlane) / (camera.farClipPlane - camera.nearClipPlane)));
		}

		return camera.ViewportToWorldPoint(point);
	}
}
