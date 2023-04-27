using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace Macromedia {
    public static class Math {
        public static Vector3 ClampMagnitude(bool clampX, bool clampY, bool clampZ, Vector3 vector, float maxLength) {
            Vector3 v = vector;
            if (!clampX) v.x = 0;
            if (!clampY) v.y = 0;
            if (!clampZ) v.z = 0;

            v = Vector3.ClampMagnitude(v, maxLength);

            if (clampX) vector.x = v.x;
            if (clampY) vector.y = v.y;
            if (clampZ) vector.z = v.z;

            return vector;
        }

        public static Vector3 InputToWorldVector(Vector2 input, Camera camera) {
            if (input == Vector2.zero) return Vector3.zero;
            if (camera == null) camera = Camera.main;

            float length = input.magnitude;
            input.Normalize();

            var matrix = camera.cameraToWorldMatrix;
            var input3 = new Vector3(input.x, 0, -input.y);
            var direction = matrix.MultiplyVector(input3);
            direction.y = 0; // project to xz plane

            if (direction == Vector3.zero) return Vector3.zero;

            direction.Normalize();
            return direction * length;
        }
    }
}