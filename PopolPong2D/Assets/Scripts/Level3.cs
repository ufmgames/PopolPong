using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{

    [SerializeField] private GameObject[] rings;
    [SerializeField] private bool randomPositions = false;
    private int activeRing = 0;
    private bool activeLevel = false;

    //private void Start()
    //{
    //    StartCoroutine(ChangeRing());
    //}

    //private void Update()
    //{
    //    if (this.gameObject.activeSelf)
    //    {
    //        activeLevel = true;
    //        StartCoroutine(ChangeRing());
    //    } else
    //    {
    //        activeLevel = false;
    //    }
    //}

    private void Update()
    {
        Debug.Log("level3 active");
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
        activeLevel = false;
    }

    void OnEnable()
    {
        Debug.Log("PrintOnDisable: script was enable");
        activeLevel = true;
        StartCoroutine(ChangeRing());
    }

    // Coroutine
    IEnumerator ChangeRing()
    {
        Debug.Log("ChangeRing Coroutine");
        while (activeLevel)
        {
            Debug.Log("while");
            yield return new WaitForSeconds(1);
            Debug.Log("while1");

            rings[activeRing].SetActive(false); 
            if (randomPositions)
            {
                int ringIndex = Random.Range(0, rings.Length);
                rings[ringIndex].SetActive(true);
                activeRing = ringIndex;
            }
            else
            {
                activeRing++;
                if (activeRing >= rings.Length)
                {
                    activeRing = 0;
                }
                rings[activeRing].SetActive(true);
            }
        }
    }
}
