using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Registrar : System.Web.UI.Page
{
    //CADENA DE CONEXION
    SqlConnection cn = new SqlConnection
    (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    void registrar_cliente()
    {




        SqlCommand CMD = new SqlCommand("Execute username_repetido @USERNAME", cn);
        CMD.Parameters.Add("@USERNAME", System.Data.SqlDbType.Char, 13).Value = txtUsuario.Text;

        if (cn.State == 0)
            cn.Open();
        int Resul = (int)CMD.ExecuteScalar();
        if (Resul == 1)
            lblUserRepe.Text = "Usuario Ya Existe";
        else
        {
            lblUserRepe.Text = "";
            CMD.Parameters.Clear();
            CMD.CommandText = "INSERT INTO CLIENTE (NOMBRES,APE_PATER_CLIENTE,APE_MATER_CLIENTE,CORREO_E,TELEFONO_CLI,USERNAME,PASS) VALUES ('" + txtNombre.Text + "','" + txtApe_Pa.Text + "','" + txtApe_Ma.Text + "','" + txtCorreo.Text + "','" + txtTelefono.Text + "','" + txtUsuario.Text + "','" + txtPassword.Text + "')";
            lblUserRepe.Text = "Usuario Registrado Satisfactoriamente";
            CMD.ExecuteNonQuery();
        }
        cn.Close();

        /*
        SqlDataAdapter da = new SqlDataAdapter
        ("username_repetido", cn);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add
        ("@USERNAME", SqlDbType.VarChar).Value = txtUsuario.Text;
        if (cn.State == 0)
            cn.Open();
        int Resul = (int)da.


            da.SelectCommand.Parameters.Add 
            ("@NOMBRES", SqlDbType.VarChar).Value = txtNombre.Text;
          da.SelectCommand.Parameters.Add
         ("@APE_PATER_CLIENTE", SqlDbType.VarChar).Value =txtApe_Pa.Text;
         da.SelectCommand.Parameters.Add
         ("@APE_MATER_CLIENTE", SqlDbType.VarChar).Value = txtApe_Ma.Text;
        da.SelectCommand.Parameters.Add
         ("@CORREO_E", SqlDbType.VarChar).Value = txtCorreo.Text;
        da.SelectCommand.Parameters.Add
         ("@TELEFONO_CLI", SqlDbType.VarChar).Value = txtTelefono.Text;
        da.SelectCommand.Parameters.Add
         ("@USERNAME", SqlDbType.VarChar).Value = txtUsuario.Text;
        da.SelectCommand.Parameters.Add
         ("@PASS", SqlDbType.VarChar).Value = txtPassword.Text;




        DataTable dt = new DataTable();*/

    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        registrar_cliente();
    }
    protected void btnIniciar_Sesion_Click(object sender, EventArgs e)
    {


        Response.Redirect("Login.aspx");
    }
}