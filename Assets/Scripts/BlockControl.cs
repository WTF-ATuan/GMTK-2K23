using System;
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
		_canvasGroup.alpha = 0.7f;
	}

	public void OnEndDrag(PointerEventData eventData){
		_canvasGroup.blocksRaycasts = true;
		_canvasGroup.alpha = 1f;
	}

	public void OnDrag(PointerEventData eventData){
		transform.localPosition = eventData.position + _deviation;
		var worldPoint = (Vector2)Camera.main.ScreenToWorldPoint(eventData.position);
		_cloneGameObject.transform.position = worldPoint;
	}
}