using FluentAssertions.Execution;
using SpecFlow.Actions.Selenium;
using Specflow.Actions.Framework.Models;
using Specflow.Actions.Framework.Pages.Executors;

namespace Specflow.Actions.Framework.Tests.Steps;

[Binding]
internal class HomepageSteps
{
    private readonly HomePage _homePage;
    private readonly IBrowserInteractions _browserInteractions;

    public HomepageSteps(HomePage homePage, IBrowserInteractions browserInteractions)
    {
        _homePage = homePage;
        _browserInteractions = browserInteractions;
    }

    [Given(@"I navigate to the homepage")]
    public void GivenINavigateToThe()
    {
        _homePage.Go();
        _homePage.AcceptPageCookies();
    }

    [Then(@"I should see the page banner is displayed")]
    public void ThenIShouldSeeThePageBannerIsDisplayed() =>
        _homePage.PageBannerHeaderDisplayed().Should().BeTrue();

    [Then(@"the community section should be displayed")]
    public void ThenTheCommunitySectionShouldBeDisplayed() =>
        _homePage.CommunitySectionDisplayed().Should().BeTrue();

    [Then(@"each of the expected articles is displayed with the correct title")]
    public void ThenEachOfTheExpectedArticlesIsDisplayedWithTheCorrectTitle(IEnumerable<ArticlePosts> articlePosts)
    {
        foreach (var article in articlePosts)
        {
            using var scope = new AssertionScope();

            _homePage.ArticlePostDisplayed(article.Post).Should().BeTrue();
            _homePage.GetArticlePostLinkTitle(article.Post).Should().Be(article.Title);
        }
    }

    [When(@"I click on ([^']*)")]
    public void WhenIClickOnThe(string post) => _homePage.SelectArticlePost(post);

    [Then(@"I expect the page URL to be ([^']*)")]
    public void ThenIExpectThePageURLToBe(string url)
    {
        using var scope = new AssertionScope();

        _browserInteractions.GetUrl().Should().Be(url);
        _homePage.ArticleHeaderDisplayed().Should().BeTrue();
    }
}