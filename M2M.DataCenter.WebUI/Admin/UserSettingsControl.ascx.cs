using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using M2M.DataCenter.Localization;
using System.Globalization;

namespace M2M.DataCenter.WebUI.Admin
{
    public partial class UserSettingsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucResponse.Reset();
            
            if (!Page.IsPostBack)
                BindData();
        }

        protected void gridUsers_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridUsers.DataSource = UserCollection.GetUserCollection(false);
        }

        public void BindData()
        {
            gridUsers.Rebind();
        }

        protected void gridUsers_DataBound(object sender, EventArgs e)
        {
        }

        protected void gridUsers_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                GridEditFormItem editFormItem = e.Item as GridEditFormItem;

                DropDownList dlRoles = editFormItem.FindControl("dlRoles") as DropDownList;
                dlRoles.DataSource = M2MDataCenter.User.Roles;
                dlRoles.DataTextField = "DisplayName";
                dlRoles.DataValueField = "Role";
                dlRoles.DataBind();
                dlRoles.SelectedIndexChanged += new EventHandler(dlRoles_SelectedIndexChanged);
                
                RadComboBox cbDivisions = editFormItem.FindControl("cbDivisions") as RadComboBox;
                cbDivisions.DataSource = M2MDataCenter.GetDivisionList();
                cbDivisions.DataBind();

                RadComboBox cbModules = editFormItem.FindControl("cbModules") as RadComboBox;
                cbModules.DataSource = M2MDataCenter.GetUserModuleList();
                cbModules.DataBind();

                DropDownList dlCultures = editFormItem.FindControl("dlCultures") as DropDownList;
                dlCultures.DataSource = CultureList.GetCultureList();
                dlCultures.DataTextField = "Name";
                dlCultures.DataValueField = "Name";
                dlCultures.DataBind();
                
                foreach (RadComboBoxItem division in cbDivisions.Items)
                {
                    CheckBox chk1 = division.FindControl("chk1") as CheckBox;
                    if (M2MDataCenter.User.CanAccessDivision(division.Value))
                    {
                        chk1.Attributes["onclick"] = String.Format("onCheckBoxClick('{0}')", cbDivisions.ClientID);
                    }
                    else
                    {
                        chk1.Enabled = false;
                        Label lb1 = division.FindControl("lb1") as Label;
                        lb1.Enabled = false;
                    }
                }

                foreach (RadComboBoxItem module in cbModules.Items)
                {
                    CheckBox chk1 = module.FindControl("chk1") as CheckBox;
                    chk1.Attributes["onclick"] = String.Format("onCheckBoxClick('{0}')", cbModules.ClientID);
                }

                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    GridDataItem parentItem = editFormItem.ParentItem;
                    User user = parentItem.DataItem as User;
                    dlRoles.SelectedValue = user.RoleWithHighestAccess.Role;
                    dlCultures.SelectedValue = user.Settings.Culture;

                    cbDivisions.Enabled = dlRoles.SelectedValue != "System";
                    cbModules.Enabled = dlRoles.SelectedValue != "System";

                    if (user.UserId == M2MDataCenter.User.UserId)
                    {
                        TextBox tbUser = (TextBox)editFormItem.FindControl("tbUserName");
                        tbUser.Enabled = false;
                        dlRoles.Enabled = false;
                    }

                    int selectedCount = 0;

                    foreach (RadComboBoxItem division in cbDivisions.Items)
                    {
                        
                        if (user.CanSeeAllDivisions || user.Divisions.Contains(division.Value))
                        {
                            CheckBox chk1 = division.FindControl("chk1") as CheckBox;
                            chk1.Checked = true;

                            if (cbDivisions.Text != "")
                                cbDivisions.Text += ",";

                            cbDivisions.Text += division.Text;

                            selectedCount++;
                        }
                    }

                    if (selectedCount == cbDivisions.Items.Count)
                        cbDivisions.Text = ResourceStrings.GetString("AllDivisions");

                    selectedCount = 0;

                    foreach (RadComboBoxItem module in cbModules.Items)
                    {
                        if (user.Modules.Contains(module.Value))
                        {
                            CheckBox chk1 = module.FindControl("chk1") as CheckBox;
                            chk1.Checked = true;

                            if (cbModules.Text != "")
                                cbModules.Text += ",";

                            cbModules.Text += module.Text;

                            selectedCount++;
                        }
                    }
                    if(selectedCount == 0)
                        cbModules.Text = "";
                    else if (selectedCount == cbModules.Items.Count)
                        cbModules.Text = ResourceStrings.GetString("All");
                }
                else
                    dlRoles.SelectedValue = "User";
            }
            else if (e.Item is GridDataItem && !e.Item.IsInEditMode)
            {
                GridDataItem item = (e.Item as GridDataItem);
                User user = (item.DataItem as User);
                item["RoleWithHighestAccess"].Text = user.RoleWithHighestAccess.DisplayName;
            }
        }

        void dlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dlRoles = (sender as DropDownList);
            RadComboBox cbDivisions = (dlRoles.Parent.FindControl("cbDivisions") as RadComboBox);

            cbDivisions.Enabled = dlRoles.SelectedValue != "System";
            
            if(dlRoles.SelectedValue == "System")
            {
                cbDivisions.Text = ResourceStrings.GetString("All");
            }
        }

        private void SaveRoles(User user, string role)
        {
            user.Roles.Clear();

            foreach (RoleListItem item in M2MDataCenter.GetAvailableRoles())
            {
                UserRole userRole = user.Roles.Add();
                userRole.Role = item.Role;
                
                if (role == item.Role)
                    break;
            }
        }


        protected void gridUsers_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditFormItem editFormItem = e.Item as GridEditFormItem;
            string userId = (string)editFormItem.GetDataKeyValue("UserId");

            Hashtable newValues = new Hashtable();
            //The GridTableView will fill the values from all editable columns in the hash
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editFormItem);

            DropDownList dlRoles = editFormItem.FindControl("dlRoles") as DropDownList;
            DropDownList dlCultures = editFormItem.FindControl("dlCultures") as DropDownList;
            
            RadComboBox cbDivisions = editFormItem.FindControl("cbDivisions") as RadComboBox;
            RadComboBox cbModules = editFormItem.FindControl("cbModules") as RadComboBox;

            try
            {
                UserCollection users = UserCollection.GetUserCollection();
                User user = users.GetItem(userId);
                user.Password = (string)newValues["Password"];
                if (newValues["DisplayName"].ToString() != "")
                    user.DisplayName = (string)newValues["DisplayName"];
                else
                    user.DisplayName = user.UserId;
                SaveRoles(user, dlRoles.SelectedValue);

                user.Settings.Culture = dlCultures.SelectedValue;
                
                user.Divisions.Clear();

                if (cbDivisions.Text != ResourceStrings.GetString("AllDivisions"))
                {
                    foreach (RadComboBoxItem divisionItem in cbDivisions.Items)
                    {
                        CheckBox chk1 = divisionItem.FindControl("chk1") as CheckBox;

                        if (chk1.Checked)
                        {
                            UserDivision division = user.Divisions.Add();
                            division.DivisionId = divisionItem.Value;
                        }
                    }
                }

                user.Modules.Clear();

                if (cbModules.Text != ResourceStrings.GetString("AllModules"))
                {
                    foreach (RadComboBoxItem moduleItem in cbModules.Items)
                    {
                        CheckBox chk1 = moduleItem.FindControl("chk1") as CheckBox;

                        if (chk1.Checked)
                        {
                            UserModule module = user.Modules.Add();
                            module.Module = moduleItem.Value;
                        }
                    }
                }
                
                users.Save();
                
                if (user.UserId == M2MDataCenter.User.UserId)
                    M2MDataCenter.ReloadConfiguration();

                ucResponse.SetInformation(String.Format(ResourceStrings.GetString("UserUpdated"), userId));
            }
            catch (Exception ex)
            {
                ucResponse.SetError(String.Format(ResourceStrings.GetString("UserNotUpdated"), userId), ex);
                e.Canceled = true;
            }
        }

        protected void gridUsers_DeleteCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem dataItem = e.Item as GridDataItem;
            string userId = (string)dataItem.GetDataKeyValue("UserId");

            if (userId == M2MDataCenter.User.UserId)
            {
                ucResponse.SetError(ResourceStrings.GetString("UserDeleteNotPossible"));
                e.Canceled = true;
                return;
            }

            try
            {
                UserCollection users = UserCollection.GetUserCollection();
                users.Remove(userId);
                users.Save();
                ucResponse.SetInformation(String.Format(ResourceStrings.GetString("UserDeleted"), userId));
            }
            catch (Exception ex)
            {
                ucResponse.SetError(String.Format(ResourceStrings.GetString("UserNotDeleted"), userId), ex);
                e.Canceled = true;
            }
        }


        protected void gridUsers_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridEditFormItem editFormItem = e.Item as GridEditFormItem;

            Hashtable newValues = new Hashtable();
            //The GridTableView will fill the values from all editable columns in the hash
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editFormItem);
            DropDownList dlRoles = editFormItem.FindControl("dlRoles") as DropDownList;
            DropDownList dlCultures = editFormItem.FindControl("dlCultures") as DropDownList;

            RadComboBox cbDivisions = editFormItem.FindControl("cbDivisions") as RadComboBox;
            RadComboBox cbModules = editFormItem.FindControl("cbModules") as RadComboBox;

            string userId = (string)newValues["UserId"];

            try
            {
                UserCollection users = UserCollection.GetUserCollection();
                User user = users.Add(userId);
                user.Password = (string)newValues["Password"];
                if (newValues["DisplayName"].ToString() != "")
                    user.DisplayName = (string)newValues["DisplayName"];
                else
                    user.DisplayName = user.UserId;
                SaveRoles(user, dlRoles.SelectedValue);
                
                user.Settings.Culture = dlCultures.SelectedValue;
                if (cbDivisions.Text != ResourceStrings.GetString("AllDivisions"))
                {
                    foreach (RadComboBoxItem divisionItem in cbDivisions.Items)
                    {
                        CheckBox chk1 = divisionItem.FindControl("chk1") as CheckBox;

                        if (chk1.Checked)
                        {
                            UserDivision division = user.Divisions.Add();
                            division.DivisionId = divisionItem.Value;
                        }
                    }
                }

                foreach (RadComboBoxItem moduleItem in cbModules.Items)
                {
                    CheckBox chk1 = moduleItem.FindControl("chk1") as CheckBox;

                    if (chk1.Checked)
                    {
                        UserModule module = user.Modules.Add();
                        module.Module = moduleItem.Value;
                    }
                }

                users.Save();

                ucResponse.SetInformation(String.Format(ResourceStrings.GetString("UserAdded"), userId));
            }
            catch (Exception ex)
            {
                ucResponse.SetError(String.Format(ResourceStrings.GetString("UserNotAdded"), userId), ex);
                e.Canceled = true;
            }
        }

        protected void cbDivisions_DataBound(object sender, EventArgs e)
        {

        }

        protected string GetResourceString(string key)
        {
            return ResourceStrings.GetString(key);
        }
    }
}