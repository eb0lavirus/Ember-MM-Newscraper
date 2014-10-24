﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports System.IO
Imports EmberAPI

Public Class frmTMDBTrailerSettingsHolder

#Region "Fields"

    Private _api As String
    Private _language As String

#End Region 'Fields

#Region "Properties"

    Public Property API() As String
        Get
            Return Me._api
        End Get
        Set(ByVal value As String)
            Me._api = value
        End Set
    End Property

    Public Property Lang() As String
        Get
            Return Me._language
        End Get
        Set(ByVal value As String)
            Me._language = value
        End Set
    End Property

#End Region 'Properties

#Region "Events"

    Public Event ModuleSettingsChanged()

    Public Event SetupScraperChanged(ByVal state As Boolean, ByVal difforder As Integer)

    Public Event SetupNeedsRestart()
#End Region 'Events

#Region "Methods"
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim order As Integer = ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.AssemblyName = TMDB_Trailer._AssemblyName).ModuleOrder
        If order < ModulesManager.Instance.externalScrapersModules_Trailer_Movie.Count - 1 Then
            ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.ModuleOrder = order + 1).ModuleOrder = order
            ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.AssemblyName = TMDB_Trailer._AssemblyName).ModuleOrder = order + 1
            RaiseEvent SetupScraperChanged(cbEnabled.Checked, 1)
            orderChanged()
        End If
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim order As Integer = ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.AssemblyName = TMDB_Trailer._AssemblyName).ModuleOrder
        If order > 0 Then
            ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.ModuleOrder = order - 1).ModuleOrder = order
            ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.AssemblyName = TMDB_Trailer._AssemblyName).ModuleOrder = order - 1
            RaiseEvent SetupScraperChanged(cbEnabled.Checked, -1)
            orderChanged()
        End If
    End Sub

    Private Sub cbEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEnabled.CheckedChanged
        RaiseEvent SetupScraperChanged(cbEnabled.Checked, 0)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.SetUp()
    End Sub

    Sub orderChanged()
        Dim order As Integer = ModulesManager.Instance.externalScrapersModules_Trailer_Movie.FirstOrDefault(Function(p) p.AssemblyName = TMDB_Trailer._AssemblyName).ModuleOrder
        If ModulesManager.Instance.externalScrapersModules_Trailer_Movie.Count > 0 Then
            btnDown.Enabled = (order < ModulesManager.Instance.externalScrapersModules_Trailer_Movie.Count - 1)
            btnUp.Enabled = (order > 0)
        Else
            btnDown.Enabled = False
            btnUp.Enabled = False
        End If
    End Sub

    Sub SetUp()
        Me.Label3.Text = Master.eLang.GetString(168, "Scrape Order")
        Me.cbEnabled.Text = Master.eLang.GetString(774, "Enabled")
        Me.Label1.Text = String.Format(Master.eLang.GetString(790, "These settings are specific to this module.{0}Please refer to the global settings for more options."), vbCrLf)
        Me.Label18.Text = Master.eLang.GetString(870, "TMDB API Key")
        Me.gbSettings.Text = Master.eLang.GetString(937, "TMDB")
        Me.chkFallBackEng.Text = Master.eLang.GetString(922, "Fall back on english")
        Me.Label2.Text = Master.eLang.GetString(741, "Preferred Language:")
        Me.btnUnlockAPI.Text = Master.eLang.GetString(1188, "Use my own API key")
        Me.lblEMMAPI.Text = Master.eLang.GetString(1189, "Ember Media Manager API key")
    End Sub

    Private Sub txtTMDBApiKey_TextEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTMDBApiKey.Enter
        _api = txtTMDBApiKey.Text
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub cbTMDBPrefLanguage_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTMDBPrefLanguage.SelectedIndexChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkFallBackEng_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFallBackEng.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub btnUnlockAPI_Click(sender As Object, e As EventArgs) Handles btnUnlockAPI.Click
        Me.lblEMMAPI.Visible = False
        Me.txtTMDBApiKey.Enabled = True
        Me.txtTMDBApiKey.Visible = True
    End Sub

#End Region 'Methods

End Class