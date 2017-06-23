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
        if (txtDesde.Text != "" & txtHasta.Text != "" & txtColumnas.Text != "" & txtLetra.Text != "" & txtPosicion.Text != "")
        {
            int desde = int.Parse(txtDesde.Text);
            int hasta = int.Parse(txtHasta.Text);
            int col = int.Parse(txtColumnas.Text);
            String letra = txtLetra.Text.ToUpper();
            int posicion = int.Parse(txtPosicion.Text);
            if (posicion <= 4 & posicion >= 1)
            {
                if (col > 0)
                {
                    if (desde < hasta)
                    {
                        resp += "   <tr>";
                        int[] numeros = null;
                        int cantidad = hasta - desde + 1;
                        if (txtInferior.Text != "" & txtSuperior.Text != "")
                        {
                            int inferior = int.Parse(txtInferior.Text);
                            int superior = int.Parse(txtSuperior.Text);
                            cantidad = cantidad - (superior - inferior + 1);
                            numeros = arregloAleatorio(desde, hasta, inferior, superior);
                        }
                        else
                        {
                            numeros = arregloAleatorio(desde, hasta);
                        }
                        int contador = 0;
                        int numFilas = cantidad / col;
                        String aux = "";
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
                                    switch (posicion)
                                    {
                                        case 1:
                                            if (numeros[contador] > 9)
                                            {
                                                if (numeros[contador] > 99)
                                                {
                                                    resp += letra + numeros[contador];
                                                }
                                                else
                                                {
                                                    resp += letra + "0" + numeros[contador];
                                                }
                                            }
                                            else
                                            {
                                                resp += letra + "00" + numeros[contador];
                                            }
                                            break;
                                        case 2:
                                            if (numeros[contador] > 9)
                                            {
                                                if (numeros[contador] > 99)
                                                {
                                                    aux = "" + numeros[contador];
                                                }
                                                else
                                                {
                                                    aux = "0" + numeros[contador];
                                                }
                                            }
                                            else
                                            {
                                                aux = "00" + numeros[contador];
                                            }
                                            resp += aux.Substring(0, 1) + letra + aux.Substring(1);
                                            break;
                                        case 3:
                                            if (numeros[contador] > 9)
                                            {
                                                if (numeros[contador] > 99)
                                                {
                                                    aux = "" + numeros[contador];
                                                }
                                                else
                                                {
                                                    aux = "0" + numeros[contador];
                                                }
                                            }
                                            else
                                            {
                                                aux = "00" + numeros[contador];
                                            }
                                            resp += aux.Substring(0, 2) + letra + aux.Substring(2);
                                            break;
                                        case 4:
                                            if (numeros[contador] > 9)
                                            {
                                                if (numeros[contador] > 99)
                                                {
                                                    resp += numeros[contador] + letra;
                                                }
                                                else
                                                {
                                                    resp += "0" + numeros[contador] + letra;
                                                }
                                            }
                                            else
                                            {
                                                resp += "00" + numeros[contador] + letra;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    //resp += "" + numeros[contador];
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
                resp += "<tr><td>Posicion debe estar entre <strong>1</strong> y <strong>4</strong></td></tr>";
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

    protected int[] arregloAleatorio(int desde, int hasta, int rme, int rma)
    {
        hasta = hasta + 1;
        rma = rma + 1; 
        int cantidad = hasta - desde;
        int elim = rma - rme;
        int s = rme;
        Random r = new Random((int)DateTime.Now.Ticks);
        int[] arreglo = new int[cantidad];
        int[] eliminar = new int[elim];
        for (int a = 0; a < eliminar.Length; a++)
        {
            eliminar[a] = s;
            s++;
        }
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
        var lista = new List<int>(arreglo);
        for (int i = 0; i < eliminar.Length; i++)
        {
            lista.Remove(eliminar[i]);
        }
        arreglo = lista.ToArray();
        return arreglo;
    }

    protected void limpiar_ServerClick(object sender, EventArgs e)
    {
        resultado.InnerText = "";
    }
}