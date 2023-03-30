using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineSystem : MonoBehaviour
{
    private Queue coroutineQueue = new Queue();

    public void AddCoroutineQueue(IEnumerator coroutine)
    {
        coroutineQueue.Enqueue(coroutine);
    }
    // Start is called before the first frame update
    void Start()
    {
        AddCoroutineQueue(Logging(10));
        AddCoroutineQueue(Logging(100));
        AddCoroutineQueue(Logging(1000));
        if (coroutineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }

    IEnumerator Logging(int number)
    {
        for(int i = number; i < number + 10; i++)
        {
            Debug.Log(i.ToString() + "<--");
            yield return new WaitForSeconds(0.1f);
        }

        if(coroutineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
