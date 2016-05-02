Imports CMS.PortalControls
Imports System.Collections.Generic
Imports System.Linq
Imports System.Globalization
Imports CMS.SiteProvider


Partial Class CMSWebParts_MFS_MFSAdminProyectos
    Inherits CMSAbstractWebPart
    Private TempUbicacion As List(Of MFSProyUbicacion) = New List(Of MFSProyUbicacion)
    Private cnx As MFSDataContext = New MFSDataContext
    Private myDTFI As DateTimeFormatInfo
    
    Private Sub GetInfoProyectoFromForm(ByRef tmpproyecto As MFSProyecto)
        tmpproyecto.IdConvocatoria = Integer.Parse(Me.IdConvocatoria.SelectedValue)
        tmpproyecto.NombreProyecto = Me.NombreProyecto.Text
        
        tmpproyecto.AmbitoPais = Me.AmbitoPais0.SelectedValue
        'tmpproyecto.AmbitoRegion = Me.AmbitoRegion.SelectedValue
        'tmpproyecto.AmbitoUbicacion = Me.AmbitoUbicacion.Text
        tmpproyecto.NomCoord = Me.NomCoord.Text
        tmpproyecto.AppCoord = Me.AppCoord.Text
        tmpproyecto.CargoCoord = Me.CargoCoord.Text
        If Me.PaisCoord.SelectedValue = "" Then
            Me.PaisCoord.SelectedIndex = -1
        End If
        If Me.RegionCoord.SelectedValue = "" Then
            Me.RegionCoord.SelectedIndex = -1
        End If
        tmpproyecto.PaisCoord = Me.PaisCoord.SelectedValue
        tmpproyecto.RegionCoord = Me.RegionCoord.SelectedValue
        'tmpproyecto.IdProvinciaCoord = Integer.Parse(Me.ProvinciaEndtidad1.SelectedValue)
        tmpproyecto.DireccionCoord = Me.DireccionCoord.Text
        tmpproyecto.EmailCoord = Me.EmailCoord.Text
        tmpproyecto.telefono = Me.telefonoCoord.Text

        tmpproyecto.contrapartida = Double.Parse(Me.contrapartida.Text)
        tmpproyecto.financiamientosolicitado = Double.Parse(Me.financiamientosolicitado.Text)
        tmpproyecto.Duracionmes = Integer.Parse(Me.Duracionmes.Text)
        'tmpproyecto.Tipopy2 = Integer.Parse(Me.rbproducto.SelectedValue)

        If Me.PostulacionAsociada.Checked Then
            tmpproyecto.PostulacionAsociada = 1
            If Me.pnlentidadasociada.Visible = True Then
                tmpproyecto.EntidadAsociada1 = Me.EntidadAsociada1.Text
                'tmpproyecto.TipoEA11 = Integer.Parse(rbfin0.SelectedValue)
                tmpproyecto.TipoEA21 = Integer.Parse(DropDownList2.SelectedValue)
                tmpproyecto.fechaconstitucionEA1 = Date.Parse(Me.fechaconstitucionEA1.Text, Me.myDTFI)
                If tmpproyecto.TipoEA21 = 9 Then
                    tmpproyecto.TipoEA2otro1 = Me.TxtConstOtro0.Text
                Else
                    tmpproyecto.TipoEA2otro1 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada1 = ""
            End If
            If Me.pnlentidadasociada0.Visible = True Then
                tmpproyecto.EntidadAsociada2 = Me.EntidadAsociada2.Text
                tmpproyecto.fechaconstitucionEA2 = Date.Parse(Me.txtfechaconstitucion1.Text, Me.myDTFI)
                'tmpproyecto.TipoEA12 = Integer.Parse(rbfin1.SelectedValue)
                tmpproyecto.TipoEA22 = Integer.Parse(DropDownList3.SelectedValue)
                If tmpproyecto.TipoEA22 = 9 Then
                    tmpproyecto.TipoEA2otro2 = Me.TxtConstOtro0.Text
                Else
                    tmpproyecto.TipoEA2otro2 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada2 = ""
            End If
            If Me.pnlentidadasociada1.Visible = True Then
                tmpproyecto.EntidadAsociada3 = Me.EntidadAsociada3.Text
                tmpproyecto.fechaconstitucionEA3 = Date.Parse(Me.txtfechaconstitucion2.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA23 = Integer.Parse(DropDownList4.SelectedValue)
                If tmpproyecto.TipoEA23 = 9 Then
                    tmpproyecto.TipoEA2otro3 = Me.TxtConstOtro0.Text
                Else
                    tmpproyecto.TipoEA2otro3 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada3 = ""
            End If
            If Me.pnlentidadasociada1.Visible = True Then
                tmpproyecto.EntidadAsociada3 = Me.EntidadAsociada3.Text
                tmpproyecto.fechaconstitucionEA3 = Date.Parse(Me.txtfechaconstitucion2.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA23 = Integer.Parse(DropDownList4.SelectedValue)
                If tmpproyecto.TipoEA23 = 9 Then
                    tmpproyecto.TipoEA2otro3 = Me.TxtConstOtro0.Text
                Else
                    tmpproyecto.TipoEA2otro3 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada3 = ""
            End If

            If Me.pnlentidadasociada2.Visible = True Then
                tmpproyecto.EntidadAsociada4 = Me.TextBox1.Text
                tmpproyecto.fechaconstitucionEA4 = Date.Parse(Me.TextBox2.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA24 = Integer.Parse(DropDownList5.SelectedValue)
                If tmpproyecto.TipoEA24 = 9 Then
                    tmpproyecto.TipoEA2otro4 = Me.TextBox3.Text
                Else
                    tmpproyecto.TipoEA2otro4 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada4 = ""
            End If

            If Me.pnlentidadasociada3.Visible = True Then
                tmpproyecto.EntidadAsociada5 = Me.TextBox4.Text
                tmpproyecto.fechaconstitucionEA5 = Date.Parse(Me.TextBox5.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA25 = Integer.Parse(DropDownList6.SelectedValue)
                If tmpproyecto.TipoEA25 = 9 Then
                    tmpproyecto.TipoEA2otro5 = Me.TextBox6.Text
                Else
                    tmpproyecto.TipoEA2otro5 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada5 = ""
            End If

            If Me.pnlentidadasociada4.Visible = True Then
                tmpproyecto.EntidadAsociada6 = Me.TextBox7.Text
                tmpproyecto.fechaconstitucionEA6 = Date.Parse(Me.TextBox8.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA26 = Integer.Parse(DropDownList7.SelectedValue)
                If tmpproyecto.TipoEA26 = 9 Then
                    tmpproyecto.TipoEA2otro6 = Me.TextBox9.Text
                Else
                    tmpproyecto.TipoEA2otro6 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada6 = ""
            End If

            If Me.pnlentidadasociada5.Visible = True Then
                tmpproyecto.EntidadAsociada7 = Me.TextBox10.Text
                tmpproyecto.fechaconstitucionEA7 = Date.Parse(Me.TextBox11.Text, Me.myDTFI)
                'tmpproyecto.TipoEA13 = Integer.Parse(rbfin2.SelectedValue)
                tmpproyecto.TipoEA27 = Integer.Parse(DropDownList8.SelectedValue)
                If tmpproyecto.TipoEA27 = 9 Then
                    tmpproyecto.TipoEA2otro7 = Me.TextBox12.Text
                Else
                    tmpproyecto.TipoEA2otro7 = ""
                End If
            Else
                tmpproyecto.EntidadAsociada7 = ""
            End If
        Else
            tmpproyecto.PostulacionAsociada = 0
            tmpproyecto.EntidadAsociada3 = ""
            tmpproyecto.EntidadAsociada2 = ""
            tmpproyecto.EntidadAsociada1 = ""
            tmpproyecto.EntidadAsociada4 = ""
            tmpproyecto.EntidadAsociada5 = ""
            tmpproyecto.EntidadAsociada6 = ""
            tmpproyecto.EntidadAsociada7 = ""
        End If

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
        TmpInfoEntidad.fechaconstitucion = Date.Parse(Me.txtfechaconstitucion.Text, Me.myDTFI)
        TmpInfoEntidad.TipoEP1 = Integer.Parse(Me.rbfin.SelectedValue)
        TmpInfoEntidad.TipoEP2 = Integer.Parse(Me.DropDownList1.SelectedValue)
        If TmpInfoEntidad.TipoEP2.Value = 9 Then
            TmpInfoEntidad.TipoEP2Otro = Me.TxtConstOtro.Text
        Else
            TmpInfoEntidad.TipoEP2Otro = ""
        End If
        'TmpInfoEntidad.IdProvincia = Integer.Parse(ProvinciaEndtidad.SelectedValue)
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
            codpro = "AEA"
            tmpconvocatoria = (From t_c In Me.cnx.MFSConvocatoria Where t_c.IdConvocatoria = TmpProyecto.IdConvocatoria Select t_c).Single()
            codpro = codpro + tmpconvocatoria.codconvocatoria
            codpais = (From t_p In Me.cnx.PER_PAIS Where t_p.CodPais = TmpProyecto.AmbitoPais Select t_p).Single()
            codpro = codpro + codpais.AbrevPais
            codproponente = (From t_c In Me.cnx.MFS_AEA_Proponente Where t_c.UserId = TmpProyecto.UserId Select t_c).Single()
            codpro = codpro + codproponente.CodProponente
            cantpro = (From t_prp In Me.cnx.MFSProyecto Where t_prp.UserId = TmpProyecto.UserId And t_prp.IdConvocatoria = tmpconvocatoria.IdConvocatoria Select t_prp).Count
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
                'tmu.IdProvincia = TmpUbicacion.IdProvincia
                'tmu.Provincia = TmpUbicacion.Provincia
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
        If Me.ValidaInfoProponente1 Then
            'se esta realizando una actualizacion
            TmpEntidad = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
            TmpEntidad.MFS_AEA_Proponente_His.Add(TmpEntidadHis)
            Me.GetInfoEntidadFromForm(TmpEntidad)
            TmpEntidad.fec_up = Date.Now
            TmpEntidad.user_acces = CMS.CMSHelper.CMSContext.CurrentUser.UserID
            'TmpEntidad.ip_acces = HTTPHelper.GetUserHostAddress()
            'TmpEntidad.IdProvincia = Integer.Parse(ProvinciaEndtidad.SelectedValue)
        Else
            'es la primera vez que se registrara la informacion
            Me.GetInfoEntidadFromForm(TmpEntidad)

            'TmpEntidad.CodProponente = Me.cnx.GETNroProponente()
            TmpEntidad.CodProponente = Me.GetNroProponente(TmpEntidad.email_legal)
            TmpEntidad.fec_ins = Date.Now
            TmpEntidad.user_acces = CMS.CMSHelper.CMSContext.CurrentUser.UserID
            TmpEntidad.ip_acces = HTTPHelper.GetUserHostAddress()

            cnx.MFS_AEA_Proponente.InsertOnSubmit(TmpEntidad)
        End If
        cnx.SubmitChanges()
    End Sub
    Private Function GetNroProponente(ByVal obs As String) As String

        Dim NroProponente As String = "0000"
        Dim className As String = "customtable.FASERT_Proponente"
        Dim FASERT_Proponente As CustomTableItem = Nothing
        Dim Tbprovider As CustomTableItemProvider = New CustomTableItemProvider(CMSContext.CurrentUser)
        FASERT_Proponente = New CustomTableItem(className, Tbprovider)
        FASERT_Proponente.SetValue("Observacion", obs)

        If FASERT_Proponente.OrderEnabled Then
            FASERT_Proponente.ItemOrder = Tbprovider.GetLastItemOrder(className) + 1
        End If
        FASERT_Proponente.Insert()
        NroProponente = NroProponente + FASERT_Proponente.GetIntegerValue("ItemOrder", 0).ToString()

        Return NroProponente.Substring(NroProponente.Length - 4, 4)

    End Function
    Private Sub GetProyectonew()
        Me.Page.Validate()
        Me.IdProyecto.Text = ""

        Me.NombreProyecto.Text = ""
        Me.PostulacionAsociada.Checked = False
        Me.AmbitoPais0.Enabled = True
        Me.Duracionmes.Text = ""
        Me.financiamientosolicitado.Text = ""
        Me.contrapartida.Text = ""
        Me.TotalProyecto.Text = ""
        'Me.rbproducto.SelectedIndex = -1
        'Me.AmbitoPais.SelectedValue = TmpProyecto.AmbitoPais
        'Me.AmbitoRegion.SelectedValue = TmpProyecto.AmbitoRegion
        'Me.AmbitoUbicacion.Text = TmpProyecto.AmbitoUbicacion
        Me.NomCoord.Text = ""
        Me.AppCoord.Text = ""
        Me.CargoCoord.Text = ""
        'Me.PaisCoord.SelectedValue = TmpProyecto.PaisCoord
        'Me.RegionCoord.SelectedValue = TmpProyecto.RegionCoord
        Me.PaisCoord.DataBind()
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
        If Not TmpProyecto.RegionCoord = "" Then
            Me.RegionCoord.SelectedValue = TmpProyecto.RegionCoord
        End If
        'Me.ProvinciaEndtidad1.DataBind()
        'If Not TmpProyecto.IdProvinciaCoord.ToString() = "" Then
        '    Me.ProvinciaEndtidad1.SelectedValue = TmpProyecto.IdProvinciaCoord.ToString()
        'End If
        Me.DireccionCoord.Text = TmpProyecto.DireccionCoord
        Me.EmailCoord.Text = TmpProyecto.EmailCoord
        Me.telefonoCoord.Text = TmpProyecto.telefono
        TempUbicacion = TmpProyecto.MFSProyUbicacion.ToList
        For Each tmp As MFSProyUbicacion In TempUbicacion
            tmp.Region = tmp.PER_REGION.Region
            tmp.Pais = tmp.PER_REGION.PER_PAIS.Pais
            'tmp.Provincia = tmp.Provincia
        Next
        Session("TempUbicacion") = Me.TempUbicacion
        Me.GridView2.DataSource = TempUbicacion
        Me.GridView2.DataBind()

        Me.contrapartida.Text = TmpProyecto.contrapartida.ToString
        Me.financiamientosolicitado.Text = TmpProyecto.financiamientosolicitado.ToString
        Me.TotalProyecto.Text = TmpProyecto.contrapartida + TmpProyecto.financiamientosolicitado
        Me.Duracionmes.Text = TmpProyecto.Duracionmes.ToString
        'Me.rbproducto.DataBind()
        'If TmpProyecto.Tipopy2.HasValue Then
        '    Me.rbproducto.SelectedValue = TmpProyecto.Tipopy2.ToString
        'End If
        If TmpProyecto.PostulacionAsociada = 1 Then
            Me.PostulacionAsociada.Checked = True
            Me.pnlentidadasociada.Visible = False
            Me.pnlentidadasociada0.Visible = False
            Me.pnlentidadasociada1.Visible = False
            Me.pnlentidadasociada2.Visible = False
            Me.pnlentidadasociada3.Visible = False
            Me.pnlentidadasociada4.Visible = False
            Me.pnlentidadasociada5.Visible = False
            If TmpProyecto.EntidadAsociada1 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada1.Trim("").Length > 0 Then
                    Me.pnlentidadasociada.Visible = True
                    Me.EntidadAsociada1.Text = TmpProyecto.EntidadAsociada1
                    If TmpProyecto.fechaconstitucionEA1.HasValue Then
                        Me.fechaconstitucionEA1.Text = TmpProyecto.fechaconstitucionEA1.Value.Day.ToString & "/" & TmpProyecto.fechaconstitucionEA1.Value.Month.ToString & "/" & TmpProyecto.fechaconstitucionEA1.Value.Year.ToString
                    Else
                        RequiredFieldValidator26.Validate()
                    End If
                    ' rbfin0.DataBind()
                    '  rbfin0.SelectedValue = TmpProyecto.TipoEA11.ToString
                    DropDownList2.DataBind()
                    DropDownList2.SelectedValue = TmpProyecto.TipoEA21.ToString
                    If TmpProyecto.TipoEA21 = 9 Then
                        Me.PnlConstOtro0.Visible = True
                        Me.TxtConstOtro0.Text = TmpProyecto.TipoEA2otro1
                    Else
                        Me.TxtConstOtro0.Text = ""
                        Me.PnlConstOtro0.Visible = False
                    End If
                End If
            End If
            If TmpProyecto.EntidadAsociada2 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada2.Trim("").Length > 0 Then
                    Me.pnlentidadasociada0.Visible = True
                    Me.EntidadAsociada2.Text = TmpProyecto.EntidadAsociada2
                    If TmpProyecto.fechaconstitucionEA2.HasValue Then
                        Me.txtfechaconstitucion1.Text = TmpProyecto.fechaconstitucionEA2.Value.Day.ToString & "/" & TmpProyecto.fechaconstitucionEA2.Value.Month.ToString & "/" & TmpProyecto.fechaconstitucionEA2.Value.Year.ToString
                    Else
                        RequiredFieldValidator29.Validate()
                    End If
                    'rbfin1.DataBind()
                    'rbfin1.SelectedValue = TmpProyecto.TipoEA12.ToString
                    DropDownList3.DataBind()
                    DropDownList3.SelectedValue = TmpProyecto.TipoEA22.ToString
                    If TmpProyecto.TipoEA22 = 9 Then
                        Me.PnlConstOtro1.Visible = True
                        Me.TxtConstOtro1.Text = TmpProyecto.TipoEA2otro2
                    Else
                        Me.TxtConstOtro1.Text = ""
                        Me.PnlConstOtro1.Visible = False
                    End If
                End If
            End If
            If TmpProyecto.EntidadAsociada3 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada3.Trim("").Length > 0 Then
                    Me.pnlentidadasociada1.Visible = True
                    Me.EntidadAsociada3.Text = TmpProyecto.EntidadAsociada3
                    If TmpProyecto.fechaconstitucionEA3.HasValue Then
                        Me.txtfechaconstitucion2.Text = TmpProyecto.fechaconstitucionEA3.Value.Day.ToString & "/" & TmpProyecto.fechaconstitucionEA3.Value.Month.ToString & "/" & TmpProyecto.fechaconstitucionEA3.Value.Year.ToString
                    Else
                        RequiredFieldValidator33.Validate()
                    End If

                    'rbfin2.DataBind()
                    'rbfin2.SelectedValue = TmpProyecto.TipoEA13.ToString()
                    DropDownList4.DataBind()
                    DropDownList4.SelectedValue = TmpProyecto.TipoEA23.ToString
                    If TmpProyecto.TipoEA23 = 9 Then
                        Me.PnlConstOtro2.Visible = True
                        Me.TxtConstOtro2.Text = TmpProyecto.TipoEA2otro3
                    Else
                        Me.TxtConstOtro2.Text = ""
                        Me.PnlConstOtro2.Visible = False
                    End If
                End If
            End If

            If TmpProyecto.EntidadAsociada4 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada4.Trim("").Length > 0 Then
                    Me.pnlentidadasociada2.Visible = True
                End If
            End If

            If TmpProyecto.EntidadAsociada5 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada5.Trim("").Length > 0 Then
                    Me.pnlentidadasociada3.Visible = True
                End If
            End If

            If TmpProyecto.EntidadAsociada6 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada6.Trim("").Length > 0 Then
                    Me.pnlentidadasociada4.Visible = True
                End If
            End If

            If TmpProyecto.EntidadAsociada7 IsNot Nothing Then
                If TmpProyecto.EntidadAsociada7.Trim("").Length > 0 Then
                    Me.pnlentidadasociada5.Visible = True
                End If
            End If

        Else
            Me.PostulacionAsociada.Checked = False
            Me.pnlentidadasociada.Visible = False
            Me.EntidadAsociada1.Text = ""
            Me.fechaconstitucionEA1.Text = ""
            'Me.rbfin0.SelectedIndex = -1
            Me.DropDownList2.SelectedIndex = -1
            Me.pnlentidadasociada0.Visible = False
            Me.EntidadAsociada2.Text = ""
            Me.txtfechaconstitucion1.Text = ""
            'Me.rbfin2.SelectedIndex = -1
            Me.DropDownList3.SelectedIndex = -1
            Me.pnlentidadasociada1.Visible = False
            Me.EntidadAsociada3.Text = ""
            Me.txtfechaconstitucion2.Text = ""
            'Me.rbfin2.SelectedIndex = -1
            Me.DropDownList4.SelectedIndex = -1
        End If


    End Sub
    Private Sub getinfoentidad(ByVal opc As Integer)
        Dim TmpInfoEntidad As MFS_AEA_Proponente
        Me.email.Text = CMS.CMSHelper.CMSContext.CurrentUser.Email

        Dim existeproponente As Integer = 0
        Dim tmp_prp As MFS_AEA_Proponente

        existeproponente = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID).Count()

        If existeproponente > 0 Then
            tmp_prp = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
        End If

        If tmp_prp Is Nothing Then
            opc = 0
        Else
            opc = 1
        End If

        
        If opc = 0 Then
            'aun no se ha registrado la entidad.
            'recuperamos la informacion del usuario actual
            Me.acronimo.Text = CMS.CMSHelper.CMSContext.CurrentUser.LastName
            Me.nombre_entidad.Text = CMS.CMSHelper.CMSContext.CurrentUser.FirstName
            Me.PnlConstOtro.Visible = False
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
            'Me.ProvinciaEndtidad.DataBind()
            'Me.ProvinciaEndtidad.SelectedValue = TmpInfoEntidad.IdProvincia.ToString()
            Me.direccion.Text = TmpInfoEntidad.direccion
            Me.telefono.Text = TmpInfoEntidad.telefono
            Me.nom_legal.Text = TmpInfoEntidad.nom_legal
            Me.app_legal.Text = TmpInfoEntidad.app_legal
            Me.tipo_doc_legal.Text = TmpInfoEntidad.tipo_doc_legal
            Me.num_doc_legal.Text = TmpInfoEntidad.num_doc_legal
            Me.email_legal.Text = TmpInfoEntidad.email_legal
            Me.telefono_legal.Text = TmpInfoEntidad.telefono_legal
            If Not TmpInfoEntidad.fechaconstitucion.HasValue Then
                Me.RequiredFieldValidator18.Validate()
            Else
                Me.txtfechaconstitucion.Text = TmpInfoEntidad.fechaconstitucion.Value.Day.ToString & "/" & TmpInfoEntidad.fechaconstitucion.Value.Month.ToString & "/" & TmpInfoEntidad.fechaconstitucion.Value.Year.ToString


            End If
            If Not TmpInfoEntidad.TipoEP1.HasValue Then
                Me.RequiredFieldValidator19.Validate()
            Else
                Me.rbfin.SelectedValue = TmpInfoEntidad.TipoEP1.Value.ToString

            End If

            Me.PnlConstOtro.Visible = False
            If TmpInfoEntidad.TipoEP2.HasValue Then
                Me.DropDownList1.SelectedValue = TmpInfoEntidad.TipoEP2.Value.ToString
                If TmpInfoEntidad.TipoEP2.Value = 9 Then
                    Me.PnlConstOtro.Visible = True
                    Me.TxtConstOtro.Text = TmpInfoEntidad.TipoEP2Otro
                End If
                '
                '
            End If
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
                Me.btnInfoentidad.Text = "[+] Entidad Proponente"
                PnlregistroProyecto.Visible = False
                PnlBandejaProyecto.Visible = True
            Case 3
                Me.pnlRegInstitucion.Visible = False
                Me.btnInfoentidad.Text = "[+] Entidad Proponente"
            Case 4
                Me.pnlRegInstitucion.Visible = True
                Me.btnInfoentidad.Text = "[-] Entidad Proponente"
            Case 5
                Me.PnlregistroProyecto.Visible = False
                Me.Pnlinfoproponente.Visible = True
                Me.PnlBandejaProyecto.Visible = True
            Case 6
                Me.pnlRegInstitucion.Visible = True
                Me.btnInfoentidad.Text = "[-] Entidad Proponente"
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
        'tubicacion.IdProvincia = Integer.Parse(Me.ProvinciaEndtidad0.SelectedValue)
        tubicacion.PER_REGION = (From reg In cnx.PER_REGION Where reg.CodRegion = tubicacion.AmbitoRegion Select reg).Single()
        tubicacion.Pais = tubicacion.PER_REGION.PER_PAIS.Pais
        tubicacion.Region = tubicacion.PER_REGION.Region
        'tubicacion.Provincia = (From reg In cnx.PER_PROVINCIA Where reg.CodRegion = tubicacion.AmbitoRegion Select reg).Single().Provincia
        'tubicacion.Provincia = (From reg In tubicacion.PER_REGION.PER_PROVINCIA Where reg.IdProvincia = tubicacion.IdProvincia Select reg).Single().Provincia

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
    Private Function ValidaInfoProponente1() As Boolean
        Dim existeproponente As Integer = 0
        Dim tmp_prp As MFS_AEA_Proponente

        existeproponente = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID).Count()

        If existeproponente > 0 Then
            tmp_prp = (From t_prp In Me.cnx.MFS_AEA_Proponente Where t_prp.UserId = CMS.CMSHelper.CMSContext.CurrentUser.UserID Select t_prp).Single()
        End If

        If tmp_prp Is Nothing Then
            Return False
        Else
            Return True
        End If
        

    End Function
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
    Private Sub MensajeEtapa2()

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('../App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.pnlinfoetapa2.Attributes("style") = "position:fixed; top:50%; left:50%; width:30em; height:27em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.pnlinfoetapa2.Visible = True
        Me.Label4.Text = "Documentos para el proceso de la segunda etapa del concurso"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	myDTFI = New DateTimeFormatInfo()
        myDTFI.ShortDatePattern = "dd/MM/yyyy"

        Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        HttpContext.Current.Response.AddHeader("P3P", "CP = \' IDC DSP COR ADM DEVI Taií PSA PSD Ivaí IVDi CONI SU NUESTRA IND CNT \' ")
        Session("UserId") = CMS.CMSHelper.CMSContext.CurrentUser.UserID
        If validapermiso() Then
            If Page.IsPostBack Then
                grdubicacion()
                grdproyectos()
                admpaneles(Session("admpaneles"))

            Else
                'inicializacion
                Dim idcontrapartida As String = contrapartida.ClientID
                Dim idfinanciamiento As String = financiamientosolicitado.ClientID
                Dim idtotal As String = TotalProyecto.ClientID
                Dim onchange As String = "javascript: Changed( this," + idcontrapartida + "," + idtotal + ",2 );"
                Me.financiamientosolicitado.Attributes("onchange") = onchange
                onchange = "javascript: Changed( this," + idfinanciamiento + "," + idtotal + ",2 );"
                Me.contrapartida.Attributes("onchange") = onchange

                Me.rbfin.DataBind()
                Me.DropDownList1.DataBind()
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
                    'validar si el usario tiene un proyecto en segunda etapa
                    If (CMSContext.CurrentUser.IsInRole("AEAEtapa2", CMSContext.CurrentSiteName)) Then
                        Me.MensajeEtapa2()
                    End If
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
    Protected Function validaentidad() As Boolean
        Dim rslt As Boolean = True
        'fecha de constitucion
        Dim fechacons As Date
        'fechacons = Date.Parse(Me.txtfechaconstitucion.Text)
        'Dim date As Date    
        'Date.TryParseExact(Me.txtfechaconstitucion.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, fechacons)
        Dim myDTFI As DateTimeFormatInfo = New DateTimeFormatInfo()
        myDTFI.ShortDatePattern = "dd/MM/yyyy"
        Try
            fechacons = Date.Parse(Me.txtfechaconstitucion.Text, myDTFI)
        Catch ex As Exception
            Me.lblerror_fechacons.Text = "fecha de constitucion no valida, el formato de fecha es: dd/mm/yyyy"
            Me.lblerror_fechacons.Visible = True
            rslt = False
        End Try

        If fechacons > Date.Parse("12/09/2012") Then
            Me.lblerror_fechacons.Text = "La fecha de constitucion debe tener una antiguedad de minima de 2 años"
            Me.lblerror_fechacons.Visible = True
            rslt = False
        End If
        Dim dnumero As Double
        'If ((num_registro.Text.Length < 11) Or (Not Double.TryParse(num_registro.Text, dnumero))) Then
        '    Me.lblerror_rucproponente.Text = "El numero de RUC ingresado debe tener 11 caracteres numericos"
        '    Me.lblerror_rucproponente.Visible = True
        '    rslt = False
        'End If
        'If (Me.tipo_doc_legal.SelectedValue = "1") Then
        '    If ((num_doc_legal.Text.Length <> 8) Or (Not Double.TryParse(num_doc_legal.Text, dnumero))) Then
        '        Me.lblerror_dni.Text = "El numero de DNI ingresado debe tener 8 caracteres numericos"
        '        Me.lblerror_dni.Visible = True
        '        rslt = False
        '    End If
        'End If
        Return rslt

    End Function
    Protected Sub btngrabarentidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabarentidad.Click
        If Page.IsValid And validaentidad() Then
            SaveInfoEntidad()
            Mensaje("Sus datos se grabaron satisfactoriamente")
            Me.getinfoentidad(1)
            Me.lblmensajeproponente.Visible = False
            Me.lblmensajeproponente.Text = ""
            admpaneles(2)
            Session("admpaneles") = 2
        Else
            Mensaje("Los datos proporcionados no son correcto, revise los avisos en rojo")
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
            Me.Response.Redirect("~/sconvocatoria/PostularProyecto.aspx")
            'Me.Response.Redirect("~/SConvocatoria/SConvocatoria/FASERTConsultas.aspx")
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
                ctrlAdmin.CssClass = "btnworkflow"
                

                'VALIDACION DE CONVOCATORIA ACTIVA
                Dim activa As String
                activa = "Convocatoria 2014-I"
                If DirectCast(DirectCast(DirectCast(e.Row.DataItem, System.Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(3) = activa Then
                    ctrlAdmin.Enabled = True
                    ctrlAdmin.Text = "Presentar Perfil"
                    'validacion estado de proyecto
                    If DirectCast(DirectCast(DirectCast(e.Row.DataItem, System.Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(5) > 2 Then
                        ctrlAdmin.Enabled = True
                        ctrlAdmin.Text = "Presentar Propuesta"
                    '    ctrlAdmin.Text = "Consultar II Etapa"
                    Else
                        ctrlAdmin.Enabled = False
                    End If
                Else
                    ctrlAdmin.Enabled = False
                    e.Row.Enabled = False
                End If

        End Select
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

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Select Case e.Row.RowType

            Case DataControlRowType.DataRow

                Dim ctrlEliminar As ImageButton = CType(e.Row.Cells(6).Controls(0), ImageButton)
                ctrlEliminar.OnClientClick = "if( !confirm('¿Seguro que desea ELIMINAR esta Ubicación?')){return false;}"
                ctrlEliminar.ToolTip = "Eliminar Proyecto"

        End Select

    End Sub

    Protected Function validarmontos() As Boolean
        Dim mfinaciamiento, mcontrapartida, mcontramin As Double
        Dim vfinaciamiento, vcontrapartida As String
        vfinaciamiento = Me.financiamientosolicitado.Text.Replace(",", "")
        'vfinaciamiento = vfinaciamiento.Replace(".", ",")
        vcontrapartida = Me.contrapartida.Text.Replace(",", "")
        'vcontrapartida = vcontrapartida.Replace(".", ",")
        Dim rslt As Boolean = True
        Me.lblerror_financiamiento.Visible = False
        Me.lblerror_contrapartida.Visible = False

        mfinaciamiento = ValidationHelper.GetDouble(vfinaciamiento, 0, "en-US")
        mcontrapartida = ValidationHelper.GetDouble(vcontrapartida, 0, "en-US")
        If (mfinaciamiento < 100000 Or mfinaciamiento > 250000) Then
            Me.lblerror_financiamiento.Text = "Monto ingresado como Financiamiento es invalido, este debe estar entre: USD 100,000.00 y USD 250,000.00 "
            Me.lblerror_financiamiento.Visible = True
            rslt = False
        End If
        If (mcontrapartida <= 0) Then
            Me.lblerror_contrapartida.Text = "Monto ingresado como Contrapartida es invalido"
            Me.lblerror_contrapartida.Visible = True
            rslt = False
        End If
        mcontramin = mfinaciamiento
        If (mcontrapartida < mcontramin) Then
            Me.lblerror_contrapartida.Text = "Monto ingresado como Contrapartida es menor al 50% del Costo del Proyecto"
            Me.lblerror_contrapartida.Visible = True
            rslt = False
        End If
        Return rslt
    End Function
    Protected Sub btngrabar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar1.Click
        If Page.IsValid Then
            If (Me.TempUbicacion.Count > 0 And Me.validarmontos()) Then
                SaveProyecto()
                Mensajeperfil("Sus datos se grabaron satisfactoriamente")
                Actualiza()

            Else
                Mensaje("Se encontraron inconsistencias en los datos proporcionados, revise los textos en rojo." & "</br>" & " [Proyecto NO Guardado] ")
                Me.lblmensaje.Visible = True
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
        Me.Response.Redirect("../sconvocatoria/PostularProyecto.aspx")
    End Sub
    Private Sub Mensajeperfil(ByVal cad As String)

        Me.fondo.Attributes("style") = "position:fixed;width:100%;height:100%;top:0px;left:0px;background-image:url('../App_Themes/REC/REC_imagenes/black.png');z-index:2;display:block"
        Me.fondo.Visible = True
        Me.Panel4.Attributes("style") = "position:fixed; top:50%; left:50%; width:30em; height:7em; margin-top: -9em; margin-left: -15em; z-index:3; border:3px solid #d2b48c; padding:20px; background-color:#fafad2; display:block;   "
        Me.Panel4.Visible = True
        Me.Label3.Text = cad
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.fondo.Visible = False
        Me.Panel4.Visible = False
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedValue = "9" Then
            Me.PnlConstOtro.Visible = True
            Me.RequiredFieldValidator17.Validate()
            Me.RequiredFieldValidator18.Validate()
            Me.RequiredFieldValidator19.Validate()
        Else
            Me.PnlConstOtro.Visible = False
            Me.RequiredFieldValidator18.Validate()
            Me.RequiredFieldValidator19.Validate()
            Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub PostulacionAsociada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PostulacionAsociada.CheckedChanged
        If Me.PostulacionAsociada.Checked Then
            Me.pnlentidadasociada.Visible = True
        Else
            Me.pnlentidadasociada.Visible = False
            Me.EntidadAsociada1.Text = ""
            Me.fechaconstitucionEA1.Text = ""
            'Me.rbfin0.SelectedIndex = -1
            Me.DropDownList2.SelectedIndex = -1
            Me.pnlentidadasociada0.Visible = False
            Me.EntidadAsociada2.Text = ""
            Me.txtfechaconstitucion1.Text = ""
            'Me.rbfin2.SelectedIndex = -1
            Me.DropDownList3.SelectedIndex = -1
            Me.pnlentidadasociada1.Visible = False
            Me.EntidadAsociada3.Text = ""
            Me.txtfechaconstitucion2.Text = ""
            'Me.rbfin2.SelectedIndex = -1
            Me.DropDownList4.SelectedIndex = -1
        End If
    End Sub

    Protected Sub btnEA1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEA1.Click
        If btnEA1.Text = "Agregar Entidad Asociada" Then
            Me.pnlentidadasociada0.Visible = True
        End If
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.pnlentidadasociada1.Visible = True
        Me.Button10.Visible = False
        Me.Button11.Visible = True
        Me.Button9.Visible = True
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.pnlentidadasociada1.Visible = False
        Me.Button10.Visible = True
    End Sub

    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.pnlentidadasociada0.Visible = False

    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        If Me.DropDownList2.SelectedValue = "9" Then
            Me.PnlConstOtro0.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.PnlConstOtro0.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.PnlConstOtro1.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.PnlConstOtro1.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub
    Protected Sub financiamientosolicitado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles financiamientosolicitado.TextChanged
        Dim aporte, contrapartida As Double
        Try
            aporte = Double.Parse(Me.financiamientosolicitado.Text)
            contrapartida = Double.Parse(Me.contrapartida.Text)
            Me.TotalProyecto.Text = (aporte + contrapartida).ToString("f2")
        Catch ex As Exception
            lblerror_financiamiento.Text = "Debe ingresar un monto entre 100,000.00 y 250,000.00"
            lblerror_financiamiento.Visible = True
        End Try

    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.pnlentidadasociada2.Visible = True
        Me.Button9.Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.pnlentidadasociada2.Visible = False
        Me.Button9.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.pnlentidadasociada3.Visible = True
        Me.Button2.Visible = False
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.pnlentidadasociada3.Visible = False
        Me.Button2.Visible = True
    End Sub

    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        Me.pnlentidadasociada4.Visible = False
        Me.Button12.Visible = True
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.pnlentidadasociada4.Visible = True
        Me.Button12.Visible = False
    End Sub

    Protected Sub Button16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button16.Click
        Me.pnlentidadasociada5.Visible = False
        Me.Button14.Visible = True
    End Sub

    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.pnlentidadasociada5.Visible = True
        Me.Button14.Visible = False
    End Sub

    Protected Sub DropDownList4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList4.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.PnlConstOtro2.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.PnlConstOtro2.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub DropDownList5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList5.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.Panel6.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.Panel6.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub DropDownList6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList6.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.Panel7.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.Panel7.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub DropDownList7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList7.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.Panel8.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.Panel8.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub DropDownList8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList8.SelectedIndexChanged
        If Me.DropDownList3.SelectedValue = "9" Then
            Me.Panel9.Visible = True
            'Me.RequiredFieldValidator17.Validate()
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
        Else
            Me.Panel9.Visible = False
            'Me.RequiredFieldValidator18.Validate()
            'Me.RequiredFieldValidator19.Validate()
            'Me.RequiredFieldValidator17.IsValid = True
        End If
    End Sub

    Protected Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        Me.fondo.Visible = False
        Me.pnlinfoetapa2.Visible = False
    End Sub
End Class
