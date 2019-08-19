<%@ Page Title="Map Reduce Word Counter" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapReduceWordCounter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="partitionCount" CssClass="col-md-6 control-label">Partition Count</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="partitionCount" CssClass="form-control" />
                        <asp:RegularExpressionValidator runat="server"
                            ControlToValidate="partitionCount" ValidationExpression="^\d*$"
                            ErrorMessage="Please enter whole numbers only (e.g., 5 or 701)." Display="Dynamic" SetFocusOnError="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="partitionCount"
                            CssClass="text-danger" ErrorMessage="Partition count field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-6 control-label">File path</asp:Label>
                    <div class="col-md-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="col-md-offset-6 col-md-6">
                        <br />
                        <asp:Button runat="server" Text="Count" OnClick="UploadButton_Click" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Status" CssClass="col-md-6 control-label">File:</asp:Label>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="Status" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Counted" CssClass="col-md-6 control-label">Words counted:</asp:Label>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="Counted" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="totalWords" CssClass="col-md-6 control-label">Words in file:</asp:Label>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="totalWords" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <h4>File is not stored - uses PostedFile & InputStream to read it.</h4>
    <h4>Uses Task-Based Asynchronous Pattern (i.e. SOAP services & some client methods use async, await, & Task).</h4>
    <h4>Please read About page for more details.</h4>
</asp:Content>
