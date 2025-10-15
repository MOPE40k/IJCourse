namespace Module_10_11_Homework.Utils
{
    public class Timer
    {
        public float Time { get; private set; } = 0f;

        public void Increment(float delta) => Time += delta;

        public void Decrement(float delta)
        {
            if (Time <= 0)
                return;

            Time -= delta;
        }

        public void Reset() => Time = 0f;
    }
}