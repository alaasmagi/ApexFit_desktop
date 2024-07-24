using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainInterface
{
    public interface IAnalysis
    {
        TrainingsComponent.ITrainings Trainings { get; }
        SecurityLayer.ISecurity SecurityLayer { get; }
        CoreComponent.ICore Core { get; }
        FoodsOrRecipesComponent.IFoodsOrRecipes FoodsOrRecipes { get; }
        UserProfileComponent.IUserProfile UserProfile { get; }
        SleepComponent.ISleep Sleep { get; }
    }
}
