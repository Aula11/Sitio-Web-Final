<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServicioCopias.aspx.cs" Inherits="ServicioCopias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <%--Prueba--%>
   <%-- <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
    </asp:GridView>--%>

    <form  runat="server"  method="post">

    <asp:Button ID="Logout" runat="server" Text="Cerrar Sesión"   style="position:relative; top: 0px; left: 863px;" OnClick="Logout_Click" CausesValidation="False" />

    <%--SERVICIO DE COPIAS--%>
     <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">COPIAS</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
           <%-- <form role="form">--%>
              <div class="box-body">
                


            <!-- select -->
                <div class="form-group">
                  <label>Tamaño de Hoja: </label><br />
                    <%--<textarea class="form-control" rows="3" placeholder="Acá puede escribir el n"></textarea>--%>
            <asp:DropDownList ID="lstTamHoja" runat="server" ForeColor="Red" AutoPostBack="True">
                <asp:ListItem>A4</asp:ListItem>
                <asp:ListItem>A0</asp:ListItem>
                <asp:ListItem>A1</asp:ListItem>
                <asp:ListItem>A2</asp:ListItem>
                    </asp:DropDownList>
                </div>

                   <div class="form-group">
                  <label>A Color o Blanco/Negro: </label><br />
                    <%--<textarea class="form-control" rows="3" placeholder="Acá puede escribir el n"></textarea>--%>
            <asp:DropDownList ID="lstTipoCopia" runat="server" ForeColor="Red" AutoPostBack="True">
                <asp:ListItem>Blanco/Negro</asp:ListItem>
                <asp:ListItem>Color</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- text input -->
                <div class="form-group" style="position:relative;">
                  <label>Número de Copias</label><br />
                    <asp:TextBox ID="txtNCopia" runat="server"  placeholder="Ejemplo: 20" ForeColor="Red"></asp:TextBox><br />   
                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" style="position:relative;" ErrorMessage="Ingresar Número de Copias" ControlToValidate="txtNCopia" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" runat="server"   ErrorMessage="Ingresar un Número" ControlToValidate="txtNCopia" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    <%-- <input type="file" id="exampleInputFile">--%>
                </div>


         <!-- textarea -->
                <div class="form-group">
                  <label>Información Adicional</label><br />
                    <%--<asp:FileUpload ID="FileUpload1" runat="server" style="position:absolute;text-align: center; top: 434px; left: 378px;"   /> --%>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="multiline" Columns="50" Rows="5" placeholder="Agregue alguna informaciòn adicional a las opciones" ForeColor="Red" Height="50px"></asp:TextBox>

                </div>


                <div class="form-group" >
                  <label for="exampleInputFile">Subir Archivo</label>

                 <%-- <p class="help-block">Example block-level help text here.</p>--%>                 <%--<div class="checkbox">
                  <label>
                    <input type="checkbox"> Check me out
                  </label>
                </div>--%>
                <asp:FileUpload ID="FileUpload1" runat="server" style="position:relative; top: 0px; left: 366px;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="No hay ningún archivo subido" ControlToValidate="FileUpload1" ForeColor="Red"></asp:RequiredFieldValidator>
                    <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
                </div>
                <%--<div class="checkbox">
                  <label>
                    <input type="checkbox"> Check me out
                  </label>
                </div>--%>
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
            
            <asp:Button ID="btnPedido" runat="server" Text="Solicitar Impresión" OnClick="btnPedido_Click" ForeColor="Red" /><br />
                  <asp:Label ID="lblSubida" runat="server" ForeColor="Red"></asp:Label>
              </div>

            <%--</form>--%>
          </div>
          <!-- /.box -->


        </form>


</asp:Content>

