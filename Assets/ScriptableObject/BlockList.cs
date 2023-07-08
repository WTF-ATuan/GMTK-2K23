using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block List", menuName = "ScriptableObject/Block List")]
public class BlockList : ScriptableObject
{
    public List<Block> instantiatedBlock;
    public List<Block> blocks;
    public int maxSize;

    public void Add(int id)
    {
        blocks.Add(new Block(instantiatedBlock[id].ID, instantiatedBlock[id].summonedBlock, instantiatedBlock[id].sprite));
    }
   

}
