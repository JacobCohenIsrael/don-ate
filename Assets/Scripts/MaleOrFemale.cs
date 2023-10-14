using System;
using UnityEngine;

public class MaleOrFemale : MonoBehaviour
{
    [SerializeField] GameObject femaleSoldier;
    [SerializeField] GameObject maleSoldier;

    void Start()
    {
        int random = UnityEngine.Random.Range(0, 2);
        if(random == 1)
        {
            femaleSoldier.SetActive(true);
        }
        else
        {
            maleSoldier.SetActive(true);
        }
    }
}
