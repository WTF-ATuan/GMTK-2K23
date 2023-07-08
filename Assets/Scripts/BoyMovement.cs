using System;
using UnityEngine;

namespace DefaultNamespace{
	public class BoyMovement : MonoBehaviour{
		[SerializeField] private float speed = 1;
		[SerializeField] private LayerMask detectLayer;
		private bool _facingRight = true;
		private Animator _animator;
		private Rigidbody2D _rigidbody2D;


		private void Start(){
			_animator = GetComponent<Animator>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void ChangeDirection(){
			_facingRight = !_facingRight;
			var localScale = transform.localScale;
			transform.localScale = _facingRight
					? new Vector3(localScale.x, localScale.y, localScale.z)
					: new Vector3(-localScale.x, localScale.y, localScale.z);
		}

		private void FixedUpdate(){
			Move();
			DetectDirection();
			PlayAnimation();
		}

		private void DetectDirection(){
			var faceDirection = _facingRight ? transform.position + Vector3.right : transform.position + Vector3.left;
			var raycastHit2D = Physics2D.Raycast(transform.position, faceDirection, 0.1f, detectLayer);
			if(raycastHit2D){
				print($"{raycastHit2D.collider}");
				ChangeDirection();
			}
		}

		private void Move(){
			if(_facingRight){
				var velocity = _rigidbody2D.velocity;
				velocity += new Vector2(speed, velocity.y);
				_rigidbody2D.velocity = velocity;
			}
			else{
				var velocity = _rigidbody2D.velocity;
				velocity += new Vector2(-speed, velocity.y);
				_rigidbody2D.velocity = velocity;
			}
		}

		private void PlayAnimation(){
			_animator.SetBool($"Run", Mathf.Abs(_rigidbody2D.velocity.x) > 0);
		}

		private void OnDrawGizmosSelected(){
			Gizmos.color = Color.green;
			var faceDirection = _facingRight ? transform.position + Vector3.right : transform.position + Vector3.left;
			Gizmos.DrawLine(transform.position, faceDirection);
		}
	}
}