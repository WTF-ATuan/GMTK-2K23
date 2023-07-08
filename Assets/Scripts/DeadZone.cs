using UnityEngine;

namespace DefaultNamespace{
	public class DeadZone : MonoBehaviour{
		
		private void OnTriggerEnter2D(Collider2D col){
			if(col.gameObject.CompareTag("Player")){
				GameRoot.Root.CharacterDead();
			}
		}
	}
}