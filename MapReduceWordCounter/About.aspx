<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MapReduceWordCounter.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Map Reduce Word Counter Description</h3>
    <p>
        A service-oriented web application & the SOAP services that collectively count the number of words in a
        text file via MapReduce. It uses the Task-Based Asynchronous Pattern. The SOAP services & some 
        client methods use async, await, & Task. The web services are configured such that a new instance 
        is created per call.
    </p>
    <p>  
        Uses PostedFile & InputStream to read the file. The file is not stored. The file contents are 
        partitioned & handled by tasks. It mimics the Hadoop process by distributing the data & the processing 
        over a network.
    </p>
    <h3>Map Service</h3>
    <p>Input type: string[ ].</p>
    <p>Return type: IDictionary&lt;string, int&gt;.</p>
    <h3>Reduce Service</h3>
    <p>Input type: IDictionary&lt;string, int&gt;.</p>
    <p>Return type: IDictionary&lt;string, int&gt;.</p>
    <h3>Combine Service</h3>
    <p>Input type: IDictionary&lt;string, int&gt;.</p>
    <p>Return type: int.</p>
</asp:Content>
