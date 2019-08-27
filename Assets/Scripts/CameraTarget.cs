/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

[ExecuteInEditMode]
public class CameraTarget : MonoBehaviour
{
	public Transform Target;

	public bool LockX;
	public bool LockY;
	public bool LockZ;

	private void Update()
	{
#if UNITY_EDITOR
		if (this.Target == null)
			return;
#endif

		this.transform.position =
			new Vector3(
				this.LockX ? this.transform.position.x : this.Target.position.x,
				this.LockY ? this.transform.position.y : this.Target.position.y,
				this.LockZ ? this.transform.position.z : this.Target.position.z
			);
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(CameraTarget))]
[CanEditMultipleObjects]
public class CameraTargetEditor : Editor
{
#pragma warning disable 0219, 414
	private CameraTarget _sCameraTarget;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sCameraTarget = this.target as CameraTarget;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif