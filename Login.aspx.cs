using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{


    //CADENA DE CONEXION
    SqlConnection cn = new SqlConnection
    (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }




    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        

        string usuario = txtUsuario.Text;
        string pass = txtPassword.Text;
        
            cn.Open();
            SqlCommand CMD = new SqlCommand("verifica_usuario", cn);
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = txtUsuario.Text;
            CMD.Parameters.Add("@PASS", SqlDbType.NVarChar).Value = txtPassword.Text;

            int respuesta;
            respuesta = (int)CMD.ExecuteScalar();  //Convert.ToInt32(cmd.ExecuteScalar())


            if (respuesta == 1)
            {
               // Session["usuario"] = (char)respuesta;
                Session["usuario"] = usuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                //Response.Write("No se encontro usuario");
                lblError.Text = "Usuario o";
                lblError2.Text = "Contraseña";
                lblError3.Text = "Incorrectos";
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Hola mundo');</script>");﻿
                // Response.Write("<script>alert('Your text');</script>");
                // Response.Write("<script>alert('alert box')</script>");﻿
            }

            cn.Close();

        
       




    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrar.aspx");
    }
}
