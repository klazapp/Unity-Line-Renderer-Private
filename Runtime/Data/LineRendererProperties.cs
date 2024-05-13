using System;
using UnityEngine;

namespace com.Klazapp.Utility
{
    [Serializable]
    public class LineRendererProperties
    {
        [Header("Entity Prefab")]
        public LineRendererEntity entityPrefab;

        [Header("Spacing")]
        public float spacing;

        [Header("Animation Speed")]
        public float animateSpeed;

        [Header("Is Animated")]
        public bool animated;

        [Header("Movement Speed")]
        public float moveSpeed;

        [Header("Rotation Speed")]
        public float rotSpeed;
    }
}