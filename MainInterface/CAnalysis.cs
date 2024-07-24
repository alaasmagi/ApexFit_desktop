using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainInterface
{
    public class PrimaryInterface:IAnalysis
    {
        public TrainingsComponent.ITrainings Trainings { get; private set; }
        public SecurityLayer.ISecurity SecurityLayer { get; private set; }
        public CoreComponent.ICore Core { get; private set; }
        public FoodsOrRecipesComponent.IFoodsOrRecipes FoodsOrRecipes { get; private set; }
        public UserProfileComponent.IUserProfile UserProfile { get; private set; }
        public SleepComponent.ISleep Sleep { get; private set; }

        public PrimaryInterface(
            TrainingsComponent.ITrainings trainings,
            SecurityLayer.ISecurity securityLayer,
            CoreComponent.ICore core,
            FoodsOrRecipesComponent.IFoodsOrRecipes foodsOrRecipes,
            UserProfileComponent.IUserProfile userProfile,
            SleepComponent.ISleep sleep)
        {
            Trainings = trainings;
            SecurityLayer = securityLayer;
            Core = core;
            FoodsOrRecipes = foodsOrRecipes;
            UserProfile = userProfile;
            Sleep = sleep;
        }
    }
}
