using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Tetris
{
	public class ShapeCtrl : MonoBehaviour
	{

		private bool mIsPause = false;

		private float mTimer = 0;

		private float mStepTime = 0.8f;

		public void Init(Color color)
		{
			foreach (Transform childTrans in transform)
			{
				if (childTrans.tag.Equals("Block"))
				{
					childTrans.GetComponent<SpriteRenderer>().color = color;
				}
			}
		}

		private void Update()
		{
			if (mIsPause) return;
			mTimer += Time.deltaTime;
			if (mTimer > mStepTime)
			{
				mTimer = 0;
				Fall();
			}
		}

		void Fall()
		{
			var pos = transform.position;
			pos.y -= 1;
			transform.position = pos;
		}
	}
}