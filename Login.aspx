<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication8.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
         <a href="Default.aspx">
            <span class="glyphicon glyphicon-log-in"></span>
              Register                   
         </a>
    <li>
    <a href="Login.aspx">
            <span class="glyphicon glyphicon-user"></span>
              Login                  
         </a>
     </li>    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container-fluid col-sm-5" style="text-align:center!important;float:none!important;">
    <form id="Form_login" class="login-form" runat="server">
        <asp:ScriptManager ID="scriptmanager1" runat="server">

        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel1">

            <ContentTemplate>

               <asp:Label runat="server" ID="Mess" Visible="false" />
                <p>                                  
                     <div class="form-group row">
                          <label class="col-sm-3 col-form-label">Username:</label>
                          <div class="col-sm-9"> 
                               <asp:TextBox runat="server" ID="Username" class="form-control"  />
                               <asp:RequiredFieldValidator runat="server" ID="req_username" ControlToValidate="Username" ErrorMessage="Please fill your username!" ForeColor="#c83349" />
                          </div>
                     </div>
                    
                     <div class="form-group row"> 
                           <label class="col-sm-3 col-form-label">Password:</label>  
                           <div class="col-sm-9">                            
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control"  />
                                <asp:RequiredFieldValidator runat="server" ID="req_sub" ControlToValidate="Password" ErrorMessage="Please fill the Password!" ForeColor="#c83349" />
                            </div>
                     </div>                                        
                </p>

                <div class="form-group row">
                    <asp:Button runat="server" ID="Login_btn" Text="Login" CssClass="btn btn-lg" OnClick="Login_Click" />
                </div>                                              
            </ContentTemplate>
                
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Login_btn" EventName="Click" />        
            </Triggers>
        </asp:UpdatePanel>
    </form>    
  </div>
</asp:Content>
