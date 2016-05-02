Imports CMS.PortalControls
Partial Class CMSWebParts_MFS_AEAAdminConsulta
    Inherits CMSAbstractWebPart
    Protected Friend cnx As MFSDataContext = New MFSDataContext
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        'Me.Page.MaintainScrollPositionOnPostBack = False
        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('~/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.pnlconsulta.Attributes("style") = "position:fixed; top:25%; left:25%; width:600px; height:500px; margin-top: 0px; margin-left: 0px; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.pnlconsulta.Visible = True
        'Mensaje("ok")
    End Sub
    Private Sub Mensaje(ByVal cad As String)
        Me.Page.MaintainScrollPositionOnPostBack = False
        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('~/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.Panel2.Attributes("style") = "position:fixed; top:10%; left:25%; width:520px; height:70px; margin-top: 0px; margin-left: 0px; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.Panel2.Visible = True
        Me.Label2.Text = cad
        Me.Button4.Focus()
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.fondo.Visible = False
        Me.Panel2.Visible = False

    End Sub
    Private Sub GetConsultaFromForm(ByRef aeacon As AEA_CONSULTA)
        aeacon.userid = CMS.CMSHelper.CMSContext.CurrentUser.UserID
        aeacon.IdConvocatoria = Me.IdConvocatoria.SelectedValue
        aeacon.Desconvocatoria = Me.IdConvocatoria.SelectedItem.Text
        aeacon.AmbitoPais = Me.AmbitoPais0.SelectedValue
        aeacon.pais = Me.AmbitoPais0.SelectedItem.Text
        aeacon.antecedente = Me.antecedente.Text
        aeacon.referenciabases = Me.referenciabases.Text
        aeacon.consulta = Me.consulta.Text
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim aeacon As AEA_CONSULTA = New AEA_CONSULTA
        GetConsultaFromForm(aeacon)
        aeacon.idestado = 1 'enviado sin responder
        cnx.AEA_CONSULTA.InsertOnSubmit(aeacon)
        cnx.SubmitChanges()
        'envio de mail
        Dim emailTemplateName As String
        Dim replacements(6, 2) As String
        Dim destinatarios As String
        Dim fromemail As String
        Dim envio As New SendEmailUsingTemplateHelper

        destinatarios = "" 'tmpproy.EmailCoord & ";" & CMS.CMSHelper.CMSContext.CurrentUser.Email
        Select Case aeacon.pais
            Case "PERU"
                destinatarios = "aea.peru@iica.int"
            Case "COLOMBIA"
                destinatarios = "aea.colombia@iica.int"
            Case "ECUADOR"
                destinatarios = "aea.ecuador@iica.int"
            Case "BOLIVIA"
                destinatarios = "aea.bolivia@iica.int"
        End Select

        fromemail = CMS.CMSHelper.CMSContext.CurrentUser.Email
        'destinatarios = CMS.CMSHelper.CMSContext.CurrentUser.Email

        emailTemplateName = "ConsultaConvocatoria"

        replacements(0, 0) = "Consultante"
        replacements(0, 1) = CMS.CMSHelper.CMSContext.CurrentUser.FirstName & " " & CMS.CMSHelper.CMSContext.CurrentUser.LastName
        replacements(1, 0) = "Convocatoria"
        replacements(1, 1) = aeacon.Desconvocatoria
        replacements(2, 0) = "paispostulacion"
        replacements(2, 1) = aeacon.pais
        replacements(3, 0) = "refernciabases"
        replacements(3, 1) = aeacon.referenciabases
        replacements(4, 0) = "antecedentes"
        replacements(4, 1) = aeacon.antecedente
        replacements(5, 0) = "Consulta"
        replacements(5, 1) = aeacon.consulta
       
        envio.SendEmailUsingTemplate(emailTemplateName, destinatarios, fromemail, replacements, "CierrePresentacionPerfil")

        '
        Me.GridView3.DataBind()
        Me.fondo.Visible = False
        Me.pnlconsulta.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.fondo.Visible = False
        Me.pnlconsulta.Visible = False
    End Sub
    Private Sub enviomailconfirmacion()
       
    End Sub
End Class
