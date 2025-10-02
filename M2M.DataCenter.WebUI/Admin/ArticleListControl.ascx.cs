using System;
using System.Collections;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class ArticleListControl : System.Web.UI.UserControl
	{
		#region Members

		public Machine CurrentMachine
		{
			get
			{
				return (Machine)Session["CurrentMachine"];
			}
			set
			{
				Session["CurrentMachine"] = value;
                Session["CurrentMachineId"] = value.MachineId;
			}

		}

        #endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
            ucResponse.Reset();
		}

		protected void gridArticles_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			gridArticles.DataSource = CurrentMachine.Articles;
		}

		protected void gridArticles_ItemCreated(object sender, GridItemEventArgs e)
		{
		
		}

		protected void gridArticles_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
			{
				GridEditableItem editItem = (GridEditableItem)e.Item;
				
				GridTextBoxColumnEditor editArticleNumber = editItem.EditManager.GetColumnEditor("ArticleNumber") as GridTextBoxColumnEditor;
				editArticleNumber.TextBoxControl.Columns = 12;
				editArticleNumber.TextBoxControl.ReadOnly = !e.Item.OwnerTableView.IsItemInserted;

                GridTextBoxColumnEditor editToolNumber = editItem.EditManager.GetColumnEditor("ToolNumber") as GridTextBoxColumnEditor;
                editToolNumber.TextBoxControl.Columns = 12;
                
                GridTextBoxColumnEditor editIdealRunRate = editItem.EditManager.GetColumnEditor("IdealRunRate") as GridTextBoxColumnEditor;
				editIdealRunRate.TextBoxControl.Columns = 10;

				DropDownList list = editItem.FindControl("rcbRunRateUnit") as DropDownList;
				
				Article article = (e.Item.DataItem as Article);
				
				if(article != null)
					list.SelectedValue = article.RunRateUnit.ToString();

  
			}
			else if (e.Item is GridDataItem && !e.Item.IsInEditMode)
			{
				GridDataItem item = e.Item as GridDataItem;
				Label label = item.FindControl("lbRunRateUnit") as Label;
				
				label.Text = ResourceStrings.GetString((e.Item.DataItem as Article).RunRateUnit);
			}
		}

		protected void gridArticles_ItemCommand(object source, GridCommandEventArgs e)
		{
			
		}

		protected void gridArticles_InsertCommand(object source, GridCommandEventArgs e)
		{
			GridEditableItem editedItem = e.Item as GridEditableItem;

			//Set new values
			Hashtable newValues = new Hashtable();
			//The GridTableView will fill the values from all editable columns in the hash
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

			if (newValues["ArticleNumber"] != null && newValues["IdealRunRate"] != null)
			{
                string newArticle = newValues["ArticleNumber"].ToString();
                try
                {
                    
                    if (CurrentMachine.Articles.Contains(newArticle))
                    {
                        ucResponse.SetWarning(ResourceStrings.GetString("ArticleDuplicate"));
                        e.Canceled = true;
                        return;
                    }
                    Article article = CurrentMachine.Articles.Add(newArticle);
                    article.IdealRunRate = Convert.ToInt32(newValues["IdealRunRate"]);
                    GridEditableItem editItem = e.Item as GridEditableItem;
                    DropDownList list = editItem.FindControl("rcbRunRateUnit") as DropDownList;
                    article.RunRateUnit = (RunRateUnit)Enum.Parse(typeof(RunRateUnit), list.SelectedValue);
                    article.ToolNumber = newValues["ToolNumber"].ToString();

                    if (CurrentMachine.IsValid)
                    {
                        CurrentMachine.Save();
                        M2MDataCenter.ReloadConfiguration();
                        CurrentMachine = Machine.GetMachine(CurrentMachine.MachineId);
                        ucResponse.SetInformation(ResourceStrings.GetString("ArticleInsertSuccess"));
                    }

                    
                }
                catch (Exception ex)
                {
                    try { CurrentMachine.Articles.Remove(newArticle); }catch  {}
                    ucResponse.SetError(ResourceStrings.GetString("ArticleInsertFailed"), ex);
                    e.Canceled = true;
                }

                gridArticles.Rebind();
			}
		}

		protected void gridArticles_UpdateCommand(object source, GridCommandEventArgs e)
		{
			GridEditableItem editedItem = e.Item as GridEditableItem;

			//Set new values
			Hashtable newValues = new Hashtable();
			//The GridTableView will fill the values from all editable columns in the hash
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

			if (newValues["ArticleNumber"] != null && newValues["IdealRunRate"] != null)
			{
                try
                {
                    Article article = CurrentMachine.Articles.GetItem(newValues["ArticleNumber"].ToString());
                    article.IdealRunRate = Convert.ToInt32(newValues["IdealRunRate"]);
                    GridEditableItem editItem = e.Item as GridEditableItem;
                    DropDownList list = editItem.FindControl("rcbRunRateUnit") as DropDownList;
                    article.RunRateUnit = (RunRateUnit)Enum.Parse(typeof(RunRateUnit), list.SelectedValue);
                    article.ToolNumber = newValues["ToolNumber"].ToString();

                    if (CurrentMachine.IsValid)
                    {
                        CurrentMachine.Save();
                        M2MDataCenter.ReloadConfiguration();
                        CurrentMachine = Machine.GetMachine(CurrentMachine.MachineId);
                        ucResponse.SetInformation(ResourceStrings.GetString("ArticleUpdateSuccess"));
                    }

                    
                }
                catch (Exception ex)
                {
                    e.Canceled = true;
                    ucResponse.SetError(ResourceStrings.GetString("ArticleUpdateFailed"), ex);
                }
                gridArticles.Rebind();
			}
		}

		protected void gridArticles_DeleteCommand(object source, GridCommandEventArgs e)
		{
            try
            {
                string articleNumber = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleNumber"].ToString();

                CurrentMachine.Articles.Remove(articleNumber);

                CurrentMachine.Save();

                M2MDataCenter.ReloadConfiguration();
                ucResponse.SetInformation(ResourceStrings.GetString("ArticleDeleteSuccess"));

                
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                ucResponse.SetError(ResourceStrings.GetString("ArticleDeleteFailed"), ex);
            }
            gridArticles.Rebind();
		}
					
		#endregion

		#region Methods

		public void BindData()
		{
			gridArticles.Rebind();
		}

		#endregion
	}
}