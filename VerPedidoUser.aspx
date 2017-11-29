<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VerPedidoUser.aspx.cs" Inherits="ConsultasPruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="Form1" runat="server">
    
    <asp:Button ID="Logout" runat="server" Text="Cerrar Sesión"   style="position:relative; top: 0px; left: 842px;" OnClick="Logout_Click" CausesValidation="False" />
        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
         <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td, th
        {
            height: 25px;
            width: 100px;
        }
    </style>
    

        <br />

        
        <div class="box-header with-border" style="text-align: center">
              <h3 class="box-title" style="color: #0000FF;">PEDIDOS DE IMPRESIÓN</h3>
            </div>
        


        <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
        <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" BorderStyle="Ridge" style="text-align: center;  margin:0 auto;"  >
<AlternatingRowStyle BackColor="White" ForeColor="#000000"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="NOMBRE_ARCHIVO" HeaderText="Nombre Archivo" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Descargar" OnClick="DownloadFile"
                            CommandArgument='<%# Eval("ID_CLIENTE") %>'></asp:LinkButton>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="FECHA"  HeaderText="Fecha" />


                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="ESTADO_PEDIDO" HeaderText="Estado" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>


            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White" ></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>

              <EmptyDataTemplate>
      <img src="~/images/nodata.jpg"
              alt="no hay datos que mostrar" />
      <br/><%--<a href="….">Inserte un nuevo dato</a>.--%>
    </EmptyDataTemplate>



        </asp:GridView>


        <div class="box-header with-border" style="text-align: center">
              <h3 class="box-title" style="color: #0000FF;">PEDIDOS DE PLOTEOS</h3>
            </div>

        <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" BorderStyle="Ridge"  style="text-align: center;  margin:0 auto;" >
<AlternatingRowStyle BackColor="White" ForeColor="#000000"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="NOMBRE_ARCHIVO" HeaderText="Nombre Archivo" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Descargar" OnClick="DownloadFile2"
                            CommandArgument='<%# Eval("ID_CLIENTE") %>'></asp:LinkButton>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="FECHA"  HeaderText="Fecha" />

                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="ESTADO_PEDIDO" HeaderText="Estado" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>


            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>

            <EmptyDataTemplate>
      <img src="~/images/nodata.jpg"
              alt="no hay datos que mostrar" />
      <br/><%--<a href="….">Inserte un nuevo dato</a>.--%>
    </EmptyDataTemplate>


        </asp:GridView>


         <div class="box-header with-border" style="text-align: center">
              <h3 class="box-title" style="color: #0000FF;">PEDIDOS DE COPIAS</h3>
            </div>

        <asp:GridView ID="GridView3" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" BorderStyle="Ridge" style="text-align: center;  margin:0 auto;" >
<AlternatingRowStyle BackColor="White" ForeColor="#000000"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="NOMBRE_ARCHIVO" HeaderText="Nombre Archivo" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Descargar" OnClick="DownloadFile3"
                            CommandArgument='<%# Eval("ID_CLIENTE") %>'></asp:LinkButton>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="FECHA"  HeaderText="Fecha" />

                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="ESTADO_PEDIDO" HeaderText="Estado" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White" ></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>

            <EmptyDataTemplate>
      <img src="~/images/nodata.jpg"
              alt="no hay datos que mostrar" />
      <br/><%--<a href="….">Inserte un nuevo dato</a>.--%>
    </EmptyDataTemplate>


        </asp:GridView>

        <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>--%>

    </form>
</asp:Content>

