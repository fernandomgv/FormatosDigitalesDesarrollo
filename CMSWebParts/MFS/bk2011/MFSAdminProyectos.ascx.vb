Imports CMS.PortalControls
Imports System.Collections.Generic
Imports System.Linq

Partial Class CMSWebParts_MFS_MFSAdminProyectos
    Inherits CMSAbstractWebPart
    Private TempUbicacion As List(Of MFSProyUbicacion) = New List(Of MFSProyUbicacion)
    Private cnx As MFSDataContext = New MFSDataContext
    
    Private Sub GetInfoProyectoFromForm(ByRef tmpproyecto As MFSProyecto)
        tmpproyecto.IdConvocatoria = Integer.Parse(Me.IdConvocatoria.SelectedValue)
        tmpproyecto.NombreProyecto = Me.NombreProyecto.Text
        If Me.PostulacionAsociada.Checked Then
            tmpproyecto.PostulacionAsociada = 1
        Else
            tmpproyecto.PostulacionAsociada = 0
        End If
        tmpproyecto.AmbitoPais = Me.AmbitoPais0.SelectedValue
        'tmpproyecto.AmbitoRegion = Me.AmbitoRegion.SelectedValue
        'tmpproyecto.AmbitoUbicacion = Me.AmbitoUbicacion.Text
        tmpproyecto.NomCoord = Me.NomCoord.Text
        tmpproyecto.AppCoord = Me.AppCoord.Text
        tmpproyecto.CargoCoord = Me.CargoCoord.Text
        tmpproyecto.PaisCoord = Me.PaisCoord.SelectedValue
        tmpproyecto.RegionCoord = Me.RegionCoord.SelectedValue
        tmpproyecto.DireccionCoord = Me.DireccionCoord.Text
        tmpproyecto.EmailCoord = Me.EmailCoord.Text
        tmpproyecto.telefono = Me.telefonoCoord.Text

        'Dim cnx1 As MFSDataContext = New MFSDataContext
        'TempUbicacion = tmpproyecto.MFSProyUbicacion.ToList
        'For Each tmp As MFSProyUbicacion In TempUbicacion
        '    tmp.Region = tmp.PER_REGION.Region
        '    tmp.Pais = tmp.PER_REGION.PER_PAIS.Pais
        'Next
        'Me.GridView2.DataSource = TempUbicacion
        'Me.GridView2.DataBind()

    End Sub

    Private Sub GetInfoEntidadFromForm(ByRef TmpInfoEntidad As MFS_AEA_Proponente)
        TmpInfoEntidad.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID
        TmpInfoEntidad.nombre_entidad = Me.nombre_entidad.Text
        TmpInfoEntidad.acronimo = Me.acronimo.Text
        TmpInfoEntidad.num_registro = Me.num_registro.Text
        TmpInfoEntidad.cod_pais = Me.paisentidad.SelectedValue
        TmpInfoEntidad.cod_regios = Me.regionEndtidad.SelectedValue
        TmpInfoEntidad.direccion = Me.direccion.Text
        TmpInfoEntidad.telefono = Me.telefono.Text
        TmpInfoEntidad.nom_legal = Me.nom_legal.Text
        TmpInfoEntidad.app_legal = Me.app_legal.Text
        TmpInfoEntidad.tipo_doc_legal = Me.tipo_doc_legal.Text
        TmpInfoEntidad.num_doc_legal = Me.num_doc_legal.Text
        TmpInfoEntidad.email_legal = Me.email_legal.Text
        TmpInfoEntidad.telefono_legal = Me.telefono_legal.Text
        TmpInfoEntidad.estado_proponente = 1

    End Sub

    Private Sub SaveProyecto()
        Dim IdProyecto As Integer = 0
        Dim TmpProyecto As New MFSProyecto
        If Session("IdProyecto") Is Nothing Then  ''insercion
            GetInfoProyectoFromForm(TmpProyecto)
            TmpProyecto.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID
            TmpProyecto.FecIns = Date.Now
            TmpProyecto.MFSProyUbicacion.Clear()
            TmpProyecto.EstadoProyecto = 1
            'generacion de codigo de proyecto
            Dim codpro As String
            Dim tmpconvocatoria As MFSConvocatoria
            Dim codpais As PER_PAIS
            Dim codproponente As MFS_AEA_Proponente
            Dim cantpro As Integer
            codpro = "MFS"
            tmpconvocatoria = (From t_c In Me.cnx.MFSConvocatoria Where t_c.IdConvocatoria = TmpProyecto.IdConvocatoria Select t_c).Single()
            codpro = codpro + tmpconvocatoria.codconvocatoria
            codpais = (From t_p In Me.cnx.PER_PAIS Where t_p.CodPais = TmpProyecto.AmbitoPais Select t_p).Single()
            codpro = codpro + codpais.AbrevPais
            codproponente = (From t_c In Me.cnx.MFS_AEA_Proponente Where t_c.UserId = TmpProyecto.UserId Select t_c).Single()
            codpro = codpro + codproponente.CodProponente
            cantpro = (From t_prp In Me.cnx.MFSProyecto Where t_prp.UserId = TmpProyecto.UserId Select t_prp).Count
            cantpro = cantpro + 1
            If cantpro < 9 Then
                codpro = codpro + "0" + cantpro.ToString
            Else
                codpro = codpro + cantpro.ToString
            End If
            TmpProyecto.CodProyecto = codpro
            'grabamos en bd el proyecto
            cnx.MFSProyecto.InsertOnSubmit(TmpProyecto)
            cnx.SubmitChanges()
            If Session("TempUbicacion") IsNot Nothing Then
                Me.TempUbicacion = Session("TempUbicacion")
            End If
            For Each TmpUbicacion As MFSProyUbicacion In Me.TempUbicacion
                Dim tmu As New MFSProyUbicacion
                tmu.AmbitoPais = TmpUbicacion.AmbitoPais
                tmu.AmbitoRegion = TmpUbicacion.AmbitoRegion
                tmu.AmbitoUbicacion = TmpUbicacion.AmbitoUbicacion
                tmu.IdProyecto = TmpProyecto.IdProyecto
                TmpProyecto.MFSProyUbicacion.Add(tmu)
            Next
            cnx.MFSProyUbicacion.InsertAllOnSubmit(TmpProyecto.MFSProyUbicacion)
            TmpProyecto.IpAccess = HTTPHelper.GetUserHostAddress()
            
        Else    ''actualizacion

            IdProyecto = Session("IdProyecto")
            TmpProyecto = (From t_prp In Me.cnx.MFSProyecto Where t_prp.IdProyecto = IdProyecto Select t_prp).Single()
            GetInfoProyectoFromForm(TmpProyecto)
            TmpProyecto.FechaUp = Date.Now
            'borramos las ubicaciones actuales y generamos las nuevas
            cnx.DelUbicacionesProyecto(TmpProyecto.IdProyecto)
            ''agregamos las ubicaciones.
            If Session("TempUbicacion") IsNot Nothing Then
                Me.TempUbicacion = Session("TempUbicacion")
            End If
            For Each TmpUbicacion As MFSProyUbicacion In Me.TempUbicacion
                Dim tmu As New MFSProyUbicacion
                tmu.AmbitoPais = TmpUbicacion.AmbitoPais
                tmu.AmbitoRegion = TmpUbicacion.AmbitoRegion
                tmu.AmbitoUbicacion = TmpUbicacion.AmbitoUbicacion
                tmu.IdProyecto = TmpProyecto.IdProyecto
                TmpProyecto.MFSProyUbicacion.Add(tmu)
            Next
            cnx.MFSProyUbicacion.InsertAllOnSubmit(TmpProyecto.MFSProyUbicacion)
            TmpProyecto.IpAccess = HTTPHelper.GetUserHostAddress()
        End If
        cnx.SubmitChanges()
        Session("IdProyecto") = TmpProyecto.IdProyecto
    End Sub
    Private Sub SaveInfoEntidad()
        Dim TmpEntidad As New MFS_AEA_Proponente
        Dim TmpEntidadHis As New MFS_AEA_Proponente_His
        If Me.ValidaInfoProponente Then
            'se esta realizando una actualizacion
            TmpEntidad = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
            TmpEntidad.MFS_AEA_Proponente_His.Add(TmpEntidadHis)
            Me.GetInfoEntidadFromForm(TmpEntidad)
            TmpEntidad.fec_up = Date.Now
            TmpEntidad.user_acces = CMS.CMSHelper.CMSContext.CurrentUser.UserID
            TmpEntidad.ip_acces = HTTPHelper.GetUserHostAddress()
        Else
            'es la primera vez que se registrara la informacion
            Me.GetInfoEntidadFromForm(TmpEntidad)
            TmpEntidad.CodProponente = Me.cnx.GETNroProponente()
            TmpEntidad.fec_ins = Date.Now
            TmpEntidad.user_acces = CMS.CMSHelper.CMSContext.CurrentUser.UserID
            TmpEntidad.ip_acces = HTTPHelper.GetUserHostAddress()
            cnx.MFS_AEA_Proponente.InsertOnSubmit(TmpEntidad)
        End If
        cnx.SubmitChanges()
    End Sub
    Private Sub GetProyectonew()

        Me.NombreProyecto.Text = ""
        Me.PostulacionAsociada.Checked = False
        Me.AmbitoPais0.Enabled = True
        'Me.AmbitoPais.SelectedValue = TmpProyecto.AmbitoPais
        'Me.AmbitoRegion.SelectedValue = TmpProyecto.AmbitoRegion
        'Me.AmbitoUbicacion.Text = TmpProyecto.AmbitoUbicacion
        Me.NomCoord.Text = ""
        Me.AppCoord.Text = ""
        Me.CargoCoord.Text = ""
        'Me.PaisCoord.SelectedValue = TmpProyecto.PaisCoord
        'Me.RegionCoord.SelectedValue = TmpProyecto.RegionCoord
        Me.DireccionCoord.Text = ""
        Me.EmailCoord.Text = ""
        Me.telefonoCoord.Text = ""
        TempUbicacion.clear()
        Me.GridView2.DataSource = TempUbicacion
        Me.GridView2.DataBind()
    End Sub
    Private Sub GetProyecto(ByVal IdProyecto As Integer)
        Dim TmpProyecto As New MFSProyecto
        TmpProyecto = (From t_prp In Me.cnx.MFSProyecto Where t_prp.IdProyecto = IdProyecto Select t_prp).Single()
        Me.IdProyecto.Text = TmpProyecto.CodProyecto
        Me.IdConvocatoria.SelectedValue = TmpProyecto.IdConvocatoria.ToString
        Me.NombreProyecto.Text = TmpProyecto.NombreProyecto
        If TmpProyecto.PostulacionAsociada = 1 Then
            Me.PostulacionAsociada.Checked = True
        Else
            Me.PostulacionAsociada.Checked = False
        End If
        Me.AmbitoPais0.SelectedValue = TmpProyecto.AmbitoPais
        Me.AmbitoPais0.Enabled = False
        'Me.AmbitoRegion.databind()
        'Me.AmbitoRegion.SelectedValue = TmpProyecto.AmbitoRegion
        'Me.AmbitoUbicacion.Text = TmpProyecto.AmbitoUbicacion
        Me.NomCoord.Text = TmpProyecto.NomCoord
        Me.AppCoord.Text = TmpProyecto.AppCoord
        Me.CargoCoord.Text = TmpProyecto.CargoCoord
        Me.PaisCoord.SelectedValue = TmpProyecto.PaisCoord
        Me.RegionCoord.DataBind()
        Me.RegionCoord.SelectedValue = TmpProyecto.RegionCoord
        Me.DireccionCoord.Text = TmpProyecto.DireccionCoord
        Me.EmailCoord.Text = TmpProyecto.EmailCoord
        Me.telefonoCoord.Text = TmpProyecto.telefono
        TempUbicacion = TmpProyecto.MFSProyUbicacion.ToList
        For Each tmp As MFSProyUbicacion In TempUbicacion
            tmp.Region = tmp.PER_REGION.Region
            tmp.Pais = tmp.PER_REGION.PER_PAIS.Pais
        Next
        Session("TempUbicacion") = Me.TempUbicacion
        Me.GridView2.DataSource = TempUbicacion
        Me.GridView2.DataBind()

    End Sub
    Private Sub getinfoentidad(ByVal opc As Integer)
        Dim TmpInfoEntidad As MFS_AEA_Proponente
        Me.email.Text = CMS.CMSHelper.CMSContext.CurrentUser.Email
        
        If opc = 0 Then
            'aun no se ha registrado la entidad.
            'recuperamos la informacion del usuario actual
            Me.acronimo.Text = CMS.CMSHelper.CMSContext.CurrentUser.LastName
            Me.nombre_entidad.Text = CMS.CMSHelper.CMSContext.CurrentUser.FirstName
        Else
            TmpInfoEntidad = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
            'recuperamos la informacion desde la BD

            Me.nombre_entidad.Text = TmpInfoEntidad.nombre_entidad
            Me.acronimo.Text = TmpInfoEntidad.acronimo
            Me.num_registro.Text = TmpInfoEntidad.num_registro
            Me.paisentidad.DataBind()
            Me.paisentidad.SelectedValue = TmpInfoEntidad.cod_pais
            Me.regionEndtidad.DataBind()
            Me.regionEndtidad.SelectedValue = TmpInfoEntidad.cod_regios
            Me.direccion.Text = TmpInfoEntidad.direccion
            Me.telefono.Text = TmpInfoEntidad.telefono
            Me.nom_legal.Text = TmpInfoEntidad.nom_legal
            Me.app_legal.Text = TmpInfoEntidad.app_legal
            Me.tipo_doc_legal.Text = TmpInfoEntidad.tipo_doc_legal
            Me.num_doc_legal.Text = TmpInfoEntidad.num_doc_legal
            Me.email_legal.Text = TmpInfoEntidad.email_legal
            Me.telefono_legal.Text = TmpInfoEntidad.telefono_legal
            '
            '
        End If

    End Sub
    Private Sub admpaneles(ByVal opc As Integer)
        Select Case opc
            Case 0 ' sin acceso
                Pnlinfoproponente.Visible = False
                PnlregistroProyecto.Visible = False
                PnlBandejaProyecto.Visible = False
                Pnlmensajeaceso.Visible = True
            Case 1  ' ver panel de proyectos
                Me.Pnlinfoproponente.Visible = False
                Me.PnlBandejaProyecto.Visible = False
                Me.PnlregistroProyecto.Visible = True
            Case 2 ' mostrar informacion proponente
                Me.pnlRegInstitucion.Visible = False
                Me.btnInfoentidad.Text = "[+] Mostrar la información de Entidad Proponente"
                PnlregistroProyecto.Visible = False
                PnlBandejaProyecto.Visible = True
            Case 3
                Me.pnlRegInstitucion.Visible = False
                Me.btnInfoentidad.Text = "[+] Mostrar la información de Entidad Proponente"
            Case 4
                Me.pnlRegInstitucion.Visible = True
                Me.btnInfoentidad.Text = "[-] Ocultar la información de Entidad Proponente"
            Case 5
                Me.PnlregistroProyecto.Visible = False
                Me.Pnlinfoproponente.Visible = True
                Me.PnlBandejaProyecto.Visible = True
            Case 6
                Me.pnlRegInstitucion.Visible = True
                Me.btnInfoentidad.Text = "[-] Ocultar la información de Entidad Proponente"
                PnlregistroProyecto.Visible = False
                PnlBandejaProyecto.Visible = False
                Pnlmensajeaceso.Visible = False

        End Select
    End Sub
    Protected Sub btnagregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("idProyecto") = Nothing
        GetProyectonew()
        admpaneles(1)
        Session("admpaneles") = 1
    End Sub

    Private Sub grdubicacion()
        If Session("TempUbicacion") IsNot Nothing Then
            Me.TempUbicacion = Session("TempUbicacion")
            Me.GridView2.DataSource = Me.TempUbicacion
            Me.GridView2.DataBind()
            Me.lblmensaje.Visible = False
        End If

    End Sub
    Private Function validaUbicacion() As Boolean
        If Me.AmbitoUbicacion.Text = "" Then
            Me.lblmensaje.Visible = True
            Me.lblmensaje.Text = "Debe ingresar la Ubicacion Especifica, correspondiente al Pais y Region Seleccionados"
            Return False
        Else
            Me.lblmensaje.Visible = False
            Return True
        End If
    End Function
    Protected Sub BtnUbicacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUbicacion.Click
        '  If validaUbicacion() Then
        Dim tubicacion As MFSProyUbicacion = New MFSProyUbicacion()

        tubicacion.AmbitoPais = Me.AmbitoPais.SelectedValue
        tubicacion.AmbitoRegion = Me.AmbitoRegion.SelectedValue
        tubicacion.AmbitoUbicacion = Me.AmbitoUbicacion.Text

        tubicacion.PER_REGION = (From reg In cnx.PER_REGION Where reg.CodRegion = tubicacion.AmbitoRegion Select reg).Single()
        tubicacion.Pais = tubicacion.PER_REGION.PER_PAIS.Pais
        tubicacion.Region = tubicacion.PER_REGION.Region

        If Session("TempUbicacion") IsNot Nothing Then
            Me.TempUbicacion = Session("TempUbicacion")
        End If
        Dim TmpIdProyectoUbicacion As Integer = 0

        If TempUbicacion.Count > 0 Then
            TmpIdProyectoUbicacion = (From pu In TempUbicacion Select pu.IdProyectoUbicacion).Min()
        End If

        If TmpIdProyectoUbicacion >= 0 Then
            TmpIdProyectoUbicacion = -1
        Else
            TmpIdProyectoUbicacion = -1 + TmpIdProyectoUbicacion
        End If

        tubicacion.IdProyectoUbicacion = TmpIdProyectoUbicacion
        Me.TempUbicacion.Add(tubicacion)
        Session("TempUbicacion") = Me.TempUbicacion
        Me.AmbitoUbicacion.Text = ""
        grdubicacion()
        '  End If
    End Sub
    Private Function ValidaInfoProponente() As Boolean
        Dim existeproponente As Integer = 0
        Dim tmp_prp As MFS_AEA_Proponente

        existeproponente = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID).Count()

        If existeproponente > 0 Then
            tmp_prp = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
        End If

        If tmp_prp Is Nothing Then
            Return False
        End If
        'valida informacion necesaria
        If tmp_prp.estado_proponente = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Function validapermiso() As Boolean
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            If Not CMS.CMSHelper.CMSContext.CurrentUser.IsInRole("UserMFS", CMS.CMSHelper.CMSContext.CurrentSiteName) Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Sub solicitainfoproponente()
        Me.btnInfoentidad.Text = "[-] Ocultar la información de Entidad Proponente"
        Me.Pnlinfoproponente.Visible = True
        Me.pnlRegInstitucion.Visible = True
        Me.lblmensajeproponente.Visible = True
        Me.lblmensajeproponente.Text = "Usted aún no ha registrado la información necesaria para poder registrar su(s) proyecto(s): Favor ingresar los datos en TODOS los campos solicitados en el siguiente formulario"

        Me.PnlBandejaProyecto.Visible = False
        Me.PnlregistroProyecto.Visible = False
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.Response.AddHeader("P3P", "CP = \' IDC DSP COR ADM DEVI Taií PSA PSD Ivaí IVDi CONI SU NUESTRA IND CNT \' ")
        Session("UserId") = CMS.CMSHelper.CMSContext.CurrentUser.UserID
        If validapermiso() Then
            If Page.IsPostBack Then
                grdubicacion()
                grdproyectos()
                admpaneles(Session("admpaneles"))

            Else
                'inicializacion
                If Not ValidaInfoProponente() Then
                    solicitainfoproponente()
                    Me.getinfoentidad(0)
                    admpaneles(6)
                    Session("admpaneles") = 6
                    Me.GridView2.DataSource = TempUbicacion
                    Session("TempUbicacion") = Nothing
                Else
                    ' la informacion del proponente esta completa
                    Me.getinfoentidad(1)
                    Me.lblmensajeproponente.Visible = False
                    Me.lblmensajeproponente.Text = ""
                    admpaneles(2)
                    Session("admpaneles") = 2
                    Me.GridView2.DataSource = TempUbicacion
                    Session("TempUbicacion") = Nothing
                End If
            End If
        Else
            admpaneles(0)
        End If
    End Sub
    Private Sub DelProyUbicacionAll()
        Me.TempUbicacion = Session("TempUbicacion")
        Dim tubicacion() As MFSProyUbicacion
        ReDim tubicacion(Me.TempUbicacion.Count - 1)
        TempUbicacion.CopyTo(tubicacion)
        For Each tpu As MFSProyUbicacion In tubicacion
            DelProyUbicacion(tpu.IdProyectoUbicacion)
        Next
        Session("TempUbicacion") = Me.TempUbicacion
        grdubicacion()
    End Sub
    Private Sub DelProyUbicacion(ByVal ID As Integer)
        'If ID < 0 Then 'no ha sido aun guardado en la bd
        Me.TempUbicacion = Session("TempUbicacion")
        Dim pu As MFSProyUbicacion
        pu = (From tpu In TempUbicacion Where tpu.IdProyectoUbicacion = ID Select tpu).Single()
        Me.TempUbicacion.Remove(pu)
        Session("TempUbicacion") = Me.TempUbicacion
        grdubicacion()
        'End If
    End Sub
    Protected Sub btnInfoentidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfoentidad.Click
        If Me.pnlRegInstitucion.Visible Then
            admpaneles(3)
            Session("admpaneles") = 3
        Else
            admpaneles(4)
            Session("admpaneles") = 4
        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Actualiza()
    End Sub
   
    Protected Sub btngrabarentidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabarentidad.Click
        If Page.IsValid Then
            SaveInfoEntidad()
            Mensaje("Sus datos se grabaron satisfactoriamente")
            Me.getinfoentidad(1)
            Me.lblmensajeproponente.Visible = False
            Me.lblmensajeproponente.Text = ""
            admpaneles(2)
            Session("admpaneles") = 2
        End If
    End Sub


    Protected Sub btncancelarentidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelarentidad.Click
        If Not ValidaInfoProponente() Then
            Me.getinfoentidad(0)
        Else
            ' la informacion del proponente esta completa
            Me.getinfoentidad(1)
        End If
    End Sub
    Private Sub grdproyectos()
        Me.GridView1.DataBind()
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Page.IsValid Then
            SaveProyecto()
            Mensaje("Sus datos se grabaron satisfactoriamente")
            Actualiza()
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If Session("grdap4") Is Nothing Then
            If Session("TempUbicacion") IsNot Nothing Then
                Me.TempUbicacion = Session("TempUbicacion")
                Me.GridView2.DataSource = Me.TempUbicacion
                Me.GridView2.DataBind()
            End If
            If e.CommandName = "eliminar" Then
                Me.GridView2.SelectedIndex = Integer.Parse(e.CommandArgument)
                If Me.GridView2.SelectedIndex > -1 And Me.TempUbicacion.Count > 0 Then
                    DelProyUbicacion(Integer.Parse(Me.GridView2.SelectedValue))
                    Session("grdap4") = "grdap4"
                End If
                Me.grdubicacion()
            End If
        Else
            Session("grdap4") = Nothing
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim cnx1 As New MFSDataContext
        Me.GridView1.SelectedIndex = Integer.Parse(e.CommandArgument)
        Session("IdProyecto") = Integer.Parse(Me.GridView1.SelectedValue)
        If e.CommandName = "workflow" Then
            Me.Response.Redirect("/mfs/MFS/MFSworkflow.aspx")
        End If
        If e.CommandName = "Eliminar" Then
            Dim tmp As New MFSProyecto
            tmp = (From t_prp In cnx1.MFSProyecto Where t_prp.IdProyecto = Integer.Parse(Session("IdProyecto").ToString) Select t_prp).Single()
            cnx1.DelUbicacionesProyecto(tmp.IdProyecto)
            cnx1.MFSProyecto.DeleteOnSubmit(tmp)
            cnx1.SubmitChanges()
            Me.GridView1.DataBind()
        End If
        If e.CommandName = "Editar" Then
            Me.admpaneles(1)
            Me.GetProyecto(Session("IdProyecto"))
            Session("admpaneles") = 1
        End If
    End Sub
    Private Sub Actualiza()
        admpaneles(5)
        Session("admpaneles") = 5
        Me.GridView1.DataBind()
    End Sub
    
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                
                Dim ctrlEliminar As ImageButton = CType(e.Row.Cells(2).Controls(0), ImageButton)
                ctrlEliminar.OnClientClick = "if( !confirm('¿Seguro que desea ELIMINAR este Proyecto?')){return false;}"
                ctrlEliminar.ToolTip = "Eliminar Proyecto"

                Dim ctrlEditar As ImageButton = CType(e.Row.Cells(1).Controls(0), ImageButton)
                ctrlEditar.ToolTip = "Editar Proyecto, clic aqui para modificar la informacion de su Proyecto"

                Dim ctrlAdmin As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                ctrlAdmin.ToolTip = "Administrar Proyecto, clic aqui para continuar con el Proceso de la Convocatoria"

        End Select
    End Sub

    Private Sub Mensaje(ByVal cad As String)

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('/MFS/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
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

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim ctrlEliminar As ImageButton = CType(e.Row.Cells(5).Controls(0), ImageButton)
                ctrlEliminar.OnClientClick = "if( !confirm('¿Seguro que desea ELIMINAR esta Ubicación?')){return false;}"
                ctrlEliminar.ToolTip = "Eliminar Proyecto"

        End Select

    End Sub

    Protected Sub btngrabar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar1.Click
        If Page.IsValid Then
            If Me.TempUbicacion.count > 0 Then
                SaveProyecto()
                Mensajeperfil("Sus datos se grabaron satisfactoriamente")
                Actualiza()

            Else
                Me.lblmensaje.visible = True
            End If
        End If
    End Sub

    Protected Sub btncancelar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar2.Click
        Actualiza()
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        If Me.Panel2.Visible = True Then
            Me.Panel2.Visible = False

            Me.LinkButton2.Text = "[+]"
            Me.LinkButton2.ToolTip = "Mostrar Ayuda"
        Else
            Me.Panel2.Visible = True

            Me.LinkButton2.Text = "[-]"
            Me.LinkButton2.ToolTip = "Ocultar Ayuda"
        End If

    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Response.Redirect("/mfs/MFS/MFSworkflow.aspx")
    End Sub
    Private Sub Mensajeperfil(ByVal cad As String)

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('/MFS/App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.Panel4.Attributes("style") = "position:fixed; top:50%; left:50%; width:30em; height:7em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.Panel4.Visible = True
        Me.Label3.Text = cad
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.fondo.Visible = False
        Me.Panel4.Visible = False
    End Sub
End Class
