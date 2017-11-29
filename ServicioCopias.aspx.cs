using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class ServicioCopias : System.Web.UI.Page
{

    //CADENA DE CONEXION
    SqlConnection cn = new SqlConnection
    (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    String ID_CLIENTE;
    String ID_PEDIDO;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            Response.Write("Bienvenido: " + Session["usuario"]);

            String USERNAME = Session["usuario"].ToString();
            SqlCommand CMD = new SqlCommand("Select* from cliente where USERNAME='" + USERNAME + "'", cn);
            cn.Open();
            SqlDataReader dr = CMD.ExecuteReader();


            while (dr.Read())
            {
                ID_CLIENTE = dr.GetString(0);
                // lblPrueba.Text = ID_CLIENTE;
            }

            cn.Close();


            /////////////////////////////////

        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */

    }



    protected void btnPedido_Click(object sender, EventArgs e)
    {
         if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
       {

           ////////////////////////////////Inserto Un Pedido de acuerdo al Cliente Ingresado///////////
           string sql = "insert into PEDIDO(ID_CLIENTE) values (@ID_CLIENTE)";

           SqlCommand cmd = new SqlCommand(sql, cn);
           cmd.CommandType = CommandType.Text;
           cmd.Parameters.Add("@ID_CLIENTE", System.Data.SqlDbType.VarChar).Value = ID_CLIENTE;
           cn.Open();
           cmd.ExecuteNonQuery();
           cn.Close();


           SqlCommand CMD2 = new SqlCommand("SELECT TOP 1 ID_PEDIDO FROM PEDIDO ORDER BY ID_PEDIDO DESC", cn);
           cn.Open();
           SqlDataReader dr2 = CMD2.ExecuteReader();


           while (dr2.Read())
           {
               ID_PEDIDO = dr2.GetString(0);
               // lblPedido.Text = ID_PEDIDO;
           }

           cn.Close();




            //////////////////////////////////////////para subir un archivo

//Con la clase HttpPostedFile se obtiene acceso de forma individual a los archivos cargados
HttpPostedFile imgFile = FileUpload1.PostedFile;

//Creamos byteFile que contendrá todo el contenido del archivo
Byte[] byteFile = new Byte[FileUpload1.PostedFile.ContentLength];

//Se lee el contenido del archivo en la variable creada byteFile
imgFile.InputStream.Read(byteFile, 0, FileUpload1.PostedFile.ContentLength); 

//Se crea la sentencia SQL que insertará los datos en la tabla de la BD
String TAMAÑO_HOJA =lstTamHoja. SelectedItem.Text;
String DESCRIPCION=txtDescripcion.Text;
String NRO_COPIAS = txtNCopia.Text;
String TIPO_COPIA = lstTipoCopia.SelectedItem.Text;
String NOMBRE_ARCHIVO = Path.GetFileName(FileUpload1.PostedFile.FileName);
string sql3 = "insert into COPIAS (ID_PEDIDO,TAMAÑO_HOJA ,NRO_COPIAS, TIPO_COPIA ,NOMBRE_ARCHIVO,COPIA_ARCHIVO ,TIPO_ARCHIVO, DESCRIPCION) values (@ID_PEDIDO,@TAMAÑO_HOJA ,@NRO_COPIAS,@TIPO_COPIA,@NOMBRE_ARCHIVO, @COPIA_ARCHIVO,@TIPO_ARCHIVO,@DESCRIPCION)";

//Se crea el recurso de conexión a la BD, la cadena de conexión varia de acuerdo a los parámetros establecidos por su conexión al gestor, usuario, contraseña y método de conexión.
//SqlConnection conn = new SqlConnection(“String de conexión al gestor y a la BD.”);

//Se crea el recurso de Command que permitirá ejecutar la instrucción SQL.
SqlCommand cmd3 = new SqlCommand(sql3, cn);
cmd3.CommandType = CommandType.Text;
cmd3.Parameters.Add("@ID_PEDIDO", System.Data.SqlDbType.VarChar).Value = ID_PEDIDO;
cmd3.Parameters.Add("@TAMAÑO_HOJA ",System.Data.SqlDbType.VarChar).Value=TAMAÑO_HOJA;
cmd3.Parameters.Add("@NRO_COPIAS", System.Data.SqlDbType.VarChar).Value = NRO_COPIAS;
cmd3.Parameters.Add("@TIPO_COPIA", System.Data.SqlDbType.VarChar).Value = TIPO_COPIA;
cmd3.Parameters.Add("@NOMBRE_ARCHIVO", System.Data.SqlDbType.VarChar).Value = NOMBRE_ARCHIVO;
cmd3.Parameters.Add("@COPIA_ARCHIVO", System.Data.SqlDbType.VarBinary).Value = byteFile;
cmd3.Parameters.Add("@TIPO_ARCHIVO", System.Data.SqlDbType.VarChar, 50).Value=FileUpload1.PostedFile.ContentType;
cmd3.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar).Value = DESCRIPCION;
//cmd.Parameters[“@Archivo”].Value = byteFile;
//cmd.Parameters[“@Tipo”].Value = archivoSeleccionado.PostedFile.ContentType;

//se abre la conexión al gestor de BD y se hace la ejecución de la sentencia
cn.Open();
cmd3.ExecuteNonQuery();
cn.Close();


txtDescripcion.Text = "";
txtNCopia.Text = "";
lblSubida.Text = "Pedido Enviado Satisfactoriamente";
}






    }//fin del boton 
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");

    }
}