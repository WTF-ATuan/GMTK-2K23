using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class ListController : MonoBehaviour{
	// Start is called before the first frame update
	public BlockList list;
	public List<Block> instantiatedBlock;
	public List<Block> blocks;
	public Transform container;
	public GameObject blockPrefab;
	float timer;
	[SerializeField] private float cd = 10;

	void Start(){
		foreach(var item in blocks){
			InitBlock(item);
		}

		timer = cd;
	}

	// Update is called once per frame
	void Update(){
		timer -= Time.deltaTime;
		if(timer <= 0){
			timer = cd;
			Add(2);
			InitBlock(blocks[index: Random.Range(1, blocks.Count)]);
		}
	}

	public void InitBlock(Block block){
		GameObject blockContainer = Instantiate(blockPrefab, container);
		blockContainer.GetComponent<Image>().sprite = block.sprite;
		blockContainer.GetComponent<BlockControl>().holdingBlock = block;
	}

	public void Add(int id){
		blocks.Add(new Block(instantiatedBlock[id].ID, instantiatedBlock[id].summonedBlock,
			instantiatedBlock[id].sprite));
	}
}