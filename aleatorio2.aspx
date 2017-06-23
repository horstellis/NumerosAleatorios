<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aleatorio2.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="content/materialize/css/materialize.min.css" rel="stylesheet" />
    <title>Generar numeros aleatorios con letra intercalada</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col s12">
                    <h5>Generar Numeros Aleatorios con Letra intercalada</h5>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="txtDesde" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                    <label for="txtDesde">inicio</label>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="txtHasta" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                    <label for="txtHasta">termino</label>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="txtColumnas" runat="server" TextMode="Number"></asp:TextBox>
                    <label for="txtColumnas">cantidad de columnas</label>
                </div>
                <div class="input-field col s6 l3">
                    <asp:TextBox ID="txtLetra" runat="server" MaxLength="1"></asp:TextBox>
                    <label for="txtLetra">letra a intercalar</label>
                </div>
                <div class="input-field col s6 l3">
                    <asp:TextBox ID="txtPosicion" runat="server" TextMode="Number" MaxLength="1" min="1" max="4"></asp:TextBox>
                    <label for="txtPosicion">posición donde intercalar</label>
                </div>
                <div class="input-field col s6 l3">
                    <asp:TextBox ID="txtInferior" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                    <label for="txtInferior">inicio rango a eliminar</label>
                </div>
                <div class="input-field col s6 l3">
                    <asp:TextBox ID="txtSuperior" runat="server" TextMode="Number" min="1" max="999"></asp:TextBox>
                    <label for="txtInferior">fin rango a eliminar</label>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col s12">
                            <asp:Button ID="cmdGenerar" runat="server" Text="Generar" OnClick="cmdGenerar_Click" CssClass="waves-effect waves-light btn yellow darken-4" />
                            <button id="limpiar" type="button" class="waves-effect waves-light btn red darken-3" onclick="$('#resultado').empty();$('#form1')[0].reset();">Limpiar</button>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <div class="col s12">
                            <div id="resultado" runat="server"></div>
                        </div>
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
