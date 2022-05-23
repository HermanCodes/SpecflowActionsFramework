using OpenQA.Selenium;
using Specflow.Actions.Framework.Pages.Locators;
using SpecFlow.Actions.Selenium;

namespace Specflow.Actions.Framework.Pages.Executors;

internal class HomePage : HomePageLocators
{
    private static readonly string Url = "https://derivco.com/";

    private readonly IBrowserInteractions _browserInteractions;

    public HomePage(IBrowserInteractions browserInteractions)
    {
        _browserInteractions = browserInteractions;
    }

    private IWebElement PageBannerHeader =>
        _browserInteractions.WaitAndReturnElement(PageBannerHeaderLocator);

    private IWebElement CookiesAcceptButton =>
        _browserInteractions.WaitAndReturnElement(CookiesAcceptButtonLocator);
    private IWebElement CommunitySection =>
        _browserInteractions.WaitAndReturnElement(CommunitySectionLocator);

    private IWebElement ArticleHeader =>
        _browserInteractions.WaitAndReturnElement(ArticleHeaderLocator);

    private IWebElement ArticlePost(string postId) =>
    _browserInteractions.WaitAndReturnElement(ArticlePostLocator(postId));

    private IWebElement ArticlePostLink(string postId) =>
        _browserInteractions.WaitAndReturnElement(ArticlePostLinkLocator(postId));

    public void Go() => _browserInteractions.GoToUrl(Url);

    public void AcceptPageCookies() => CookiesAcceptButton.ClickWithRetry();

    public bool PageBannerHeaderDisplayed() => PageBannerHeader.Displayed;

    public bool CommunitySectionDisplayed() => CommunitySection.Displayed;

    public bool ArticleHeaderDisplayed() => ArticleHeader.Displayed;

    public bool ArticlePostDisplayed(string postId) => ArticlePost(postId).Displayed;

    public void SelectArticlePost(string postId) => ArticlePostLink(postId).Click();

    public string GetArticlePostLinkTitle(string postId) =>
        ArticlePostLink(postId).GetAttribute("title");
}