using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	[SerializeField] private Vector2 coldDownDuration = new Vector2(0.5f, 3f);

	void Start(){
		foreach(var item in blocks){
			InitBlock(item);
		}

		timer = Random.Range(coldDownDuration.x, coldDownDuration.y);
	}

	// Update is called once per frame
	void Update(){
		timer -= Time.deltaTime;
		if(timer <= 0){
			timer = Random.Range(coldDownDuration.x, coldDownDuration.y);
			Add(Random.Range(0, instantiatedBlock.Count));
			InitBlock(blocks.Last());
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