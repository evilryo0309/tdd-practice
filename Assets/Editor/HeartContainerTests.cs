using Editor.Infrastructure;
using NUnit.Framework;
using UnityEngine.UI;

namespace Editor
{
    public class HeartContainerTests
    {
        public class TheReplenighMethod
        {
            protected Image Target;
            
            [SetUp]
            public void BeforeEveryTest()
            {
                Target = An.Image();
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(A.Heart())).Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Empty_Hearts_Are_Replenishted()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(
                        A.Heart().With(An.Image().WithFillAmount(1)),
                        A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                ((HeartContainer) A.HeartContainer()
                    .With(
                        A.Heart(), A.Heart().With(Target))).Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _Distributes_Heart_Pieces_Across_Multiple_Unfilled_Hearts()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(
                        A.Heart()
                            .With(An.Image().WithFillAmount(0.75f)),
                        A.Heart().With(Target))).Replenish(2);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }
        } 

        public class TheDepleteMethod
        {
            protected Image Target;

            [SetUp]
            public void BeforeEveryTest()
            {
                Target = An.Image().WithFillAmount(1);
            }

            [Test]
            public void _0_Sets_Full_Image_To_100_Percent_Fill()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(
                        A.Heart().With(Target))).Deplete(0);

                Assert.AreEqual(1, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Full_Image_To_75_Percent_Fill()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(
                        A.Heart().With(Target))).Deplete(1);

                Assert.AreEqual(0.75f, Target.fillAmount);
            }

            [Test]
            public void _2_Sets_Full_Image_To_75_Percent_Fill_After_Distribution()
            {
                ((HeartContainer)A.HeartContainer()
                    .With(
                        A.Heart().With(Target),
                        A.Heart()
                            .With(An.Image().WithFillAmount(0.25f)))).Deplete(2);

                Assert.AreEqual(0.75f, Target.fillAmount);
            }
        }
    }
}
