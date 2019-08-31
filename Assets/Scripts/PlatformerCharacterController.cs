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

public class PlatformerCharacterController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rigidbody2D;

	private bool _grounded;

	[SerializeField] private Transform _walkableLayerValidationPivot;
	
	[Range(0.1f, 2f)]
	[SerializeField] private float _walkableLayerValidationRadius = 0.2f;
	[SerializeField] private LayerMask _walkableLayerMask;

	[Min(0f)]
	[SerializeField] private float _jumpForce = 5f;

	private int _jumpsLeft;

	[Min(0f)]
	[SerializeField] private float _movementSpeed = 3f;

	[SerializeField] private Animator _animator;

	private float _tempTimeCached;

	private void Update()
	{
		this._grounded = Physics2D.OverlapCircle(this._walkableLayerValidationPivot.position, this._walkableLayerValidationRadius, this._walkableLayerMask) != null;
		if (this._grounded && Time.time - this._tempTimeCached > 1f)
		{
			this._tempTimeCached = Time.time;

			this._jumpsLeft = 2;
		}

		Vector2 movement = Vector2.zero;

		if (Input.GetKey(KeyCode.A))
		{
			movement.x += -1;
		}
		else if (Input.GetKey(KeyCode.W))
		{
		}
		else if (Input.GetKey(KeyCode.S))
		{
		}
		else if (Input.GetKey(KeyCode.D))
		{
			movement.x += 1;
		}

		if (Input.GetKeyDown(KeyCode.Space) && this._jumpsLeft > 0)
		{
			this._jumpsLeft--;

			this._rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, 0f);
			this._rigidbody2D.AddForce(Vector2.up * this._jumpForce, ForceMode2D.Impulse);
		}

		this._rigidbody2D.velocity = new Vector2(movement.x * this._movementSpeed, this._rigidbody2D.velocity.y);

		this.transform.localScale = new Vector3(Mathf.Abs(movement.x) > 0 ? movement.x : 1f, this.transform.localScale.y, this.transform.localScale.z);

		this._animator.SetFloat("Run", Mathf.Abs(this._rigidbody2D.velocity.x));
		this._animator.SetFloat("Jump", this._rigidbody2D.velocity.y);
	}

#if UNITY_EDITOR
	private void Reset()
	{
		this._rigidbody2D = this.GetComponent<Rigidbody2D>();
		this._animator = this.GetComponent<Animator>();
	}

	private void OnDrawGizmos()
	{
		if (this._walkableLayerValidationPivot != null)
			Gizmos.DrawWireSphere(this._walkableLayerValidationPivot.position, this._walkableLayerValidationRadius);
	}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlatformerCharacterController))]
[CanEditMultipleObjects]
public class PlatformerCharacterControllerEditor : Editor
{
#pragma warning disable 0219, 414
	private PlatformerCharacterController _sPlatformerCharacterController;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sPlatformerCharacterController = this.target as PlatformerCharacterController;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif