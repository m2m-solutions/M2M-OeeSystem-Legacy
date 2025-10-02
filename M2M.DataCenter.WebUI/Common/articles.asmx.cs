using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using Csla;
using Telerik.Web.UI;

namespace M2M.DataCenter.WebUI.Common
{
    [ScriptService]
    public class Articles : System.Web.Services.WebService
    {
        [System.Web.Services.WebMethod(EnableSession = true)]
        public GenericFilter Criteria()
        {
            return (GenericFilter)Session["CurrentCriteria"];
        }

        [WebMethod]
        public RadComboBoxItemData[] GetFacilityArticles(object context)
        {
            IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

            ArticlesInProductionList.Criteria criteria = new ArticlesInProductionList.Criteria();

            if (contextDictionary.ContainsKey("ArticlesFilter"))
            {
                criteria.ArticlesFilter = contextDictionary["ArticlesFilter"].ToString();
            }

            if (contextDictionary.ContainsKey("StartDate"))
            {
                criteria.StartDate = new SmartDate(contextDictionary["StartDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("EndDate"))
            {
                criteria.EndDate = new SmartDate(contextDictionary["EndDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("Shift"))
            {
                criteria.Shift = Convert.ToInt32(contextDictionary["Shift"]);
            }

            if (criteria.EndDate.IsEmpty)
                criteria.EndDate = new SmartDate(DateTime.Now);

            ArticlesInProductionList articles = ArticlesInProductionList.GetArticlesInProductionList(criteria);

            int numOfArticles = articles.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(numOfArticles);

            for (int i = 0; i < numOfArticles; i++)
            {
                RadComboBoxItemData item = new RadComboBoxItemData();
                item.Text = articles[i].ArticleNumber;
                item.Value = articles[i].ArticleNumber;
                result.Add(item);
            }

            return result.ToArray();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public RadComboBoxItemData[] GetDivisionArticles(object context)
        {
            IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

            ArticlesInProductionList.Criteria criteria = new ArticlesInProductionList.Criteria();

            criteria.DivisionId = Criteria().DivisionId;

            if (contextDictionary.ContainsKey("ArticlesFilter"))
            {
                criteria.ArticlesFilter = contextDictionary["ArticlesFilter"].ToString();
            }

            if (contextDictionary.ContainsKey("StartDate"))
            {
                criteria.StartDate = new SmartDate(contextDictionary["StartDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("EndDate"))
            {
                criteria.EndDate = new SmartDate(contextDictionary["EndDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("Shift"))
            {
                criteria.Shift = Convert.ToInt32(contextDictionary["Shift"]);
            }

            if (criteria.EndDate.IsEmpty)
                criteria.EndDate = new SmartDate(DateTime.Now);

            ArticlesInProductionList articles = ArticlesInProductionList.GetArticlesInProductionList(criteria);

            int numOfArticles = articles.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(numOfArticles);

            for (int i = 0; i < numOfArticles; i++)
            {
                RadComboBoxItemData item = new RadComboBoxItemData();
                item.Text = articles[i].ArticleNumber;
                item.Value = articles[i].ArticleNumber;
                result.Add(item);
            }

            return result.ToArray();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public RadComboBoxItemData[] GetMachineArticles(object context)
        {
            IDictionary<string, object> contextDictionary = (IDictionary<string, object>)context;

            ArticlesInProductionList.Criteria criteria = new ArticlesInProductionList.Criteria();

            criteria.DivisionId = Criteria().DivisionId;
            criteria.MachineId = Criteria().MachineId;

            if (contextDictionary.ContainsKey("ArticlesFilter"))
            {
                criteria.ArticlesFilter = contextDictionary["ArticlesFilter"].ToString();
            }

            if (contextDictionary.ContainsKey("StartDate"))
            {
                criteria.StartDate = new SmartDate(contextDictionary["StartDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("EndDate"))
            {
                criteria.EndDate = new SmartDate(contextDictionary["EndDate"] as DateTime?);
            }

            if (contextDictionary.ContainsKey("Shift"))
            {
                criteria.Shift = Convert.ToInt32(contextDictionary["Shift"]);
            }

            if (criteria.EndDate.IsEmpty)
                criteria.EndDate = new SmartDate(DateTime.Now);

            ArticlesInProductionList articles = ArticlesInProductionList.GetArticlesInProductionList(criteria);

            int numOfArticles = articles.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(numOfArticles);

            for (int i = 0; i < numOfArticles; i++)
            {
                RadComboBoxItemData item = new RadComboBoxItemData();
                item.Text = articles[i].ArticleNumber;
                item.Value = articles[i].ArticleNumber;
                result.Add(item);
            }

            return result.ToArray();
        }
    }
}
