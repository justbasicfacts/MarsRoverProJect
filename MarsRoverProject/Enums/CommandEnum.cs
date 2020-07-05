using MarsRoverProject.Classes;

namespace MarsRoverProject.Enums
{
    public enum CommandEnum
    {
        [StringValue("L")]
        SpinLeft,
        [StringValue("R")]
        SpinRight,
        [StringValue("M")]
        MoveForward
    }
}
