<%@ Page Title="Map Reduce Word Counter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapReduceWordCounter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h5>Enter service URLs or use the default service. See About page for service requirements.</h5>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxMap" CssClass="col-md-6 control-label">Map Service URL</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="TextBoxMap" CssClass="form-control" Text="http://localhost:64890/Service1.svc" Width="1000" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxMap"
                            CssClass="text-danger" ErrorMessage="The Map Service URL field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxReduce" CssClass="col-md-6 control-label">Reduce Service URL</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="TextBoxReduce" CssClass="form-control" Text="http://localhost:64897/Service1.svc" Width="1000" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxReduce"
                            CssClass="text-danger" ErrorMessage="The Reduce Service URL field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCombiner" CssClass="col-md-6 control-label">Combine Service URL</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="TextBoxCombiner" CssClass="form-control" Text="http://localhost:64877/Service1.svc" Width="1000" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCombiner"
                            CssClass="text-danger" ErrorMessage="The Combine Service URL field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="threadCount" CssClass="col-md-6 control-label">Parallel Thread Count</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="threadCount" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="threadCount"
                            CssClass="text-danger" ErrorMessage="The Parallel Thread Count field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-6 control-label">File path</asp:Label>
                    <div class="col-md-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="col-md-offset-6 col-md-6">
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
</asp:Content>
