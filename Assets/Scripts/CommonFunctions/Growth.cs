using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Growth {

  public static Vector3 NewPosition (Vector3 current, Vector3 initial, Vector3 final, float duration) {
    float speed = (final - initial).magnitude / duration;
    // Debug.Log("-----1");
    // Debug.Log(final);
    // Debug.Log(initial);
    // Debug.Log(duration);
    // Debug.Log((final - initial).magnitude);
    
    Vector3 toEnd = final - current;
    Vector3 move = toEnd.normalized * speed * Time.deltaTime;
    // Debug.Log("------");
    // Debug.Log(speed);
    if (toEnd.sqrMagnitude < move.sqrMagnitude) { // Check if end is reached
      // Debug.Log(final);
      return final;
    } else {
      // Debug.Log(current + move);
      return (current + move);
    }
  }

}
