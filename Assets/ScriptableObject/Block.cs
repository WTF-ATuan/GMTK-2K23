using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Block", menuName = "ScriptableObject/Block")]
public class Block : ScriptableObject
{
    public int ID;
    public GameObject summonedBlock;
    public Sprite sprite;
    public Block(int iD, GameObject summonedBlock, Sprite sprite)
    {
        ID = iD;
        this.summonedBlock = summonedBlock;
        this.sprite = sprite;
    }
}
