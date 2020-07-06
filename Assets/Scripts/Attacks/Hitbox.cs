using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderState
{
    Closed,
    Open,
    Colliding
}

public class Hitbox : MonoBehaviour
{
    public LayerMask mask;
    public bool useSphere = false;
    public Vector3 hitboxSize = Vector3.one;
    public float radius = 0.5f;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidingColor;
    public IHitboxResponder _responder = null;
    public ColliderState _state;


    private void OnDrawGizmos()
    {
        checkGizmoColor();
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(hitboxSize.x, hitboxSize.y, hitboxSize.z)); // Because size is halfExtents
    }

    public void startCheckingCollision()
    {
        _state = ColliderState.Open;
    }

    public void stopCheckingCollision()
    {
        _state = ColliderState.Closed;
    }

    private void checkGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }

    private void Update()
    {
        if (_state == ColliderState.Closed) { return; }
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, hitboxSize, transform.rotation.z, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider2D aCollider = colliders[i];
            _responder?.collisionedWith(aCollider);
        }

        _state = colliders.Length > 0 ? ColliderState.Colliding : ColliderState.Open;

    }

    public void SetResponder(IHitboxResponder responder)
    {
        _responder = responder;
    }
}