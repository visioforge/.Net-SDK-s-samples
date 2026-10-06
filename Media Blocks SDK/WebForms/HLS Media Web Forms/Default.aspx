<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HLS_Media_Web_Forms.Default" %>
<%@ Register TagPrefix="vf" Namespace="VisioForge.Core.UI.WebForms" Assembly="VisioForge.Core.UI.WebForms" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>HLS Media Web Forms - Media Blocks SDK .Net</title>
    <style>
        body { font-family: sans-serif; margin: 16px; }
        .row { margin-bottom: 8px; }
        .source { width: 600px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>HLS Media Web Forms - Media Blocks SDK .Net</h1>
        <p>The server encodes a media file, a URL or an RTSP camera to HLS, and the page plays it.</p>
        <p>This demo accepts any file path and is meant for local runs; restrict the sources before exposing it on a network.</p>
        <div class="row">
            <asp:TextBox ID="edSource" runat="server" CssClass="source" placeholder="C:\path\video.mp4, https://.../file.mp4 or rtsp://camera/stream" />
        </div>
        <div class="row">
            <asp:TextBox ID="edLogin" runat="server" placeholder="Login" />
            <asp:TextBox ID="edPassword" runat="server" TextMode="Password" placeholder="Password" />
            <asp:Button ID="btPlay" runat="server" Text="Play" OnClick="btPlay_Click" />
            <asp:Button ID="btStop" runat="server" Text="Stop" OnClick="btStop_Click" />
        </div>
        <vf:HlsPlayer ID="player" runat="server" Width="960px" Height="540px" />
    </form>
</body>
</html>
