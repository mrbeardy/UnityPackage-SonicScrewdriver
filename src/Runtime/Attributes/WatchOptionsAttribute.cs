using System;

namespace Beardy.SonicScrewdriver.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WatchOptionsAttribute : Attribute
    {
        public enum DisplayType
        {
            ScreenSpace,
            WorldSpace
        }

        public DisplayType displayType { get; private set; }

        public WatchOptionsAttribute(DisplayType displayType = DisplayType.ScreenSpace)
        {
            this.displayType = displayType;
        }
    }
}