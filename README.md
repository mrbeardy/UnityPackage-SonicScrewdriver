# Sonic Screwdriver

Sonic Screwdriver is a utility and productivity package for Unity that aims to make your life easier.

### Current Features

- **Auto-collapse inspectors**  
  Automatically collapses all inspectors in the inspector window. 
- **Watch**  
  Displays a debug canvas on screen for fields marked with the `[Watch]` Attribute. Supports both screen-space and world-space:

## Watch Feature
### `[Watch]` Attribute

![image](https://user-images.githubusercontent.com/578902/103529360-7114d000-4e7d-11eb-9d59-350ed027c5f1.png)

```cs
public class Box : MonoBehaviour
{
    public Color color;
    
    [Watch] private Vector3 position;
    [Watch] private string colorHex;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = color;

        colorHex = ColorUtility.ToHtmlStringRGB(color);
    }

    private void Update()
    {
        position = transform.position;
    }
}
```

```cs
public class ThirdPersonCharacter : MonoBehaviour
{
	// ...

	[Watch] bool m_IsGrounded;
	[Watch] float m_TurnAmount;
	[Watch] bool m_Crouching;

	// ...
}
```

### `[WatchOptions]` Attribute

![image](https://user-images.githubusercontent.com/578902/103529541-c18c2d80-4e7d-11eb-8f07-d3db2ac9e4a5.png)

```cs
[WatchOptions(WatchOptionsAttribute.DisplayType.WorldSpace)]
public class Box : MonoBehaviour {
  // ...
}
```

