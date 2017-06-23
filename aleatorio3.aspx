<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aleatorio3.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="content/materialize/css/materialize.min.css" rel="stylesheet" />
    <title>Generar numeros aleatorios con letra intercalada</title>
</head>
<body class="grey lighten-3rerdf56">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col s12">
                    <h5>Generar Numeros Aleatorios</h5>
                    <p>
                        Permite generar numeros aleatorios en una tabla, indicando la cantidad de columnas y
                        limitando la cantidad máxima de numeros a generar por bloque
                    </p>
                    <p>
                        Puede intercalar una letra entre los digitos, generando grupos desde 1 (minimo) hasta 999 (maximo)
                        generando codigos como 0A01 ó 99Z9
                    </p>
                    <p>Puede eliminar un rango de numeros y separarlos en grupos (no es obligatorio)</p>
                </div>
                <div class="card col s12 light-blue darken-2 white-text">
                    <div class="col s12">
                        <strong>configuración básica</strong>
                    </div>
                    <div class="input-field col s3">
                        <asp:TextBox ID="txtDesde" runat="server" TextMode="Number" min="1"></asp:TextBox>
                        <label for="txtDesde" class="light-blue-text text-lighten-5">inicio</label>
                    </div>
                    <div class="input-field col s3">
                        <asp:TextBox ID="txtHasta" runat="server" TextMode="Number" min="1"></asp:TextBox>
                        <label for="txtHasta" class="light-blue-text text-lighten-5">termino</label>
                    </div>
                    <div class="input-field col s3">
                        <asp:TextBox ID="txtColumnas" runat="server" TextMode="Number"></asp:TextBox>
                        <label for="txtColumnas" class="light-blue-text text-lighten-5">columnas</label>
                    </div>
                    <div class="input-field col s3">
                        <asp:TextBox ID="txtLimite" runat="server" TextMode="Number"></asp:TextBox>
                        <label for="txtLimite" class="light-blue-text text-lighten-5">limite</label>
                    </div>
                </div>
                <div class="card col s12 l5 deep-orange darken-2 white-text">
                    <div class="col s12">
                        <strong>intercalación</strong>
                    </div>
                    <div class="input-field col s6">
                        <asp:TextBox ID="txtLetra" runat="server" MaxLength="1"></asp:TextBox>
                        <label for="txtLetra" class="deep-orange-text text-lighten-2">letra</label>
                    </div>
                    <div class="input-field col s6">
                        <asp:TextBox ID="txtPosicion" runat="server" TextMode="Number" MaxLength="1" min="1" max="4"></asp:TextBox>
                        <label for="txtPosicion" class="deep-orange-text text-lighten-2">posición</label>
                    </div>
                </div>
                <div class="card col s12 l5 offset-l2 green darken-1 white-text">
                    <div class="col s12">
                        <strong>rango a eliminar</strong>
                    </div>
                    <div class="input-field col s6">
                        <asp:TextBox ID="txtInferior" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                        <label for="txtInferior" class="green-text text-lighten-3">inicio</label>
                    </div>
                    <div class="input-field col s6">
                        <asp:TextBox ID="txtSuperior" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                        <label for="txtInferior" class="green-text text-lighten-3">fin</label>
                    </div>
                </div>
                <div class="card col s12 yellow darken-1">
                    <div class="col s12">
                        <strong>separar en grupos por tamaño</strong>
                    </div>
                    <div class="input-field col s12">
                        <asp:TextBox ID="txtGrupos" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <label for="txtGrupos" class="yellow-text text-darken-4">ingresa separados por espacios</label>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card col s12 center teal darken-1">
                            <div class="row" style="margin-top: 20px;">
                                <div class="col s6">
                                    <asp:Button ID="cmdGenerar" runat="server" Text="Generar" OnClick="cmdGenerar_Click" CssClass="waves-effect waves-light btn yellow darken-4" />
                                </div>
                                <div class="col s6">
                                    <button id="limpiar" type="button" class="waves-effect waves-light btn red darken-3" onclick="$('#resultado').empty();$('#form1')[0].reset();">Limpiar</button>
                                </div>
                            </div>
                        </div>
                        <div class="card col s12">
                            <div id="resultado" runat="server"></div>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/materialize/materialize.min.js"></script>
    <script src="Scripts/funciones.js"></script>
</body>
</html>
