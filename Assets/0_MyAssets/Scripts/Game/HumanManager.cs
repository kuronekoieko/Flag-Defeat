using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    [SerializeField] HumanController humanPrefab;
    HumanController[] humanControllers;
    void Start()
    {
        Vector3 startPos = new Vector3(-3.44f, 0.55f, 0.15f);
        Vector3 pos = startPos;
        float offset = 0.75f;
        humanControllers = new HumanController[100];
        int xCount = 0;
        for (int i = 0; i < humanControllers.Length; i++)
        {
            humanControllers[i] = Instantiate(humanPrefab, pos, Quaternion.identity, transform);
            humanControllers[i].OnInstantiate();
            xCount++;
            pos.x += offset;
            if (xCount == 10)
            {
                pos.x = startPos.x;
                pos.z -= offset;
                xCount = 0;
            }
        }
    }


}
