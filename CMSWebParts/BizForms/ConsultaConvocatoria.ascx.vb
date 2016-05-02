Imports CMS.PortalControls
Imports System.Linq
Imports System.Data
Imports System.Collections.Generic
Imports CMS.DatabaseHelper
Imports CMS.DataEngine
Imports CMS.SettingsProvider
Imports CMS.GlobalHelper
Imports CMS.SiteProvider

Partial Class CMSWebParts_Consulta_Convocatoria
    Inherits CMSAbstractWebPart
    Private Sub enviomailconfirmacion()
        Dim emailTemplateName As String
        Dim replacements(10, 2) As String
        Dim destinatarios, asunto As String
        Dim envio As New SendEmailUsingTemplateHelper
        destinatarios = ""
        Select Case Me.ddpais.SelectedValue
            Case "Regional"
                destinatarios = "aea.regional@iica.int"
            Case "Bolivia"
                destinatarios = "aea.bolivia@iica.int"
            Case "Colombia"
                destinatarios = "aea.colombia@iica.int"
            Case "Ecuador"
                destinatarios = "aea.ecuador@iica.int"
            Case "Peru"
                destinatarios = "aea.peru@iica.int"
        End Select
        'destinatarios = CMS.CMSHelper.CMSContext.CurrentUser.Email
        destinatarios = destinatarios + ";aea.regional@iica.int;" + Me.txtmail.Text

        emailTemplateName = "ConsultaConvocatoriaEtapaI"
        replacements(0, 0) = "txtapellido"
        replacements(0, 1) = Me.txtapellido.Text
        replacements(1, 0) = "txtasunto"
        replacements(1, 1) = Me.txtasunto.Text
        replacements(2, 0) = "txtmail"
        replacements(2, 1) = Me.txtmail.Text
        replacements(3, 0) = "ddpais"
        replacements(3, 1) = Me.ddpais.SelectedValue
        replacements(4, 0) = "txtconsulta"
        replacements(4, 1) = Me.txtconsulta.Text
        replacements(5, 0) = "institucion"
        replacements(5, 1) = Me.txtinstitucion.Text
        replacements(6, 0) = "cargo"
        replacements(6, 1) = Me.txtcargo.Text
        replacements(7, 0) = "titulo"
        replacements(7, 1) = Me.ddTitulo.SelectedItem.Text
        replacements(8, 0) = "numeral"
        replacements(8, 1) = Me.ddNumeral.SelectedItem.Text
        replacements(9, 0) = "documento"
        replacements(9, 1) = Me.ddDocumento.SelectedItem.Text

        asunto = "Consultas a las Bases Etapa I  -  3era. Convocatoria del Programa AEA Región Andina. [" + Me.txtasunto.Text + "]"
        envio.SendEmailUsingTemplateSubject(emailTemplateName, destinatarios, Me.txtmail.Text, asunto, replacements, "ContactenosAEA")
        GrabarConsulta()
    End Sub
    Protected Sub GrabarConsulta()
        Dim className As String = "customtable.AEAConsultaEtapaI"
        Dim provider As CustomTableItemProvider = New CustomTableItemProvider(CMSContext.CurrentUser)
        Dim consulta As CustomTableItem = New CustomTableItem(className, provider)

        consulta.SetValue("Nombre", Me.txtapellido.Text)
        consulta.SetValue("Email", Me.txtmail.Text)
        consulta.SetValue("Institucion", Me.txtinstitucion.Text)
        consulta.SetValue("Cargo", Me.txtcargo.Text)
        consulta.SetValue("Asunto", Me.txtasunto.Text)
        consulta.SetValue("Pais", Me.ddpais.SelectedValue)
        consulta.SetValue("Documento", Me.ddDocumento.SelectedValue)
        consulta.SetValue("Titulo", Me.ddTitulo.SelectedValue)
        consulta.SetValue("Numeral", Me.ddNumeral.SelectedValue)
        consulta.SetValue("Consulta", Me.txtconsulta.Text)
        consulta.SetValue("Respuesta", "")
        If (consulta.OrderEnabled) Then
            consulta.ItemOrder = provider.GetLastItemOrder(className) + 1
        End If
        consulta.Insert()

    End Sub
    Protected Sub btnenviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnenviar.Click
        enviomailconfirmacion()
        Me.Mensaje("Su mensaje se envio satisfactoriamente")
        Me.Clear()
    End Sub
    Private Sub Clear()
        Me.txtapellido.Text = ""
        Me.txtasunto.Text = ""
        Me.txtconsulta.Text = ""
        Me.txtmail.Text = ""
        Me.txtasunto.Text = ""
        Me.txtcargo.Text = ""
        Me.txtinstitucion.Text = ""
        Me.ddTitulo.SelectedIndex = 0
    End Sub
    Private Sub Mensaje(ByVal cad As String)

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.Panel1.Attributes("style") = "position:absolute; top:50%; left:50%; width:30em; height:em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.Panel1.Visible = True
        Me.Label2.Text = cad
        Me.Button4.Focus()
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('/MFS/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = False

        'Me.Panel1.Attributes("style") = "position:fixed; top:20%; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        '"POSITION: absolute; TOP: " & posArriba & "px; LEFT: " & posDerecha & "px; WIDTH: " & ancho & "px; HEIGHT: " & alto & "px"
        Me.Panel1.Visible = False
    End Sub

    Protected Sub btnborrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnborrar.Click
        Me.Clear()
    End Sub

    Protected Sub ddDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDocumento.SelectedIndexChanged
        ddTitulo.DataBind()
    End Sub

    Protected Sub ddTitulo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddTitulo.SelectedIndexChanged
        ddNumeral.DataBind()
    End Sub
End Class
