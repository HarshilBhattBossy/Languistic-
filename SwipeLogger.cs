using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    private float DeleteTime = 0.0f;
    public float period = 8f;
    public float period02 = 11f;
    Queue<GameObject> myStack = new Queue<GameObject>();
    public GameObject Anime;

    private void Start()
    {
        DeleteTime = period02;
    }
    private void Update()
    {
        if (Time.time > nextActionTime)
        {

            Debug.Log("Soccer Ball clicked");
            GameObject gameObject = Instantiate(Anime, new Vector3(0, 0, 1), Quaternion.identity);
            gameObject.transform.Rotate(0, -180, 0);
            myStack.Enqueue(gameObject);
            nextActionTime += period;

        }
        if (myStack.Count != 0 && DeleteTime < Time.time)
        {
            Destroy(myStack.Peek());
            myStack.Dequeue();
            DeleteTime += period02;
        }
    }
    private void Awake()
    {
        Algo.OnSwipe += SwipeDetector;
    }

    private void SwipeDetector(SwipeData data)
    {
        Debug.Log("Swiping" + data.Direction);
    }
}
