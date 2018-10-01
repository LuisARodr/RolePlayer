using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Controls
{
    public static class Controls
    {
        public static Vector2 getAxis()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

    }
}

