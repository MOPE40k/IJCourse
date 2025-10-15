using Module_10_11_Homework.Inputs;

namespace Module_10_11_Homework.Characters
{
    public class PlayerCharacter : Character
    {
        protected override void InitInput()
            => input = new InputManagerFacade();
    }
}