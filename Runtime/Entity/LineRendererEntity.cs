using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace com.Klazapp.Utility
{
    public class LineRendererEntity : MonoBehaviour
    {
        #region Base Flow
        public virtual void OnCreated()
        {

        }
     
        public virtual void OnUpdate()
        {

        }
        #endregion
        
        #region Public Access
        //Used to set alpha value of each individual line entity
        public virtual void SetAlpha(float alphaVal)
        {
            
        }
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 GetLocalPos()
        {
            return this.transform.localPosition;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 GetWorldPos()
        {
            return this.transform.position;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalPos(float3 localPos)
        {
            this.transform.localPosition = localPos;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetWorldPos(float3 worldPos)
        {
            this.transform.position = worldPos;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion GetLocalRot()
        {
            return this.transform.localRotation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion GetWorldRot()
        {
            return this.transform.rotation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalRot(quaternion localRot)
        {
            this.transform.localRotation = localRot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetWorldRot(quaternion worldRot)
        {
            this.transform.rotation = worldRot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalPosAndRot(float3 localPos, quaternion localRot)
        {
            this.transform.SetLocalPositionAndRotation(localPos, localRot);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetWorldPosAndRot(float3 worldPos, quaternion worldRot)
        {
            this.transform.SetPositionAndRotation(worldPos, worldRot);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalScale(float3 scale)
        {
            this.transform.localScale = scale;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 GetLocalScale()
        {
            return this.transform.localScale;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetGameObjectLocalActiveState()
        {
            return this.gameObject.activeSelf;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetGameObjectWorldActiveState()
        {
            return this.gameObject.activeInHierarchy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnableGameObject()
        {
            this.gameObject.SetActive(true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DisableGameObject()
        {
            this.gameObject.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetGameObjectState(bool state)
        {
            this.gameObject.SetActive(state);
        }
        #endregion
    }
}