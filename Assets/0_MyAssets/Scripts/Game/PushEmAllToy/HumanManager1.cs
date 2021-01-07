using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HumanManager1 : MonoBehaviour
{
    [SerializeField] Transform protectedTf;
    [SerializeField] HumanController1 humanPrefab;
    HumanController1[] humanControllers;
    void Start()
    {
        Vector3 startPos = new Vector3(-3.44f, 0.55f, 0.15f);
        Vector3 pos = startPos;
        float offset = 0.75f;
        humanControllers = new HumanController1[100];
        int xCount = 0;
        for (int i = 0; i < humanControllers.Length; i++)
        {
            humanControllers[i] = Instantiate(humanPrefab, pos, Quaternion.identity, transform);
            humanControllers[i].OnInstantiate(protectedTf);
            humanControllers[i].transform.localPosition = pos;
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

    public int HumanCount()
    {
        return humanControllers.Count();
    }

    public int FallCount()
    {
        return humanControllers.Where(h => h.isFallen).Count();
    }
}
