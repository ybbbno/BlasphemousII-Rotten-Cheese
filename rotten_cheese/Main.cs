using MelonLoader;

namespace rotten_cheese
{
    public class Main : MelonMod
    {
        public static rotten_cheese rotten_cheese { get; private set; }

        public override void OnLateInitializeMelon()
        {
            rotten_cheese = new rotten_cheese();
        }
    }
}