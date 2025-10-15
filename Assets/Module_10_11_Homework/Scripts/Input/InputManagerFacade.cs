using UnityEngine;

namespace Module_10_11_Homework.Inputs
{
    public class InputManagerFacade : IInput
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public Vector3 MoveAxes => new Vector3(
            Input.GetAxisRaw(HorizontalAxisName),
            0f,
            Input.GetAxisRaw(VerticalAxisName)
        );
    }
}