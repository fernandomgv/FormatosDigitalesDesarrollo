Imports System.Linq
Imports System.Collections.Generic
Partial Class CMSWebParts_MFS_PerfilCloseConfirmation
    Inherits System.Web.UI.Page
    Private cnx As MFSDataContext = New MFSDataContext
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tmpproy As New MFSProyecto
        Dim idproyecto As Integer
        Dim pais As PER_PAIS
        Dim archivo As MFSFileProyecto
        Dim cierre As MFSCierreWorkFlow
        If Session("idproyecto") IsNot Nothing Then
            idproyecto = Integer.Parse(Session("idproyecto").ToString)
            tmpproy = (From t_prp In cnx.MFSProyecto Where t_prp.IdProyecto = idproyecto Select t_prp).Single()
            Me.lblcoord.text = tmpproy.AppCoord & ", " & tmpproy.NomCoord
            Me.lblcargo.text = tmpproy.CargoCoord
            Me.lblentidad.Text = tmpproy.MFS_AEA_Proponente.nombre_entidad
            Me.lblcodpro.Text = tmpproy.CodProyecto
            Me.lbltitulopro.Text = tmpproy.NombreProyecto
            Me.lblconvocatoria.Text = tmpproy.MFSConvocatoria.DesConvocatoria
            pais = (From t_p In cnx.PER_PAIS Where t_p.CodPais = tmpproy.AmbitoPais Select t_p).Single()
            Me.lblpaispos.Text = pais.Pais
            archivo = (From t_prp In cnx.MFSFileProyecto Where t_prp.IdProyecto = idproyecto And t_prp.IdTipo = 1 And t_prp.IdWorkFlow = 1 Select t_prp).Single()
            Me.lblarchivo.Text = archivo.TituloFile
            cierre = (From t_prp In cnx.MFSCierreWorkFlow Where t_prp.IdProyecto = idproyecto And t_prp.IdWorkFlow = 1 Select t_prp).Single()
            Me.lblfeccierre.Text = tofechahora(cierre.fechacierre)
        End If

    End Sub
End Class
