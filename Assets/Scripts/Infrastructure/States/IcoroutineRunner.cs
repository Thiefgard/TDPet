using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutineRunner 
{
    public Coroutine StartCoroutine(IEnumerator coroutine);
}
