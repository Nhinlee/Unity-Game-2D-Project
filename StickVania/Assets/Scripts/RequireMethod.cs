using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class RequireMethod
{
    static bool isDrawRayCast = true;
    public static RaycastHit2D RayCast(Vector2 pos, Vector2 direction, float length, LayerMask mask)
    {
        // Raycast
        RaycastHit2D hit = Physics2D.Raycast(pos, direction, length, mask);
        // Draw ray to debug
        if (isDrawRayCast)
        {
            //...determine the color based on if the raycast hit...
            Color color = hit ? Color.red : Color.green;
            //draw ray in screen...
            Debug.DrawRay(pos, length * direction, color, 0f, false);
        }

        return hit;
    }

    public static void HurtingMovement(Rigidbody2D rigid)
    {
        rigid.velocity += new Vector2(0,3);
    }
}
