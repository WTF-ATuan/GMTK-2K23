using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{
	public Block holdingBlock;


	private CanvasGroup _canvasGroup;
	private Vector2 _deviation;
	private GameObject _cloneGameObject;

	private void Awake(){
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData){
		_deviation = (Vector2)transform.localPosition - eventData.position;
		var worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
		worldPoint.z = 0;
		_cloneGameObject = Instantiate(holdingBlock.summonedBlock, worldPoint, Quaternion.identity);
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.alpha = 0f;
	}

	public void OnEndDrag(PointerEventData eventData){
		var offsetX = _cloneGameObject.transform.position.x;
		if(offsetX > 5){
			Destroy(_cloneGameObject);
			_canvasGroup.blocksRaycasts = true;
			_canvasGroup.alpha = 1f;
		}
		else{
			Destroy(gameObject);
		}
	}

	public void OnDrag(PointerEventData eventData){
		var offsetX = _cloneGameObject.transform.position.x;
		var worldPoint = (Vector2)Camera.main.ScreenToWorldPoint(eventData.position);
		_cloneGameObject.transform.position = offsetX < 5 ? GameRoot.Root.PolishPosition(worldPoint) : worldPoint;
	}
}