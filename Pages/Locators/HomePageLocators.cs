using OpenQA.Selenium;

namespace Specflow.Actions.Framework.Pages.Locators;

internal abstract class HomePageLocators
{
    public static By PageBannerHeaderLocator => By.ClassName("cover-photo-headline");
    public static By CookiesAcceptButtonLocator => By.Id("cookie_action_close_header");
    public static By CommunitySectionLocator => By.CssSelector("div[class='row top']");
    public static By ArticlePostLocator(string? postId) => By.Id($"{postId}");

    public static By ArticlePostLinkLocator(string? postId) =>
        By.CssSelector($"article[id='{postId}'] a");

    public static By ArticleHeaderLocator =>
        By.CssSelector("h1[class='blog-post-title / h2-light baseline-small']");
}