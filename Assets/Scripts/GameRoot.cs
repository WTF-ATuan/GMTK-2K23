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
	}
}