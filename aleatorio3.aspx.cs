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
        String[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "z" };
        String resp = "<table class='centered' style='margin-top: 10px;'>";
        if (txtDesde.Text != "" & txtHasta.Text != "" & txtColumnas.Text != "" & txtLimite.Text != "" & txtLetra.Text != "" & txtPosicion.Text != "")
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
                        int[] numeros = null;
                        int cantidad = hasta - desde + 1;
                        int limite = int.Parse(txtLimite.Text);
                        String[] grupos = null;
                        if (txtGrupos.Text.Length > 0)
                        {
                            grupos = txtGrupos.Text.Split(' ');
                        }
                        if (txtInferior.Text != "" & txtSuperior.Text != "")
                        {
                            int inferior = int.Parse(txtInferior.Text);
                            int superior = int.Parse(txtSuperior.Text);
                            cantidad = cantidad - (superior - inferior + 1);
                            numeros = arregloAleatorio(desde, hasta, inferior, superior, limite);
                        }
                        else
                        {
                            numeros = arregloAleatorio(desde, hasta, limite);
                        }
                        if (grupos == null)
                        {
                            int contador = 0;
                            int numFilas = cantidad / col;
                            String aux = "";
                            resp += "   <tr>";
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
                            int[] lista = new int[grupos.Length];
                            int cant = 0;
                            int pos = 0;
                            for (int i = 0; i < grupos.Length; i++)
                            {
                                lista[i] = int.Parse(grupos[i]);
                                cant = cant + lista[i];
                            }
                            if (cantidad == cant)
                            {
                                for (int i = 0; i < lista.Length; i++)
                                {
                                    resp += "<td colspan='" + col + "' class='indigo white-text'><strong><i>Grupo N° " + (i + 1) + " - " + lista[i] + " elementos</i></strong></td>";
                                    resp += "</tr>";
                                    resp += "<tr>";
                                    resp += generaTabla(numeros, pos, lista[i], col, letra, posicion);
                                    pos = pos + lista[i];
                                }
                            }
                            else
                            {
                                resp += "<tr><td><strong>Suma total</strong> del tamaño de cada grupo debe ser igual que <strong>cantidad</strong> de números generados</td></tr>";
                            }

                        }
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

    protected int[] arregloAleatorio(int desde, int hasta, int limite)
    {
        Random r = new Random((int)DateTime.Now.Ticks);
        int auxiliar = 0;
        hasta = hasta + 1;
        int cantidad = hasta - desde;
        int[] arreglo = new int[cantidad];
        if (limite >= cantidad)
        {
            auxiliar = r.Next(desde, hasta);
            arreglo[0] = auxiliar;
            for (int i = 1; i < arreglo.Length; i++)
            {
                while (arreglo.Contains(auxiliar))
                {
                    auxiliar = r.Next(desde, hasta);
                }
                arreglo[i] = auxiliar;
            }
        }
        else
        {
            int vueltas = cantidad / limite;
            int n = 0;
            int m = limite;
            if (cantidad % limite > 0)
            {
                vueltas++;
            }
            int inicial = desde;
            int final = limite + 1;
            for (int i = 0; i < vueltas; i++)
            {
                auxiliar = r.Next(inicial, final);
                arreglo[n] = auxiliar;
                n++;
                for (int j = n; j < m; j++)
                {
                    while (arreglo.Contains(auxiliar))
                    {
                        auxiliar = r.Next(inicial, final);
                    }
                    arreglo[j] = auxiliar;
                }
                n--;
                n += limite;
                inicial = final;
                m += limite;
                final += limite;
                if (m > arreglo.Length)
                {
                    m = arreglo.Length;
                    final = hasta;
                }
            }
        }
        return arreglo;
    }

    protected int[] arregloAleatorio(int desde, int hasta, int rme, int rma, int limite)
    {
        Random r = new Random((int)DateTime.Now.Ticks);
        int auxiliar = 0;
        hasta = hasta + 1;
        rma = rma + 1;
        int cantidad = hasta - desde;
        int elim = rma - rme;
        int s = rme;
        int[] arreglo = new int[cantidad];
        int[] eliminar = new int[elim];
        for (int a = 0; a < eliminar.Length; a++)
        {
            eliminar[a] = s;
            s++;
        }
        //Genera aleatorio
        if (limite >= cantidad)
        {
            auxiliar = r.Next(desde, hasta);
            arreglo[0] = auxiliar;
            for (int i = 1; i < arreglo.Length; i++)
            {
                while (arreglo.Contains(auxiliar))
                {
                    auxiliar = r.Next(desde, hasta);
                }
                arreglo[i] = auxiliar;
            }
        }
        else
        {
            int vueltas = cantidad / limite;
            int n = 0;
            int m = limite;
            if (cantidad % limite > 0)
            {
                vueltas++;
            }
            int inicial = desde;
            int final = limite + 1;
            for (int i = 0; i < vueltas; i++)
            {
                auxiliar = r.Next(inicial, final);
                arreglo[n] = auxiliar;
                n++;
                for (int j = n; j < m; j++)
                {
                    while (arreglo.Contains(auxiliar))
                    {
                        auxiliar = r.Next(inicial, final);
                    }
                    arreglo[j] = auxiliar;
                }
                n--;
                n += limite;
                inicial = final;
                m += limite;
                final += limite;
                if (m > arreglo.Length)
                {
                    m = arreglo.Length;
                    final = hasta;
                }
            }
        }
        //Carga aleatorio en lista para eliminar los seleccionados
        var lista = new List<int>(arreglo);
        for (int i = 0; i < eliminar.Length; i++)
        {
            lista.Remove(eliminar[i]);
        }
        arreglo = lista.ToArray();
        return arreglo;
    }

    protected String generaTabla(int[] arreglo, int n, int tamanio, int columna, String letra, int lugar)
    {
        String resp = "";
        String aux = "";
        int contador = 0;
        int numFilas = tamanio / columna;
        int color = 5;
        if (tamanio % columna != 0)
        {
            numFilas++;
        }
        for (int i = 0; i < numFilas; i++)
        {
            if (color < 1)
            {
                color = 5;
            }
            for (int j = 0; j < columna; j++)
            {
                resp += "       <td class='indigo lighten-" + color + "'>";
                if (contador != tamanio)
                {
                    switch (lugar)
                    {
                        case 1:
                            if (arreglo[n] > 9)
                            {
                                if (arreglo[n] > 99)
                                {
                                    resp += letra + arreglo[n];
                                }
                                else
                                {
                                    resp += letra + "0" + arreglo[n];
                                }
                            }
                            else
                            {
                                resp += letra + "00" + arreglo[n];
                            }
                            break;
                        case 2:
                            if (arreglo[n] > 9)
                            {
                                if (arreglo[n] > 99)
                                {
                                    aux = "" + arreglo[n];
                                }
                                else
                                {
                                    aux = "0" + arreglo[n];
                                }
                            }
                            else
                            {
                                aux = "00" + arreglo[n];
                            }
                            resp += aux.Substring(0, 1) + letra + aux.Substring(1);
                            break;
                        case 3:
                            if (arreglo[n] > 9)
                            {
                                if (arreglo[n] > 99)
                                {
                                    aux = "" + arreglo[n];
                                }
                                else
                                {
                                    aux = "0" + arreglo[n];
                                }
                            }
                            else
                            {
                                aux = "00" + arreglo[n];
                            }
                            resp += aux.Substring(0, 2) + letra + aux.Substring(2);
                            break;
                        case 4:
                            if (arreglo[n] > 9)
                            {
                                if (arreglo[n] > 99)
                                {
                                    resp += arreglo[n] + letra;
                                }
                                else
                                {
                                    resp += "0" + arreglo[n] + letra;
                                }
                            }
                            else
                            {
                                resp += "00" + arreglo[n] + letra;
                            }
                            break;
                        default:
                            break;
                    }
                    contador++;
                    n++;
                }
                resp += "</td>";
            }
            resp += "    </tr>";
            resp += "    <tr>";
            color--;
        }
        return resp;
    }

    protected void limpiar_ServerClick(object sender, EventArgs e)
    {
        resultado.InnerText = "";
    }
}