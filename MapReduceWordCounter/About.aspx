<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MapReduceWordCounter.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Map Reduce Word Counter Description</h3>
    <p>
        A service-oriented web application & the SOAP services that 
        collectively count the number of words in a text file via MapReduce. The user uploads a text file & has the option to input the 
        URLs of other services to perform the tasks or to use the default services. The web application binds to the 
        services dynamically. To ensure that the tasks are performed in parallel, multithreading is implemented: each thread receives
        a partition of the words in the text file & invokes the web services. The web services are configured such that a new instance 
        is created per call. It mimics the Hadoop process by distributing the data & the processing over a network.
    </p>
    <h3>Map Service</h3>
    <p>Input type: string[ ]. Return type: IDictionary&lt;string, int&gt;.</p>
    <h3>Reduce Service</h3>
    <p>Input type: IDictionary&lt;string, int&gt;. Return type: IDictionary&lt;string, int&gt;.</p>
    <h3>Combine Service</h3>
    <p>Input type: IDictionary&lt;string, int&gt;. Return type: int.</p>
</asp:Content>
