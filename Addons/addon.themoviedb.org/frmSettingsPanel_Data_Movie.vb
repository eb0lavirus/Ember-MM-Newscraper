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

Imports EmberAPI

Public Class frmSettingsPanel_Data_Movie

#Region "Events"

    Public Event NeedsRestart()
    Public Event SettingsChanged()
    Public Event StateChanged(ByVal State As Boolean, ByVal DiffOrder As Integer)

#End Region 'Events 

#Region "Methods"

    Public Sub New()
        InitializeComponent()
        Setup()
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        RaiseEvent StateChanged(chkEnabled.Checked, 1)
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        RaiseEvent StateChanged(chkEnabled.Checked, -1)
    End Sub

    Private Sub btnUnlockAPI_Click(sender As Object, e As EventArgs) Handles btnUnlockAPI.Click
        If btnUnlockAPI.Text = Master.eLang.GetString(1188, "Use my own API key") Then
            btnUnlockAPI.Text = Master.eLang.GetString(443, "Use embedded API Key")
            lblEMMAPI.Visible = False
            txtApiKey.Enabled = True
        Else
            btnUnlockAPI.Text = Master.eLang.GetString(1188, "Use my own API key")
            lblEMMAPI.Visible = True
            txtApiKey.Enabled = False
            txtApiKey.Text = String.Empty
        End If
    End Sub

    Private Sub cbEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckedChanged
        RaiseEvent StateChanged(chkEnabled.Checked, 0)
    End Sub

    Private Sub chkWriters_CheckedChanged(sender As Object, e As EventArgs) Handles chkWriters.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkDirector_CheckedChanged(sender As Object, e As EventArgs) Handles chkDirectors.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkCast_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkActors.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkCollectionID_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCollection.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkGenre_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGenres.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkGetAdult_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkGetAdultItems.CheckedChanged, chkSearchDeviant.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkSearchDeviant_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSearchDeviant.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkMPAA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCertifications.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkOriginalTitle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkOriginalTitle.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkPlot_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPlot.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkRating_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRating.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkRelease_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPremiered.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkRuntime_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRuntime.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkStudio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkStudios.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkTagline_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTagline.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkTitle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTitle.CheckedChanged, chkTags.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkCountry_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCountries.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkTrailer_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkTrailer.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkVotes_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkYear_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub chkFallBackEng_CheckedChanged(sender As Object, e As EventArgs) Handles chkFallBackEng.CheckedChanged
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub cbTMDBPrefLanguage_SelectedIndexChanged(sender As Object, e As EventArgs)
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub txtTMDBApiKey_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtApiKey.TextChanged
        RaiseEvent SettingsChanged()
    End Sub

    Public Sub OrderChanged(ByVal OrderState As Containers.SettingsPanel.OrderState)
        btnDown.Enabled = OrderState.Position < OrderState.TotalCount - 1
        btnUp.Enabled = OrderState.Position > 0
    End Sub

    Private Sub pbTMDBApiKeyInfo_Click(sender As Object, e As EventArgs) Handles pbTMDBApiKeyInfo.Click
        Functions.Launch(My.Resources.urlAPIKey)
    End Sub

    Private Sub Setup()
        btnUnlockAPI.Text = Master.eLang.GetString(1188, "Use my own API key")
        chkActors.Text = Master.eLang.GetString(231, "Actors")
        chkCertifications.Text = Master.eLang.GetString(56, "Certifications")
        chkCollection.Text = Master.eLang.GetString(424, "Collection")
        chkCountries.Text = Master.eLang.GetString(237, "Countries")
        chkDirectors.Text = Master.eLang.GetString(940, "Directors")
        chkEnabled.Text = Master.eLang.GetString(774, "Enabled")
        chkFallBackEng.Text = Master.eLang.GetString(922, "Fallback to english")
        chkGenres.Text = Master.eLang.GetString(725, "Genres")
        chkGetAdultItems.Text = Master.eLang.GetString(1046, "Include Adult Items")
        chkOriginalTitle.Text = Master.eLang.GetString(302, "Original Title")
        chkPlot.Text = Master.eLang.GetString(65, "Plot")
        chkPremiered.Text = Master.eLang.GetString(724, "Premiered")
        chkRating.Text = Master.eLang.GetString(400, "Rating")
        chkRuntime.Text = Master.eLang.GetString(238, "Runtime")
        chkSearchDeviant.Text = Master.eLang.GetString(98, "Search -/+ 1 year if no search result was found")
        chkStudios.Text = Master.eLang.GetString(226, "Studios")
        chkTagline.Text = Master.eLang.GetString(397, "Tagline")
        chkTags.Text = Master.eLang.GetString(243, "Tags")
        chkTitle.Text = Master.eLang.GetString(21, "Title")
        chkTrailer.Text = Master.eLang.GetString(151, "Trailer")
        chkWriters.Text = Master.eLang.GetString(394, "Writers")
        gbScraperFieldsOpts.Text = Master.eLang.GetString(791, "Scraper Fields - Scraper specific")
        gbScraperOpts.Text = Master.eLang.GetString(1186, "Scraper Options")
        lblApiKey.Text = String.Concat(Master.eLang.GetString(870, "TMDB API Key"), ":")
        lblEMMAPI.Text = Master.eLang.GetString(1189, "Ember Media Manager Embedded API Key")
        lblInfoBottom.Text = String.Format(Master.eLang.GetString(790, "These settings are specific to this module.{0}Please refer to the global settings for more options."), Environment.NewLine)
        lblScraperOrder.Text = Master.eLang.GetString(168, "Scrape Order")
    End Sub

#End Region 'Methods

End Class