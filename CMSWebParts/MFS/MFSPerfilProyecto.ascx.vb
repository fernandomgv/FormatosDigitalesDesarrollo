﻿Imports CMS.PortalControls
Imports System.Linq
Imports System.Data
Imports System.Collections.Generic
Partial Class CMSWebParts_MFS_MFSPerfilProyecto
    Inherits CMSAbstractWebPart
    Private cnx As MFSDataContext = New MFSDataContext
    Private TempUbicacion As List(Of MFSProyUbicacion) = New List(Of MFSProyUbicacion)
    Private estadoproyecto As Integer
    Private Sub GetinfoProyecto()
        Dim cnx1 As MFSDataContext = New MFSDataContext
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer
        If Session("idproyecto") IsNot Nothing Then
            idproyecto = Integer.Parse(Session("idproyecto").ToString)
            tmpproy = (From t_prp In cnx1.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
            Me.estadoproyecto = tmpproy.EstadoProyecto
            Me.IdProyecto.Text = tmpproy.CodProyecto
            Me.convocatoria.Text = tmpproy.MFSConvocatoria.DesConvocatoria
            If tmpproy.PostulacionAsociada = 1 Then
                Me.PostulacionAsociada.Checked = True
                Me.PostulacionAsociada.Visible = True
            Else
                Me.PostulacionAsociada.Checked = False
                Me.PostulacionAsociada.Visible = False

            End If
            Me.NombreProyecto.Text = tmpproy.NombreProyecto
            TempUbicacion = tmpproy.MFSProyUbicacion.ToList
            For Each tmp As MFSProyUbicacion In TempUbicacion
                tmp.Region = tmp.PER_REGION.Region
                tmp.Pais = tmp.PER_REGION.PER_PAIS.Pais

            Next
            Me.GridView2.DataSource = TempUbicacion
            Me.GridView2.DataBind()
            UpdateTabFromEstado(tmpproy.EstadoProyecto)
        Else
            'mandar mensaje de error
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetinfoProyecto()
        If Me.estadoproyecto > 2 Then
            Me.TabPanel2.Enabled = True
            Me.TabPanel1.Enabled = False
            Me.TabContainer1.ActiveTabIndex = 1
        Else
            Me.TabPanel2.Enabled = False
            Me.TabPanel1.Enabled = True
            Me.TabContainer1.ActiveTabIndex = 0
        End If


        GridView2.DataBind()
        GridView3.DataBind()
    End Sub


    Protected Sub btnpnlproy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpnlproy.Click
        If Me.pnlproy.Visible Then
            Me.btnpnlproy.Text = "[+]Mostrar Informacion del Proyecto"
            Me.pnlproy.Visible = False
        Else
            Me.btnpnlproy.Text = "[-] Ocultar informacion del Proyecto"
            Me.pnlproy.Visible = True
        End If
    End Sub
    Private Function ValidaFechaHoraConvocatoria(Optional ByVal opc As Integer = 0) As Boolean
        Dim isvalid As Boolean = False
        Dim cierre As New DateTime
        Dim actualserver As New DateTime
        Dim tmpconvocatoria As MFSConvocatoria
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer

        idproyecto = Integer.Parse(Session("idproyecto").ToString)
        tmpproy = (From t_prp In cnx.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
        tmpconvocatoria = (From t_c In Me.cnx.MFSConvocatoria Where t_c.IdConvocatoria = tmpproy.IdConvocatoria Select t_c).Single()

        cierre = tmpconvocatoria.FechaFin
        If opc = 1 Then
            cierre = tmpconvocatoria.FechaFin1
        End If
        actualserver = cnx.GETfechahora
        If cierre > actualserver Then
            isvalid = True
        End If
        Return isvalid
    End Function

    Protected Sub btnAdjuntar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjuntar.Click

        'If FileUpload1.FileName <> "" Then
        '    FileUpload1.SaveAs(Server.MapPath("../CMSWebParts/EncuestaLAB/Organigramas") & "/" & FileUpload1.FileName)
        '    encuesta.ruta_file = FileUpload1.FileName
        'End If
        If ValidaFechaHoraConvocatoria() Then
            Dim hfc As HttpFileCollection
            hfc = Request.Files
            If FUperfil.HasFile Then
                Dim fileSize As Integer = FUperfil.PostedFile.ContentLength
                If fileSize < (3 * 1024 * 1024) Then
                    Dim rutadearchivo As String = ""
                    Dim rand As New Random
                    rutadearchivo = Me.IdProyecto.Text.Trim & "Perfil_" & Date.Now.Day.ToString + Date.Now.Month.ToString + Date.Now.Year.ToString + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Date.Now.Second.ToString + Date.Now.Millisecond.ToString + rand.Next(0, 10).ToString
                    rutadearchivo = Server.MapPath("../CMSWebParts/MFS/11_11_11") & "/" & rutadearchivo & System.IO.Path.GetExtension(FUperfil.FileName)
                    'generar registro de archivo subido
                    Dim tmfileup As New MFSFileProyecto
                    tmfileup.IdProyecto = Integer.Parse(Session("IdProyecto").ToString)
                    tmfileup.IdTipo = 1 ' documento de perfil
                    tmfileup.IdWorkFlow = 1 'presentacion perfil 
                    tmfileup.nombrefile = rutadearchivo
                    tmfileup.TituloFile = FUperfil.FileName
                    tmfileup.extfile = System.IO.Path.GetExtension(FUperfil.FileName)
                    tmfileup.fecupload = Date.Now
                    tmfileup.ipupload = HTTPHelper.GetUserHostAddress()
                    tmfileup.versionfile = 1
                    FUperfil.SaveAs(rutadearchivo)
                    cnx.DelFileProyecto(tmfileup.IdProyecto, tmfileup.IdWorkFlow, tmfileup.IdTipo)
                    cnx.SubmitChanges()
                    cnx.MFSFileProyecto.InsertOnSubmit(tmfileup)
                    cnx.SubmitChanges()
                    GridView1.DataBind()
                    Me.Mensaje("Su archivo se adjuntó correctamente")
                Else
                    Me.lblperfilerror.Text = "El tamaño máximo permitido es de 3 MB"
                    Me.lblperfilerror.Visible = True
                End If
            End If
        Else
            Me.Mensaje("La Convocatoria ha finalizado, no es posible adjuntar su Perfil")
        End If
        
    End Sub
    Private Function tofechahora(ByVal fechahora As DateTime) As String
        Dim cad As String = ""
        Select Case fechahora.Month
            Case 1
                cad = "Enero"
            Case 2
                cad = "Febrero"
            Case 3
                cad = "Marzo"
            Case 4
                cad = "Abril"
            Case 5
                cad = "Mayo"
            Case 6
                cad = "Junio"
            Case 7
                cad = "Julio"
            Case 8
                cad = "Agosto"
            Case 9
                cad = "Septiembre"
            Case 10
                cad = "Octubre"
            Case 11
                cad = "Noviembre"
            Case 12
                cad = "Diciembre"
        End Select
        cad = fechahora.Day.ToString & " de " & cad & " de " & fechahora.Year.ToString & " " & fechahora.ToLongTimeString

        Return cad
    End Function
    Private Sub enviomailconfirmacion()
        Dim emailTemplateName As String
        Dim replacements(9, 2) As String
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer
        Dim destinatarios As String
        Dim envio As New SendEmailUsingTemplateHelper

       
        Dim pais As PER_PAIS
        Dim archivo As MFSFileProyecto
        Dim cierre As MFSCierreWorkFlow
        If Session("idproyecto") IsNot Nothing Then
            idproyecto = Integer.Parse(Session("idproyecto").ToString)
            tmpproy = (From t_prp In cnx.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
            pais = (From t_p In cnx.PER_PAIS Where t_p.CodPais = tmpproy.AmbitoPais Select t_p).Single()
            archivo = (From t_prp In cnx.MFSFileProyecto Where t_prp.IdProyecto = idproyecto And t_prp.IdTipo = 1 And t_prp.IdWorkFlow = 1 Select t_prp).Single()
            cierre = (From t_prp In cnx.MFSCierreWorkFlow Where t_prp.IdProyecto = idproyecto And t_prp.IdWorkFlow = 1 Select t_prp).Single()

        End If


        destinatarios = tmpproy.EmailCoord & ";" & CMS.CMSHelper.CMSContext.CurrentUser.Email
        'destinatarios = CMS.CMSHelper.CMSContext.CurrentUser.Email

        emailTemplateName = "CierrePresentacionPerfil"
        replacements(0, 0) = "destinatario"
        replacements(0, 1) = tmpproy.AppCoord & ", " & tmpproy.NomCoord
        replacements(1, 0) = "cargo"
        replacements(1, 1) = tmpproy.CargoCoord
        replacements(2, 0) = "entidad"
        replacements(2, 1) = tmpproy.MFS_AEA_Proponente.nombre_entidad
        replacements(3, 0) = "codigoproyecto"
        replacements(3, 1) = tmpproy.CodProyecto
        replacements(4, 0) = "Convocatoria"
        replacements(4, 1) = tmpproy.MFSConvocatoria.DesConvocatoria
        replacements(5, 0) = "nombreproyecto"
        replacements(5, 1) = tmpproy.NombreProyecto
        replacements(6, 0) = "paispostulacion"
        replacements(6, 1) = pais.Pais
        replacements(7, 0) = "archivoperfil"
        replacements(7, 1) = archivo.TituloFile
        replacements(8, 0) = "fechahora"
        replacements(8, 1) = tofechahora(cierre.fechacierre)

        envio.SendEmailUsingTemplate(emailTemplateName, destinatarios, replacements, "CierrePresentacionPerfil")

    End Sub
    Private Sub enviomailconfirmacionPropuesta()
        Dim emailTemplateName As String
        Dim replacements(9, 2) As String
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer
        Dim destinatarios As String
        Dim envio As New SendEmailUsingTemplateHelper

        Dim pais As PER_PAIS
        Dim archivo As MFSFileProyecto
        Dim cierre As MFSCierreWorkFlow
        If Session("idproyecto") IsNot Nothing Then
            idproyecto = Integer.Parse(Session("idproyecto").ToString)
            tmpproy = (From t_prp In cnx.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
            pais = (From t_p In cnx.PER_PAIS Where t_p.CodPais = tmpproy.AmbitoPais Select t_p).Single()
            archivo = (From t_prp In cnx.MFSFileProyecto Where t_prp.IdProyecto = idproyecto And t_prp.IdTipo = 2 And t_prp.IdWorkFlow = 2 Select t_prp).Single()
            cierre = (From t_prp In cnx.MFSCierreWorkFlow Where t_prp.IdProyecto = idproyecto And t_prp.IdWorkFlow = 2 Select t_prp).Single()

        End If


        destinatarios = tmpproy.EmailCoord & ";" & CMS.CMSHelper.CMSContext.CurrentUser.Email
        'destinatarios = CMS.CMSHelper.CMSContext.CurrentUser.Email

        emailTemplateName = "CierrePresentacionPropuesta"
        replacements(0, 0) = "destinatario"
        replacements(0, 1) = tmpproy.AppCoord & ", " & tmpproy.NomCoord
        replacements(1, 0) = "cargo"
        replacements(1, 1) = tmpproy.CargoCoord
        replacements(2, 0) = "entidad"
        replacements(2, 1) = tmpproy.MFS_AEA_Proponente.nombre_entidad
        replacements(3, 0) = "codigoproyecto"
        replacements(3, 1) = tmpproy.CodProyecto
        replacements(4, 0) = "Convocatoria"
        replacements(4, 1) = tmpproy.MFSConvocatoria.DesConvocatoria
        replacements(5, 0) = "nombreproyecto"
        replacements(5, 1) = tmpproy.NombreProyecto
        replacements(6, 0) = "paispostulacion"
        replacements(6, 1) = pais.Pais
        replacements(7, 0) = "archivoperfil"
        replacements(7, 1) = archivo.TituloFile
        replacements(8, 0) = "fechahora"
        replacements(8, 1) = tofechahora(cierre.fechacierre)

        envio.SendEmailUsingTemplate(emailTemplateName, destinatarios, replacements, "CierrePresentacionPropuesta")

    End Sub
    Private Sub UpdateEstadoProyecto(ByVal estado As Integer)
        Dim cnx1 As MFSDataContext = New MFSDataContext
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer
        If Session("idproyecto") IsNot Nothing Then
            idproyecto = Integer.Parse(Session("idproyecto").ToString)
            tmpproy = (From t_prp In cnx1.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
            tmpproy.EstadoProyecto = estado
            cnx1.SubmitChanges()
        End If
    End Sub
    Private Sub UpdateTabFromEstado(ByVal estado As Integer)
        Select Case estado
            Case 2
                Me.btnAdjuntar1.Enabled = False
                Me.BtnCerrarPerfil.Enabled = False
                Me.FUperfil.Enabled = False
            Case 4
                Me.Button5.Enabled = False
                Me.Button2.Enabled = False
                Me.Button6.Enabled = False
                Me.Button7.Enabled = False
                Me.Button8.Enabled = False
        End Select
    End Sub
    Private Sub saveconfirmacion(ByVal idworkflow As Integer)
        Dim tmpconfirmacion As New MFSCierreWorkFlow
        tmpconfirmacion.IdProyecto = Integer.Parse(Session("IdProyecto"))
        tmpconfirmacion.IdWorkFlow = idworkflow
        tmpconfirmacion.estado = 1
        tmpconfirmacion.fechacierre = DateTime.Now
        cnx.MFSCierreWorkFlow.InsertOnSubmit(tmpconfirmacion)
        cnx.SubmitChanges()
    End Sub
    Protected Sub BtnCerrarPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCerrarPerfil.Click
        If ValidaFechaHoraConvocatoria() Then
            ' Response.Redirect("/mfs/CMSWebParts/MFS/PerfilCloseConfirmation.aspx")
            'valida carga de archivo
            If Me.GridView1.Rows.Count > 0 Then
                saveconfirmacion(1)
                enviomailconfirmacion()

                Dim _URL As String

                Dim JavaScript As String

                _URL = "../CMSWebParts/MFS/PerfilCloseConfirmation.aspx"

                JavaScript = "window.open('" + _URL + "', null, 'resizable=yes, left=0, top=0, status=yes,toolbar=no,menubar=no,location=no')"

                Response.Write("<SCRIPT LANGUAGE=javascript>" & vbCrLf)

                Response.Write("<!--" & vbCrLf)

                Response.Write(JavaScript & vbCrLf)

                Response.Write("//-->" & vbCrLf)

                Response.Write("</SCRIPT>" & vbCrLf)

                'actualizar estado de proyecto
                UpdateEstadoProyecto(2)
                UpdateTabFromEstado(2)
            Else
                Me.Mensaje("Debe realizar previamente los pasos 1 y 2.")
            End If
        Else
            Me.Mensaje("La Convocatoria ha finalizado, no es posible realizar la Postulacion")
        End If
    End Sub

    Private Sub Mensaje(ByVal cad As String)

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('../App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.Panel1.Attributes("style") = "position:fixed; top:50%; left:50%; width:30em; height:7em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.Panel1.Visible = True
        Me.Label2.Text = cad
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('/MFS/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = False

        'Me.Panel1.Attributes("style") = "position:fixed; top:20%; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        '"POSITION: absolute; TOP: " & posArriba & "px; LEFT: " & posDerecha & "px; WIDTH: " & ancho & "px; HEIGHT: " & alto & "px"
        Me.Panel1.Visible = False
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow

                Dim btndescarga As HyperLink = CType(e.Row.Cells(9).Controls(0), HyperLink)

                Dim ruta As String
                ruta = System.IO.Path.GetFileName(CType(e.Row.DataItem, DataRowView).Item(7).ToString)
                ruta = "~/CMSWebParts/MFS/11_11_11" & "/" & ruta

                btndescarga.NavigateUrl = ruta
                btndescarga.Target = "_blank"
                '"../CMSWebParts/MFS/11_11_11") & "/" & rutadearchivo & System.IO.Path.GetExtension(FUperfil.FileName)
                btndescarga.ToolTip = "Comprueba que su archivo adjuntad es el correcto descargandolo AQUI"

        End Select
    End Sub


    Protected Sub btnAdjuntar0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjuntar0.Click

        Dim hfc As HttpFileCollection
        hfc = Request.Files
        If FileUpload1.HasFile Then
            Dim fileSize As Integer = FileUpload1.PostedFile.ContentLength
            If fileSize < (3 * 1024 * 1024) Then
                Dim rutadearchivo As String = ""
                Dim rand As New Random
                rutadearchivo = Me.IdProyecto.Text.Trim & "Perfil_" & Date.Now.Day.ToString + Date.Now.Month.ToString + Date.Now.Year.ToString + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Date.Now.Second.ToString + Date.Now.Millisecond.ToString + rand.Next(0, 10).ToString
                rutadearchivo = Server.MapPath("../CMSWebParts/MFS/11_11_11") & "/" & rutadearchivo
                rutadearchivo = rutadearchivo & System.IO.Path.GetExtension(FileUpload1.FileName)
                'generar registro de archivo subido
                Dim tmfileup As New MFSFileProyecto
                tmfileup.IdProyecto = Integer.Parse(Session("IdProyecto").ToString)
                tmfileup.IdTipo = 1 ' documento de perfil
                tmfileup.IdWorkFlow = 1 'presentacion perfil 
                tmfileup.nombrefile = rutadearchivo
                tmfileup.TituloFile = FileUpload1.FileName
                tmfileup.extfile = System.IO.Path.GetExtension(FileUpload1.FileName)
                tmfileup.fecupload = Date.Now
                tmfileup.ipupload = HTTPHelper.GetUserHostAddress()
                tmfileup.versionfile = 1
                FileUpload1.SaveAs(rutadearchivo)
                cnx.DelFileProyecto(tmfileup.IdProyecto, tmfileup.IdWorkFlow, tmfileup.IdTipo)
                cnx.SubmitChanges()
                cnx.MFSFileProyecto.InsertOnSubmit(tmfileup)
                cnx.SubmitChanges()
                GridView1.DataBind()
                Me.Mensaje("Su archivo se adjunto correctamente")
                'Me.fondo.Visible = False
                Me.Panel2.Visible = False
            Else
                Me.Label1.Text = "El tamaño máximo permitido es de 3 MB"
                Me.Label1.Visible = True
            End If
        End If
        
    End Sub

    Protected Sub btnAdjuntar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjuntar1.Click
        If ValidaFechaHoraConvocatoria() Then
            Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('../App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
            Me.fondo.Visible = True
            Me.Panel2.Attributes("style") = "position:fixed; top:50%; left:50%; width:35em; height:19em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
            Me.Panel2.Visible = True
            '======================
        Else
            Me.Mensaje("La Convocatoria ha finalizado, no es posible adjuntar su Perfil")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.fondo.Visible = False
        Me.Panel2.Visible = False
    End Sub

    Private Function verifyFile(ByVal opc As Integer, ByRef fu1 As FileUpload) As Boolean
        Dim extfile As String

        ' verificacion de extenciones
        Dim hfc As HttpFileCollection
        hfc = Request.Files
        If fu1.HasFile Then
            Dim fileSize As Integer = fu1.PostedFile.ContentLength
            If fileSize < (3 * 1024 * 1024) Then
                extfile = System.IO.Path.GetExtension(fu1.FileName)
                If opc = 2 Then
                    If extfile.ToLower = ".xls" Or extfile.ToLower = ".xlsx" Or extfile.ToLower = ".doc" Or extfile.ToLower = ".docx" Or extfile.ToLower = ".pdf" Then
                        Me.Label3.Visible = False
                        Return True
                    Else
                        Me.Label3.Text = "Las extension de archivo permitidas son: XLS, XLSX, DOC, DOCX, PDF"
                        Me.Label3.Visible = True
                        Return False
                    End If
                Else
                    If extfile.ToLower = ".xls" Or extfile.ToLower = ".xlsx" Or extfile.ToLower = ".doc" Or extfile.ToLower = ".docx" Or extfile.ToLower = ".pdf" Then
                        Me.Label3.Visible = False
                        Return True
                    Else
                        Me.Label3.Text = "Las extension de archivo permitidas son: XLS, XLSX, DOC, DOCX, PDF"
                        Me.Label3.Visible = True
                        Return False
                    End If
                End If
            Else
                Me.Label3.Text = "El tamaño maximo de archivo permitido es de 3 MB"
                Me.Label3.Visible = True
                Return False

            End If

        End If
    End Function

    Private Sub savefile(ByVal opc As Integer)
        If verifyFile(opc, Me.FileUpload2) Then
            Dim hfc As HttpFileCollection
            Dim prefijo As String
            hfc = Request.Files
            If FileUpload2.HasFile Then
                Dim fileSize As Integer = FileUpload2.PostedFile.ContentLength
                Dim rutadearchivo As String = ""
                Dim rand As New Random
                If opc = 2 Then

                    prefijo = "_Propuesta_"
                Else
                    prefijo = "_Complemento" + opc.ToString + "_"

                End If

                rutadearchivo = Me.IdProyecto.Text.Trim & prefijo & Date.Now.Day.ToString + Date.Now.Month.ToString + Date.Now.Year.ToString + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Date.Now.Second.ToString + Date.Now.Millisecond.ToString + rand.Next(0, 10).ToString

                rutadearchivo = Server.MapPath("../CMSWebParts/MFS/11_11_11") & "/" & rutadearchivo & System.IO.Path.GetExtension(FileUpload2.FileName)

                'generar registro de archivo subido
                Dim tmfileup As New MFSFileProyecto
                tmfileup.extfile = System.IO.Path.GetExtension(FileUpload2.FileName)
                tmfileup.IdProyecto = Integer.Parse(Session("IdProyecto").ToString)
                tmfileup.IdTipo = opc ' documento de perfil
                tmfileup.IdWorkFlow = 2 'presentacion perfil 
                tmfileup.nombrefile = rutadearchivo
                tmfileup.TituloFile = FileUpload2.FileName
                tmfileup.fecupload = Date.Now
                tmfileup.ipupload = HTTPHelper.GetUserHostAddress()
                tmfileup.versionfile = 1
                FileUpload2.SaveAs(rutadearchivo)
                cnx.DelFileProyecto(tmfileup.IdProyecto, tmfileup.IdWorkFlow, tmfileup.IdTipo)
                cnx.SubmitChanges()
                cnx.MFSFileProyecto.InsertOnSubmit(tmfileup)
                cnx.SubmitChanges()
                GridView1.DataBind()
                Me.Mensaje("Su archivo se adjunto correctamente")
                'Me.fondo.Visible = False
                Me.pnlPropuesta.Visible = False
                Me.Label3.Visible = False
                GridView3.DataBind()
            
            End If
        End If
    End Sub

    Protected Sub btnAdjuntar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdjuntar2.Click

        savefile(Integer.Parse(Session("opcfile")))


        
    End Sub

    Private Sub GetUploadFile(ByVal opc As Integer)
        If ValidaFechaHoraConvocatoria(1) Then
            Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('../App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
            Me.fondo.Visible = True
            Me.pnlPropuesta.Attributes("style") = "position:fixed; top:50%; left:50%; width:35em; height:19em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
            Me.pnlPropuesta.Visible = True
            Session("opcfile") = opc
            '======================
        Else
            Me.Mensaje("La Convocatoria ha finalizado, no es posible adjuntar su Propuesta de Proyecto")
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        GetUploadFile(2)
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.fondo.Visible = False
        Me.pnlPropuesta.Visible = False
        Session("opcfile") = 0
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        GetUploadFile(3)
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        GetUploadFile(4)
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        GetUploadFile(5)
    End Sub

    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow

                Dim btndescarga As HyperLink = CType(e.Row.Cells(9).Controls(0), HyperLink)

                Dim ruta As String
                ruta = System.IO.Path.GetFileName(CType(e.Row.DataItem, DataRowView).Item(7).ToString)
                ruta = "/CMSWebParts/MFS/11_11_11" & "/" & ruta

                btndescarga.NavigateUrl = ruta
                btndescarga.Target = "_blank"
                '"../CMSWebParts/MFS/11_11_11") & "/" & rutadearchivo & System.IO.Path.GetExtension(FUperfil.FileName)
                btndescarga.ToolTip = "Comprueba que su archivo adjuntad es el correcto descargandolo AQUI"

        End Select
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ValidaFechaHoraConvocatoria(1) Then
            ' Response.Redirect("/mfs/CMSWebParts/MFS/PerfilCloseConfirmation.aspx")
            'valida carga de archivo
            If Me.GridView3.Rows.Count > 0 Then
                saveconfirmacion(2)
                enviomailconfirmacionPropuesta()

                Dim _URL As String

                Dim JavaScript As String

                _URL = "../CMSWebParts/MFS/PropuestaCloseConfirmation.aspx"

                JavaScript = "window.open('" + _URL + "', null, 'resizable=yes, left=0, top=0, status=yes,toolbar=no,menubar=no,location=no')"

                Response.Write("<SCRIPT LANGUAGE=javascript>" & vbCrLf)

                Response.Write("<!--" & vbCrLf)

                Response.Write(JavaScript & vbCrLf)

                Response.Write("//-->" & vbCrLf)

                Response.Write("</SCRIPT>" & vbCrLf)

                'actualizar estado de proyecto
                UpdateEstadoProyecto(4)
                UpdateTabFromEstado(4)
                Me.Mensaje("Su postulacion se realizó con éxito")
            Else
                Me.Mensaje("Debe realizar previamente los pasos 1 y 2.")
            End If
        Else
            Me.Mensaje("La Convocatoria ha finalizado, no es posible realizar la Postulacion")
        End If
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged

    End Sub
End Class
