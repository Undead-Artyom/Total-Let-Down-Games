using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable {

    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; }

    void Move(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}