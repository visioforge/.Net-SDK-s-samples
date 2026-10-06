<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HLS_Webcam_Web_Forms.Default" %>
<%@ Register TagPrefix="vf" Namespace="VisioForge.Core.UI.WebForms" Assembly="VisioForge.Core.UI.WebForms" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>HLS Webcam Web Forms - Media Blocks SDK .Net</title>
    <style>
        body { font-family: sans-serif; margin: 16px; }
        .row { margin-bottom: 8px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>HLS Webcam Web Forms - Media Blocks SDK .Net</h1>
        <p>The server captures a camera and a microphone, encodes them to HLS, and the page plays the stream.</p>
        <div class="row">
            Video: <asp:DropDownList ID="cbVideo" runat="server" />
            Audio: <asp:DropDownList ID="cbAudio" runat="server">
                <asp:ListItem Text="(no audio)" Value="" />
            </asp:DropDownList>
            <asp:Button ID="btStart" runat="server" Text="Start" OnClick="btStart_Click" />
            <asp:Button ID="btStop" runat="server" Text="Stop" OnClick="btStop_Click" />
        </div>
        <vf:HlsPlayer ID="player" runat="server" Width="960px" Height="540px" />
    </form>
</body>
</html>
