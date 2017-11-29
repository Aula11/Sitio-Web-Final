using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ClientePedidos : System.Web.UI.Page
{

    //CADENA DE CONEXION
    SqlConnection cn = new SqlConnection
    (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);



    protected void Page_Load(object sender, EventArgs e)
    {

        //String USERNAME=Session["usuario"].ToString();

        if (Session["usuario"] == null)
        {
           Response.Redirect("login.aspx");

           // Equals("caracter")
        }
        else
        {
            if(!Session["usuario"].ToString().Equals("admin"))
                {
                    Response.Redirect("login.aspx");

            }
            
        //    Response.Write("Bienvenido: " + Session["usuario"]);

        //    // String USERNAME = Session["usuario"].ToString();
        //    // SqlCommand CMD = new SqlCommand("Select* from cliente where USERNAME='" + USERNAME + "'", cn);
        //    //cn.Open();
        //    //SqlDataReader dr = CMD.ExecuteReader();


        //    //while (dr.Read())
        //    //{
        //    //  ID_CLIENTE = dr.GetString(0);
        //    // lblPrueba.Text = ID_CLIENTE;
        //    //}

        //    //        cn.Close();
        }

        ///////

        
        if (!IsPostBack)
        {
            //if (GridView1==)
            BindGrid();
            BindGrid2();
            BindGrid3();

        }


    }







    private void BindGrid()
    {
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //  using (SqlConnection con = new SqlConnection(cor))
        {
            using (SqlCommand cmd1 = new SqlCommand())
            {
                //cmd1.CommandText = "select * from PEDIDO p inner join impresion i on p.ID_PEDIDO=i.ID_PEDIDO";
                cmd1.CommandText = "select p.ID_PEDIDO,c.ID_CLIENTE, NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,IMPRESION_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join impresion i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE ORDER BY FECHA desc";
               // cmd1.CommandText = "select *from PEDIDO p inner join impresion i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE";
                cmd1.Connection = cn;
                cn.Open();
                GridView1.DataSource = cmd1.ExecuteReader();
                GridView1.DataBind();

                cn.Close();
            }
        }
    }

    private void BindGrid2()
    {
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //  using (SqlConnection con = new SqlConnection(cor))
        {
            using (SqlCommand cmd22 = new SqlCommand())
            {
                cmd22.CommandText = "select p.ID_PEDIDO,c.ID_CLIENTE,NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,PLOTEO_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE ORDER BY FECHA desc";
                //cmd22.CommandText = "select NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,PLOTEO_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA from PEDIDO p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE";
                //cmd22.CommandText = "select * from PEDIDO p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO ";
                cmd22.Connection = cn;
                cn.Open();
                GridView2.DataSource = cmd22.ExecuteReader();
                GridView2.DataBind();
                cn.Close();
            }
        }
    }

    private void BindGrid3()
    {
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //  using (SqlConnection con = new SqlConnection(cor))
        {
            using (SqlCommand cmd33 = new SqlCommand())
            {
                cmd33.CommandText = "select p.ID_PEDIDO,c.ID_CLIENTE,NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,COPIA_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE ORDER BY FECHA desc";
                //cmd33.CommandText = "select NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,PLOTEO_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA from PEDIDO p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE";
                
                //cmd33.CommandText = "select * from PEDIDO p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO ";
                cmd33.Connection = cn;
                cn.Open();
                GridView3.DataSource = cmd33.ExecuteReader();
                GridView3.DataBind();
                cn.Close();
            }
        }
    }

    protected void DownloadFile(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType, fecha, descripcion, nombre_cliente, correo_e, telefono_cli, estado_pedido, id_pedido;
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select p.ID_PEDIDO,c.ID_CLIENTE,NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,IMPRESION_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join IMPRESION i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE";
                // cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                //cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["IMPRESION_ARCHIVO"];
                    contentType = sdr["TIPO_ARCHIVO"].ToString();
                    fileName = sdr["NOMBRE_ARCHIVO"].ToString();
                    fecha = sdr["FECHA"].ToString();
                    descripcion = sdr["DESCRIPCION"].ToString();
                    nombre_cliente = sdr["NOMBRE_CLIENTE"].ToString();
                    correo_e= sdr["CORREO_E"].ToString();
                    telefono_cli= sdr["TELEFONO_CLI"].ToString();
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
                    //id_pedido = sdr["p.ID_PEDIDO"].ToString();
                    
                }
                cn.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }


    protected void DownloadFile2(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType, fecha, descripcion, nombre_cliente, correo_e, telefono_cli, estado_pedido, id_pedido;
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select p.ID_PEDIDO,NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,PLOTEO_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE where c.ID_CLIENTE=@Id ORDER BY FECHA desc";
                 cmd.Parameters.AddWithValue("@Id", id);
              //  cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["PLOTEO_ARCHIVO"];
                    contentType = sdr["TIPO_ARCHIVO"].ToString();
                    fileName = sdr["NOMBRE_ARCHIVO"].ToString();
                    fecha = sdr["FECHA"].ToString();
                    descripcion = sdr["DESCRIPCION"].ToString();
                    nombre_cliente = sdr["NOMBRE_CLIENTE"].ToString();
                    correo_e = sdr["CORREO_E"].ToString();
                    telefono_cli = sdr["TELEFONO_CLI"].ToString();
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
                   // id_pedido = sdr["p.ID_PEDIDO"].ToString();
                }
                cn.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }



    protected void DownloadFile3(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType, fecha, descripcion, nombre_cliente, correo_e, telefono_cli, estado_pedido,id_pedido;
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select p.ID_PEDIDO,NOMBRES+' '+APE_PATER_CLIENTE+' '+APE_MATER_CLIENTE AS NOMBRE_CLIENTE,CORREO_E,TELEFONO_CLI,NOMBRE_ARCHIVO,COPIA_ARCHIVO,TIPO_ARCHIVO,DESCRIPCION,FECHA,ESTADO_PEDIDO from PEDIDO p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO inner join CLIENTE c ON p.ID_CLIENTE=c.ID_CLIENTE where c.ID_CLIENTE=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
               // cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["COPIA_ARCHIVO"];
                    contentType = sdr["TIPO_ARCHIVO"].ToString();
                    fileName = sdr["NOMBRE_ARCHIVO"].ToString();
                    fecha = sdr["FECHA"].ToString();
                    descripcion = sdr["DESCRIPCION"].ToString();
                    nombre_cliente = sdr["NOMBRE_CLIENTE"].ToString();
                    correo_e = sdr["CORREO_E"].ToString();
                    telefono_cli = sdr["TELEFONO_CLI"].ToString();
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
                    //id_pedido = sdr["p.ID_PEDIDO"].ToString();

                }
                cn.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }






    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "update PEDIDO set ESTADO_PEDIDO=@ESTADO_PEDIDO WHERE ID_PEDIDO = @ID_PEDIDO";

        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;
       // cmd.Parameters.Add("@ID_CLIENTE", System.Data.SqlDbType.VarChar).Value = ID_CLIENTE;
        cmd.Parameters.Add("@ESTADO_PEDIDO", System.Data.SqlDbType.VarChar).Value = txtEstado_Pedido.Text; ;
        cmd.Parameters.Add("@ID_PEDIDO", System.Data.SqlDbType.VarChar).Value = txtID_Pedido.Text; ;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Response.Redirect("ClientesPedidos.aspx");

    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}