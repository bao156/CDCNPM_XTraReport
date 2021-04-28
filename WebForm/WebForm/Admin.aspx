<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebForm.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard - Automatic Report</title>

    <link rel="stylesheet" href="/Assets/admin/assets/css/bootstrap.css">

    <link rel="stylesheet" href="/Assets/admin/assets/vendors/chartjs/Chart.min.css">

    <link rel="stylesheet" href="/Assets/admin/assets/vendors/perfect-scrollbar/perfect-scrollbar.css">
    <link rel="stylesheet" href="/Assets/admin/assets/css/app.css">
    <link rel="shortcut icon" href="/Assets/admin/assets/title.png" type="image/x-icon">
</head>
<body>
    <form id="form1" runat="server">
      <div id="app">
        <div id="sidebar" class='active'>
            <div class="sidebar-wrapper active">
                <div class="sidebar-header" >
                    <img src="/Assets/admin/assets/logonew.png" alt="" srcset="" style="width:300px;height:280px;margin-left:-50px" >
                     <select name="cars" id="cars" style="width:200px;margin-left:-20px;height:50px">
                                  <option value="volvo">SQL View</option>
                                  <option value="saab">Datasheet View</option>
                                  <option value="mercedes">Design View</option>
                    </select>
                </div>
                <div class="sidebar-menu">
                    <ul class="menu">
                        <li class='sidebar-title'>All Tables</li>

                    
                    <%
                        var todo_list=getListTable();
                        foreach(var item in todo_list)
                        {
                            Response.Write("<li class=\"sidebar-item active\">"+
                                           " <a href=\"index.html\" class=\'sidebar-link\'>"+
                                           " <i data-feather=\"grid\" width=\"20\" style=\"color:#00804d\"></i>"+
                                           "<span>"+ item+"</span>"+
                                           " </a>"+
                                           "</li>");
                        }
                    %>





<%--                        <li class="sidebar-item active ">
                            <a href="index.html" class='sidebar-link'>
                                <i data-feather="home" width="20" style="color:#00804d"></i>
                                <span>Dashboard</span>
                            </a>
                        </li>--%>



<%--                        <li class='sidebar-title'>Forms &amp; Tables</li>


                        <li class="sidebar-item  ">
                            <a href="form-layout.html" class='sidebar-link'>
                                <i data-feather="layout" width="20" style="color:#00804d"></i>
                                <span>Form Layout</span>
                            </a>

                        </li>




                        <li class="sidebar-item  ">
                            <a href="form-editor.html" class='sidebar-link'>
                                <i data-feather="layers" width="20"style="color:#00804d"></i>
                                <span>Form Editor</span>
                            </a>

                        </li>

                        <li class="sidebar-item  ">
                            <a href="table.html" class='sidebar-link'>
                                <i data-feather="grid" width="20"style="color:#00804d"></i>
                                <span>Table</span>
                            </a>

                        </li>




                        <li class="sidebar-item  ">
                            <a href="table-datatable.html" class='sidebar-link'>
                                <i data-feather="file-plus" width="20"style="color:#00804d"></i>
                                <span>Datatable</span>
                            </a>

                        </li>--%>
                
                </div>
                <button class="sidebar-toggler btn x"><i data-feather="x" ></i></button>
            </div>
        </div>
        <div id="main">
            <nav class="navbar navbar-header navbar-expand navbar-light">
                <a class="sidebar-toggler" href="#"><span class="navbar-toggler-icon"></span></a>
                <button class="btn navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav d-flex align-items-center navbar-light ms-auto">
                    
                        
                  
                    </ul>
                </div>
            </nav>

            <div class="main-content container-fluid">
                <div class="page-title">
                    <h3>Dashboard</h3>
                    <p class="text-subtitle text-muted">A good dashboard to display your statistics</p>
                </div>
                <section class="section">
                 
                </section>
            </div>

            <footer>
                <div class="footer clearfix mb-0 text-muted">
                    
                </div>
            </footer>
        </div>
    </div>
    <script src="/Assets/admin/assets/js/feather-icons/feather.min.js"></script>
    <script src="/Assets/admin/assets/vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script src="/Assets/admin/assets/js/app.js"></script>

    <script src="/Assets/admin/assets/vendors/chartjs/Chart.min.js"></script>
    <script src="/Assets/admin/assets/vendors/apexcharts/apexcharts.min.js"></script>
    <script src="/Assets/admin/assets/js/pages/dashboard.js"></script>

    <script src="/Assets/admin/assets/js/main.js"></script>
    </form>
</body>
</html>
