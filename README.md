# Dynamic Database Column Configuration

## Introduction

### Objective
Dynamically configure database columns based on attributes.

### Use Case
Customize which properties of an entity should be included in the database.

## Components

### Entity Class (e.g., BaseUser)
Contains properties marked with attributes.

```csharp
public class BaseUser
{
    [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Id))]
    public int Id { get; set; }

    [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Name))]
    public string Name { get; set; }

    // Other properties...
}
```
### Attribute (e.g., DynamicDatabaseColumnAttribute)
Marks properties for dynamic database column creation.

```csharp
[AttributeUsage(AttributeTargets.Property)]
public class DynamicDatabaseColumnAttribute : Attribute
{
    public bool IsActive { get; }
    public Type ConfigType { get; }

    public DynamicDatabaseColumnAttribute(Type configType, string propertyName)
    {
        ConfigType = configType;
        // Determine IsActive based on configuration...
    }
}
```
### Example Classes
```csharp
public static class UserPropertiesConfigs
{
    public static bool Id { get; set; } = true;
    public static bool Name { get; set; } = true;
    // Other configuration properties...
}

```
## Dynamic Instance Creation
### Factory Method (e.g., CreateInstance())
Uses reflection to create instances of entities.
Checks attributes to determine whether properties should be active.

```csharp
public class BaseUser
{
    public static BaseUser CreateInstance()
    {
        // Implementation...
    }
}

```
## DbContext Configuration
### Override OnModelCreating Method
Iterates over entity types and properties.
Uses attributes to decide whether to include or ignore properties.
Handles the issue of modifying the model during enumeration.

```csharp
public class DataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Implementation...
    }
}

```

### Benefits
* Flexibility: Easily adapt the database schema without modifying entity classes.
* Configuration Centralization: Keep configuration details in separate classes for clarity.
* Reusability: Apply the concept across multiple entities.
Usage Example
```csharp
  
var user = BaseUser.CreateInstance();
// Use the dynamically created user instance as needed.

```
