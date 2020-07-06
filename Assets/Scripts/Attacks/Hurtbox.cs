using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public Collider2D collider;
    public ColliderState _state = ColliderState.Open;

    public bool getHitBy(AttackData data)
    {
        Debug.Log(gameObject.name + " is hit for " + data.damage + " damage.");
        return true;
        // Do something with the damage and the state
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, collider.bounds.extents*2); // Because size is halfExtents
    }

}