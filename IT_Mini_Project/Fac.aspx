<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fac.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 400px">
    <asp:Label ID="Label1" runat="server" Text="FacultyName"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="MCQ"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"></asp:Button>
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Subjective"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text="Questions"></asp:Label>
        &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="View" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Enter Question"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="&quot;&quot;" ControlToValidate="TextBox2" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label9" runat="server" Text="Enter Marks"></asp:Label>
          &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Required" InitialValue="&quot;&quot;"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label5" runat="server" Text="Enter OptionA"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="&quot;&quot;" ControlToValidate="TextBox4" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label6" runat="server" Text="Enter OptionB"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="&quot;&quot;" ControlToValidate="TextBox5" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label7" runat="server" Text="Enter OptionC"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="Required" InitialValue="&quot;&quot;"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label8" runat="server" Text="Enter OptionD"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" ErrorMessage="Required" InitialValue="&quot;&quot;"></asp:RequiredFieldValidator>
        <br /><br />&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="ADD" />
        <br /><br />
        <asp:Label ID="Label10" runat="server" Text=" "></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
<br />
        </p>

</asp:Content>

