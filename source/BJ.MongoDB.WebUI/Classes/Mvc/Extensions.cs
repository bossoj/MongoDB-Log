using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BJ.MongoDB.Logger;
using BJ.MongoDB.WebUI.Models;
using WebGrease.Css.Extensions;

namespace BJ.MongoDB.WebUI.Mvc
{
    public static class Extension
    {
        public static MvcHtmlString TableColumnHeader(this HtmlHelper html, LogViewFilters viewParams, string propertyName, string linkText)
        {
            return TableColumnHeader(html, viewParams, propertyName, linkText, string.Empty);
        }

        //----------------------------------------------------------------------------------------

        public static MvcHtmlString TableColumnHeader(this HtmlHelper html, LogViewFilters viewFilters, string propertyName, string linkText, string addThAttrs)
        {
            string action = Convert.ToString(html.ViewContext.Controller.ValueProvider.GetValue("action").RawValue);
            var filters = viewFilters.SetOrderBy(propertyName);

            var routeValue = new RouteValueDictionary();

            routeValue["Page"] = filters.PageInt;
            routeValue["DateFrom"] = filters.DateFrom;
            routeValue["DateTo"] = filters.DateTo;
            routeValue["SearchStr"] = filters.SearchStr;
            routeValue["OrderBy"] = filters.OrderBy;
            routeValue["App"] = filters.App;

            for (int i = 0; i < viewFilters.Level.Count; ++i)
                routeValue["Level[" + i + "]"] = viewFilters.Level[i];

            string link = html.ActionLink(linkText, action, routeValue).ToHtmlString(); 
    
            string colClass = viewFilters.GetColumnClass(propertyName);
            return new MvcHtmlString(string.Format(@"<th class=""{0}"" {2}>{1}</th>", colClass, link, addThAttrs));
        }

        //----------------------------------------------------------------------------------------

        public static MvcHtmlString SpanLevel(this HtmlHelper html, string level)
        {
            string classAttr = String.Empty;

            if (level == LevelType.DEBUG)
                classAttr = "label-default";
            else if (level == LevelType.INFO)
                classAttr = "label-info";
            else if (level == LevelType.WARN)
                classAttr = "label-warning";
            else if (level == LevelType.ERROR)
                classAttr = "label-danger";
            else if (level == LevelType.FATAL)
                classAttr = "label-danger";

            string result = String.Format(@"<span class=""label {0}"">{1}</span>", classAttr, level);

            return new MvcHtmlString(result);
        }

        //----------------------------------------------------------------------------------------

        public static MvcHtmlString TegTR(this HtmlHelper html, string level)
        {
            string classAttr = String.Empty;

            if (level == LevelType.WARN)
                classAttr = @"class=""warning""";
            else if (level == LevelType.ERROR)
                classAttr = @"class=""danger""";
            else if (level == LevelType.FATAL)
                classAttr = @"class=""danger""";

            return new MvcHtmlString(classAttr);
        }

        //----------------------------------------------------------------------------------------

        public static MvcHtmlString CellCountText(this HtmlHelper html, long count, string level = "")
        {
            string result = String.Empty;
            string classAttr = "label-primary";

            if (level == LevelType.DEBUG)
                classAttr = "label-default";
            else if (level == LevelType.INFO)
                classAttr = "label-info";
            else if (level == LevelType.WARN)
                classAttr = "label-warning";
            else if (level == LevelType.ERROR)
                classAttr = "label-danger";
            else if (level == LevelType.FATAL)
                classAttr = "label-danger";

            if(count > 0)
                result = String.Format(@"<span class=""label {1} lable-badge"">{0}</span>", count, classAttr);

            return new MvcHtmlString(result);
        }

        //----------------------------------------------------------------------------------------

        public static MvcHtmlString LinkApp(this HtmlHelper html, string appName)
        {
            string link = html.ActionLink(appName, "Logs", "Home", new { App = appName }, null).ToHtmlString();

            return new MvcHtmlString(link);
        }

        //----------------------------------------------------------------------------------------
      
        public static MvcHtmlString ButtonCancel(this HtmlHelper helper, string name, string defaultUrl)
        {
            return new MvcHtmlString(string.Format(
                @"<a href=""{0}"" class=""btn btn-primary"" id=""cancel""><span class=""glyphicon glyphicon-arrow-left""></span> {1}</a>",
                HttpContext.Current.Request["ReturnUrl"] ?? defaultUrl, name));
        }

        // ---------------------------------------------------------------------------------------

        public static MvcHtmlString Button(this HtmlHelper helper, string name, string action, string controller, object routeValues, object htmlAttributes)
        {
            return helper.ActionLink(name, action, controller, routeValues, htmlAttributes);
        }
    }
}