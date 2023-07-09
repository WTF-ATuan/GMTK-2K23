using UnityEngine;

namespace DefaultNamespace{
	public class GameRoot : MonoBehaviour{
		public static GameRoot Root;

		private void Awake(){
			if(!Root){
				Root = this;
			}
		}

		public void CharacterDead(){
			print("Character Dead");
		}

		public Vector2 PolishPosition(Vector2 currentPosition){
			var x = GetNearestValue(currentPosition.x, new[] { -2, 0.25f, 2.5f, 4.75f });
			var y = GetNearestValue(currentPosition.y, 0.75f);

			return new Vector2(x, y);
		}
		private float GetNearestValue(float value, float[] possibleValues)
		{
			var nearestValue = possibleValues[0];
			var smallestDifference = Mathf.Abs(value - possibleValues[0]);

			foreach (var possibleValue in possibleValues)
			{
				var difference = Mathf.Abs(value - possibleValue);
				if(!(difference < smallestDifference)) continue;
				smallestDifference = difference;
				nearestValue = possibleValue;
			}

			return nearestValue;
		}

		private float GetNearestValue(float value, float interval)
		{
			var nearestValue = Mathf.Round(value / interval) * interval;
			return nearestValue;
		}
	}
}