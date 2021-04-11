using System.Collections.Generic;

namespace Editor.Infrastructure
{
    public class HeartContainerBuilder : TestDataBuilder<HeartContainer>
    {
        List<Heart> _hearts;

        public HeartContainerBuilder()
        {
            _hearts = new List<Heart>();
        }

        public HeartContainerBuilder With(params Heart[] hearts)
        {
            foreach (var heart in hearts)
                _hearts.Add(heart);
            return this;
        }

        public override HeartContainer Build()
        {
            return new HeartContainer(_hearts);
        }
    }
}