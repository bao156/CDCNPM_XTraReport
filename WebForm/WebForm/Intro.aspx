<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Intro.aspx.cs" Inherits="WebForm.Intro" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Automatic Report</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">

    <!-- Favicons -->
    <link href="/Assets/intro/img/title.png" rel="icon">
    <link href="/Assets/intro/img/apple-touch-icon.png" rel="apple-touch-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Roboto:100,300,400,500,700|Philosopher:400,400i,700,700i" rel="stylesheet">

    <!-- Bootstrap css -->
    <!-- <link rel="stylesheet" href="css/bootstrap.css"> -->
    <link href="/Assets/intro/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Libraries CSS Files -->
    <link href="/Assets/intro/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="/Assets/intro/lib/owlcarousel/assets/owl.theme.default.min.css" rel="stylesheet">
    <link href="/Assets/intro/lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="/Assets/intro/lib/animate/animate.min.css" rel="stylesheet">
    <link href="/Assets/intro/lib/modal-video/css/modal-video.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Main Stylesheet File -->
    <link href="/Assets/intro/css/style.css" rel="stylesheet">
</head>

<body>
    <form id="form1" runat="server">
        <header id="header" class="header header-hide">
            <div class="container">

                <div id="logo" class="pull-left">
                    <img src="/Assets/intro/img/logonew.png" alt="" style="width: 210px; height: 200px; margin-top: -50px; margin-left: -100px">
                </div>
            </div>
        </header>
        <!-- #header -->
        <!--==========================
      Hero Section
    ============================-->
        <section id="hero" class="wow fadeIn">
            <div class="hero-container">
                <h1>Welcome to  Automatic Report</h1>
                <h2>Create, Edit,.. With Your Style and More...</h2>
                <img src="/Assets/intro/img/hero-img.png" alt="Hero Imgs">



                <asp:DropDownList ID="cbNameDatabase" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" Style="margin-bottom: 20px; width: 400px; height: 50px; margin-top: 50px; text-align: center; border-radius: 10px; border-color: darkgreen">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Java5ConnectionString %>" SelectCommand="SELECT * FROM [database_name]"></asp:SqlDataSource>

                <asp:LinkButton class="btn-get-started scrollto" ID="btnStart" runat="server" OnClick="btnStart_Click">Get Start</asp:LinkButton>
            </div>
        </section>
        <!-- #hero -->

        <!--==========================
      Footer
    ============================-->
        <footer class="footer">
            <div class="container">
                <div class="row">
                </div>



            </div>


            <div class="copyrights">
                <div class="container">
                    <p>&copy; Copyrights eStartup. All rights reserved.</p>
                    <div class="credits">
                        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
                    </div>
                </div>
            </div>

        </footer>


        <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>

        <!-- JavaScript Libraries -->
        <script src="/Assets/intro/lib/jquery/jquery.min.js"></script>
        <script src="/Assets/intro/lib/jquery/jquery-migrate.min.js"></script>
        <script src="/Assets/intro/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="/Assets/intro/lib/superfish/hoverIntent.js"></script>
        <script src="/Assets/intro/lib/superfish/superfish.min.js"></script>
        <script src="/Assets/intro/lib/easing/easing.min.js"></script>
        <script src="/Assets/intro/lib/modal-video/js/modal-video.js"></script>
        <script src="/Assets/intro/lib/owlcarousel/owl.carousel.min.js"></script>
        <script src="/Assets/intro/lib/wow/wow.min.js"></script>
        <!-- Contact Form JavaScript File -->
        <script src="/Assets/intro/contactform/contactform.js"></script>

        <!-- Template Main Javascript File -->
        <script src="/Assets/intro/js/main.js"></script>
    </form>
</body>
</html>

