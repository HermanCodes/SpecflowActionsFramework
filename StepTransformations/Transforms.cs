using Specflow.Actions.Framework.Models;
using TechTalk.SpecFlow.Assist;

namespace Specflow.Actions.Framework.StepTransformations;

[Binding]
internal class Transforms
{
    [StepArgumentTransformation(@"each of the expected articles is displayed with the correct title")]
    public static IEnumerable<ArticlePosts> ThenEachOfTheExpectedArticlesIsDisplayedWithTheCorrectTitle(Table table) =>
        table.CreateSet<ArticlePosts>();
}