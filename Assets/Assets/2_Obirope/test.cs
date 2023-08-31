using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // keep a copy of the executing script
    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {
       // print("Starting " + Time.time);
        coroutine = WaitAndPrint(3.0f);
        StartCoroutine(coroutine);
     //   print("Done " + Time.time);
    }

    // print to the console every 3 seconds.
    // yield is causing WaitAndPrint to pause every 3 seconds
    int i = 0;
    public IEnumerator WaitAndPrint(float waitTime)
    {
        i = 0;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            i++;
            //   print("WaitAndPrint " + Time.time);
            Debug.Log("WaitAndPrint " + i);
        }
    }
 
    public void StopCour()
    {
        //    if (Input.GetKeyDown("space"))
        //    {
        StopCoroutine(coroutine);
        //  print("Stopped " + Time.time);
        Debug.Log("Stopped " + i);

        //}
    }
    [Button]
    public void startNew()
    {
        StopCour();
        i = 0;
        StartCoroutine(coroutine);
    }
    //void Update()
    //{
    //}
}
