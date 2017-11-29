using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ConsultasPruebas : System.Web.UI.Page
{

    //CADENA DE CONEXION
    SqlConnection cn = new SqlConnection
    (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

    String ID_CLIENTE;
    //String ID_PEDIDO;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
        {
           Response.Redirect("login.aspx");

           // Equals("caracter")
        }
        else
        {
           if (Session["usuario"].ToString().Equals("admin"))
                Response.Redirect("ClientesPedidos.aspx");
        }




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
                cmd1.CommandText = "select * from PEDIDO p inner join impresion i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE='"+ID_CLIENTE+"'";
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
                cmd22.CommandText = "select * from PEDIDO p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE='" + ID_CLIENTE + "'";
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
                cmd33.CommandText = "select * from PEDIDO p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE='" + ID_CLIENTE + "'";
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
        string fileName, contentType, fecha, descripcion, estado_pedido;
      //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
       // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select NOMBRE_ARCHIVO,IMPRESION_ARCHIVO,TIPO_ARCHIVO,FECHA,DESCRIPCION,ESTADO_PEDIDO from pedido p inner join impresion i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE=@ID_CLIENTE";
               // cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
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
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
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
        string fileName, contentType, fecha, descripcion, estado_pedido;
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select NOMBRE_ARCHIVO,PLOTEO_ARCHIVO,TIPO_ARCHIVO,FECHA,DESCRIPCION,ESTADO_PEDIDO from pedido p inner join PLOTEO i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE=@ID_CLIENTE";
                // cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
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
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
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
        string fileName, contentType, fecha, descripcion, estado_pedido;
        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select NOMBRE_ARCHIVO,COPIA_ARCHIVO,TIPO_ARCHIVO,FECHA,DESCRIPCION,ESTADO_PEDIDO from pedido p inner join COPIAS i on p.ID_PEDIDO=i.ID_PEDIDO where ID_CLIENTE=@ID_CLIENTE";
                // cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", ID_CLIENTE);
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
                    estado_pedido = sdr["ESTADO_PEDIDO"].ToString();
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
        ///////////////Para Consultar un dato o muchos-En este caso consulto el usuario que inició sesion;
        //String USERNAME= Session["usuario"].ToString();
        //SqlCommand CMD = new SqlCommand("Select* from cliente where USERNAME='" + USERNAME +"'", cn);
        //cn.Open();
        //SqlDataReader dr =CMD.ExecuteReader();
        
          
        //while (dr.Read())
        //    {
        //         ID_CLIENTE = dr.GetString(0);
        //       // lblPrueba.Text = ID_CLIENTE;
        //    }

        //cn.Close();


        ///////////////////////////////////


        //////////////////////////////////Inserto Un Pedido de acuerdo al Cliente Ingresado///////////
        //string sql = "insert into PEDIDO(ID_CLIENTE) values (@ID_CLIENTE)";
        
        //SqlCommand cmd = new SqlCommand(sql, cn);
        //cmd.CommandType = CommandType.Text;
        //cmd.Parameters.Add("@ID_CLIENTE", System.Data.SqlDbType.VarChar).Value = ID_CLIENTE;
        //cn.Open();
        //cmd.ExecuteNonQuery();
        //cn.Close();

        
        //SqlCommand CMD2 = new SqlCommand("SELECT TOP 1 ID_PEDIDO FROM PEDIDO ORDER BY ID_PEDIDO DESC", cn);
        //cn.Open();
        //SqlDataReader dr2 = CMD2.ExecuteReader();


        //while (dr2.Read())
        //{
        //     ID_PEDIDO = dr2.GetString(0);
        //   // lblPedido.Text = ID_PEDIDO;
        //}

        //cn.Close();


        //////////////////////////////////////////////////////////////

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}