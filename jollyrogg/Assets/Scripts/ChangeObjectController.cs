using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * -1, 0, 0);
    }
}