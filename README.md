# LineRenderer Utility for Unity

## Introduction
The `LineRenderer` utility, part of the `com.Klazapp.Utility` namespace, provides a flexible and efficient solution for rendering lines in Unity projects. It allows for easy creation and manipulation of lines with customizable properties, catering to various use cases such as drawing paths, visualizing data, and more.

## Features
- **Dynamic Line Rendering**: Render lines dynamically based on a set of points with adjustable properties.
- **Customizable Properties**: Control line spacing, animation, movement speed, rotation speed, and more to achieve desired visual effects.
- **Efficient Entity Management**: Manage line entities efficiently, allowing for smooth performance even with a large number of lines.
- **Platform Compatibility**: Compatible with all Unity-supported platforms, ensuring consistent behavior across different devices.

## Dependencies
To use the `LineRenderer` utility, ensure your Unity project meets the following requirements:
- **Unity Version**: Requires Unity 2020.3 LTS or higher.

## Compatibility
| Compatibility | URP | BRP | HDRP |
|---------------|-----|-----|------|
| Compatible    | ✔️   | ✔️   | ✔️    |

## Installation
1. In Unity, go to `Window` > `Package Manager`.
2. Click the `+` icon, select `Add package from git URL...`, and input `https://github.com/klazapp/Unity-LineRenderer.git`.
3. The package will be automatically downloaded and integrated into your project.

## Usage
To use the `LineRenderer` utility, follow these steps:

### Setting Up Line Rendering
1. Attach the `LineRenderer` script to a GameObject in your scene.
2. Set the desired properties such as line spacing, animation settings, etc., in the inspector.

### Creating Lines
```csharp
// Instantiate a LineRenderer object
var lineRenderer = new LineRenderer();

// Call OnCreated method to create a line with a list of points
lineRenderer.OnCreated(newPoints);
```

### Manipulating Lines
```csharp
// Set new points for the line
lineRenderer.SetPoints(newPoints);

// Get the number of points in the line
int pointsCount = lineRenderer.PointsCount();

// Set progress threshold at a specific index
lineRenderer.SetProgressThresholdAtIndex(index, additionalProgress);
```

### Updating Lines
The lines will be automatically updated based on the specified properties.

## Planned Enhancements (To-Do List)
- **Bezier Curve Support**: Implement support for rendering lines using Bezier curves for smoother curves.
- **Performance Optimization**: Optimize line rendering algorithms for better performance with large datasets.
- **Unity Editor Extensions**: Add custom editor tools for easier line creation and manipulation within the Unity Editor.

## License
`LineRenderer` is available under the [MIT License](LICENSE).
