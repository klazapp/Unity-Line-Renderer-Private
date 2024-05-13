using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace com.Klazapp.Utility
{
    public class LineRenderer : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] 
        private LineRendererProperties lineRendererProperties;

        private LineRendererComponent lineRendererComponent;
        private List<float> pointsPercentage;

        public float progressToCheck;

        private void Awake()
        {
            lineRendererComponent = new LineRendererComponent();
            pointsPercentage = new List<float>();
        }

        public void OnCreated(List<float3> newPoints)
        {
            gameObject.SetActive(true);
            DestroyEntities();
            
            lineRendererComponent.Initialize(newPoints);
            pointsPercentage = new List<float>(CalculatePercentagesAtPoints(newPoints));

            CreateEntities();
        }

        public int PointsCount()
        {
            return lineRendererComponent.PointsCount;
        }

        public void SetPoints(IEnumerable<float3> newPoints)
        {
            lineRendererComponent.SetPoints(newPoints);
        }

        private void CreateEntities()
        {
            var totalDistance = lineRendererComponent.TotalDistance;
            var entityNumber = (int)math.ceil(totalDistance / lineRendererProperties.spacing);

            for (var i = 0; i < entityNumber; i++)
            {
                var percentage = i / (float)(entityNumber - 1);
                var position = lineRendererComponent.GetPointAlongPath(percentage);

                var entity = Instantiate(lineRendererProperties.entityPrefab, position, quaternion.identity, transform);
 
#if UNITY_EDITOR
                entity.name += $" Entity {i}";
#endif

                lineRendererComponent.RegisterEntity(entity, percentage);
            }
        }

        private void DestroyEntities()
        {
            lineRendererComponent.DestroyEntities();
        }

        private void Update()
        {
            lineRendererComponent.UpdateEntities(Time.deltaTime, lineRendererProperties);
        }

        private IEnumerable<float> CalculatePercentagesAtPoints(List<float3> points)
        {
            var percentages = new List<float>();
            var totalDistance = lineRendererComponent.TotalDistance;
            var currentDistance = 0f;

            percentages.Add(0f); // Start at 0%

            for (var i = 0; i < points.Count - 1; i++)
            {
                currentDistance += math.distance(points[i], points[i + 1]);
                percentages.Add(currentDistance / totalDistance);
            }

            percentages[^1] = 1f; // Ensure the last point is always 100%
            return percentages;
        }

        // Retrieves the progress at a specific index
        public float GetProgressAtIndex(int index)
        {
            if (index >= 0 && index < pointsPercentage.Count)
                return pointsPercentage[index];
            
            Debug.LogError("Index out of range.");
            return -1;
        }

        // Sets a progress threshold at a specific index, adding an additional progress increment
        public void SetProgressThresholdAtIndex(int index, float additionalProgress)
        {
            var progress = GetProgressAtIndex(index);
          
            if (progress == -1) 
                return;
            
            // Check if the index was valid
            progressToCheck = progress + additionalProgress;
            // Ensure progressToCheck does not exceed 1
            progressToCheck = Mathf.Clamp01(progressToCheck);
        }
    }
}
