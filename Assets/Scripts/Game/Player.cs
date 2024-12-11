using UnityEngine;
using QFramework;

namespace shaxquan.Survivor
{
	public partial class Player : ViewController
	{
		public float MovementSpeed = 5;
		void Start()
		{
			// Code Here
			"Hello World".LogInfo();

			HurtBox.OnTriggerEnter2DEvent(collider2D1 =>
			{
				gameObject.DestroySelfGracefully();
				UIKit.OpenPanel<UIHomePanel>();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

		private void Update()
		{
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");
			var direction = new Vector3(horizontal, vertical).normalized;

			SelfRigidbody2D.linearVelocity = direction * MovementSpeed;
		}
	}
}
