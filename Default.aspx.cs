using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdGenerar_Click(object sender, EventArgs e)
    {
        String resp = "<table class='bordered centered'";
        if (txtDesde.Text != "" & txtHasta.Text != "" & txtColumnas.Text != "")
        {
            int desde = int.Parse(txtDesde.Text);
            int hasta = int.Parse(txtHasta.Text);
            int col = int.Parse(txtColumnas.Text);
            if (col > 0)
            {
                if (desde < hasta)
                {
                    resp += "   <tr>";
                    int[] numeros = arregloAleatorio(desde, hasta);
                    int cantidad = hasta - desde + 1;
                    int contador = 0;
                    int numFilas = cantidad / col;
                    if (cantidad % col != 0)
                    {
                        numFilas++;
                    }
                    for (int i = 0; i < numFilas; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            resp += "       <td>";
                            if (contador != cantidad)
                            {
                                resp += "" + numeros[contador];
                                contador++;
                            }
                            resp += "</td>";
                        }
                        resp += "    </tr>";
                        resp += "    <tr>";
                    }
                    resp += "    </tr>";
                }
                else
                {
                    resp += "<tr><td><strong>Desde</strong> debe ser menor que <strong>Hasta</strong></td></tr>";
                }
            }
            else
            {
                resp += "<tr><td>Cantidad de Columnas debe ser mayor a <strong>0</strong></td></tr>";
            }
        }
        else
        {
            resp += "<tr><td>No debe dejar <strong>campos vacios</strong></td></tr>";
        }
        resp += "</table>";
        resultado.InnerHtml = resp;
    }

    protected int[] arregloAleatorio(int desde, int hasta)
    {
        hasta = hasta + 1;
        int cantidad = hasta - desde;
        Random r = new Random((int)DateTime.Now.Ticks);
        int[] arreglo = new int[cantidad];
        int auxiliar = r.Next(desde, hasta);
        arreglo[0] = auxiliar;
        for (int i = 1; i < arreglo.Length; i++)
        {
            while (arreglo.Contains(auxiliar))
            {
                auxiliar = r.Next(desde, hasta);
            }
            arreglo[i] = auxiliar;
        }
        return arreglo;
    }

    protected void limpiar_ServerClick(object sender, EventArgs e)
    {
        resultado.InnerText = "";
    }
}