using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace com.Klazapp.Utility
{
    [Serializable]
    public class LineRendererComponent
    {
        public List<float3> points = new();
        public List<LineRendererEntity> spawnedLineRendererEntities = new();
        public List<float> spawnedEntitiesProgress = new();
        public int PointsCount => points.Count;

        public void Initialize(IEnumerable<float3> newPoints)
        {
            points = new List<float3>(newPoints);
            spawnedLineRendererEntities.Clear();
            spawnedEntitiesProgress.Clear();
        }

        public void SetPoints(IEnumerable<float3> newPoints)
        {
            points = new List<float3>(newPoints);
        }

        public void RegisterEntity(LineRendererEntity entity, float initialProgress)
        {
            spawnedLineRendererEntities.Add(entity);
            spawnedEntitiesProgress.Add(initialProgress);
        }

        public void DestroyEntities()
        {
            foreach (var entity in spawnedLineRendererEntities)
            {
                UnityEngine.Object.Destroy(entity.gameObject);
            }
            
            spawnedLineRendererEntities.Clear();
            spawnedEntitiesProgress.Clear();
        }

        public void UpdateEntities(float deltaTime, LineRendererProperties properties)
        {
            for (var i = 0; i < spawnedLineRendererEntities.Count; i++)
            {
                var entity = spawnedLineRendererEntities[i];
                var progress = spawnedEntitiesProgress[i];

                if (properties.animated)
                {
                    progress += deltaTime * properties.animateSpeed / TotalDistance;

                    if (progress >= 1f)
                    {
                        progress -= 1f;
                    }
                    
                    spawnedEntitiesProgress[i] = progress;
                }

                var position = GetPointAlongPath(progress);
                var rotation = GetRotationAtPoint(progress);
                entity.SetWorldPosAndRot(position, rotation);
            }
        }

        public float TotalDistance => CalculateTotalDistance(points);

        public float3 GetPointAlongPath(float percentage)
        {
            var totalDistance = TotalDistance;
            var targetDistance = percentage * totalDistance;
            var currentDistance = 0f;

            for (var i = 0; i < points.Count - 1; i++)
            {
                var segmentDistance = math.distance(points[i], points[i + 1]);
                
                if (currentDistance + segmentDistance >= targetDistance)
                {
                    var t = (targetDistance - currentDistance) / segmentDistance;
                    return math.lerp(points[i], points[i + 1], t);
                }
                
                currentDistance += segmentDistance;
            }
            
            return points[^1];
        }

        public quaternion GetRotationAtPoint(float percentage)
        {
            var totalDistance = TotalDistance;
            var targetDistance = percentage * totalDistance;
            var currentDistance = 0f;

            for (var i = 0; i < points.Count - 1; i++)
            {
                var segmentDistance = math.distance(points[i], points[i + 1]);
              
                if (currentDistance + segmentDistance >= targetDistance)
                {
                    var direction = points[i + 1] - points[i];
                    
                    if (math.lengthsq(direction) > 0f)
                    {
                        return quaternion.LookRotationSafe(direction, new float3(0, 1, 0));
                    }
                    
                    break;  
                }
                
                currentDistance += segmentDistance;
            }
            
            return quaternion.identity;
        }


        private static float CalculateTotalDistance(IReadOnlyList<float3> points)
        {
            var distance = 0f;
            
            for (var i = 0; i < points.Count - 1; i++)
            {
                distance += math.distance(points[i], points[i + 1]);
            }
            
            return distance;
        }
    }
}
