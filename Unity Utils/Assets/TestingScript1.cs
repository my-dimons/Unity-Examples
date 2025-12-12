using System;
using System.Collections;
using UnityEngine;
using UnityUtils.ScriptUtils;
using UnityEngine.UI;

public class TestingScript1 : MonoBehaviour
{
    public float testingValue;
    public Vector3 testingVector3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectAnimations.AnimateImageOpacity(GetComponent<Image>(), 0.5f, 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);

    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
