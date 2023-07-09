using System;
using UnityEngine;

namespace DefaultNamespace{
	public class BoyMovement : MonoBehaviour{
		[SerializeField] private float speed = 1;
		private bool _facingRight = true;
		private Animator _animator;
		private Rigidbody2D _rigidbody2D;
		private SpriteRenderer _spriteRenderer;
		private AudioManager audioManager;


		private void Start(){
			_animator = GetComponent<Animator>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			audioManager = AudioManager.Instance;	
		}

		private void OnCollisionEnter2D(Collision2D col){
			if(col.gameObject.CompareTag($"Brick")){
				ChangeDirection();
			}
		}

		private void ChangeDirection(){
			_facingRight = !_facingRight;
			_spriteRenderer.flipX = !_spriteRenderer.flipX;
		}

		private void FixedUpdate(){
			Move();
			PlayAnimation();
		}


		private void Move(){
			if(_facingRight){
				var velocity = _rigidbody2D.velocity;
				velocity = new Vector2(speed, velocity.y);
				_rigidbody2D.velocity = velocity;
			}
			else{
				var velocity = _rigidbody2D.velocity;
				velocity = new Vector2(-speed, velocity.y);
				_rigidbody2D.velocity = velocity;
			}
			audioManager.PlaySound("WalkingSound");

		}

		private void PlayAnimation(){
			_animator.SetBool($"Run", Mathf.Abs(_rigidbody2D.velocity.x) > 0);
			_animator.SetFloat($"JumpState", _rigidbody2D.velocity.y);
		}
	}
}