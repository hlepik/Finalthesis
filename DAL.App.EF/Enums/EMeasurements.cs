using System.ComponentModel;
using System.Runtime.Serialization;

namespace DAL.App.EF.Enums;

public enum EMeasurements
{
    neckSize,
    chestGirth,
    waistGirth,
    upperHipGirth,
    waistLengthFirst,
    hipGirth,
    waistLengthSec,
    upperArmGirth,


}

public static class EnumExtensions
{
    public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        return type.GetField(name)!
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .SingleOrDefault()!;
    }

    public static String GetDescription(this Enum value)
    {
        var description = GetAttribute<DescriptionAttribute>(value);
        return description != null ? description.Description : null!;
    }
}