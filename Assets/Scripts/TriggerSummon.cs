using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSummon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LevelGenerate>(out  var levelGenerate))
            levelGenerate.Generate();

    }
}
