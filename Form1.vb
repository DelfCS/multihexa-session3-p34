Imports System.Net.Http.Headers
Imports System.Net.Mime.MediaTypeNames
Imports System.Reflection.Metadata.Ecma335



Public Class Form1

    ' Déclaration de mes variables Globales
    Public valueGenerator As System.Random = New System.Random()

    Public nbrCartes As Integer ' Nbr cartes sorties
    Public arrayCartes(10) As String ' Tableau des cartes sorties
    Public mainDuJoueur(4, 1) ' Main du joueur

    Public miseActuelle = 0 ' Mise Actuelle
    Public creditUtilisateur = 200 ' Crédits de départ

    Public Tab As Integer = 1 ' Tabulation ( Btn commencer, miser, clear )

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        hideComponents()
        deActivateCardCheckBoxes()

    End Sub

    Private Sub hideComponents()

        lblCredit.Hide()
        lblBanque.Hide()
        lblMise.Hide()

        numericBet.Hide()
        btnMiser.Hide()

        Panel1.Hide()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()

        deActivateCardCheckBoxes()

    End Sub

    Private Sub showComponents()

        btnCommencer.Hide()

        lblCredit.Show()
        lblBanque.Show()
        lblMise.Show()

        numericBet.Show()
        btnMiser.Show()

        Panel1.Show()
        Panel2.Show()
        Panel3.Show()
        Panel4.Show()
        Panel5.Show()
        Panel6.Show()

    End Sub

    ' Bouton commencer, affiche le jeu
    Private Sub btnCommencer_Click(sender As Object, e As EventArgs) Handles btnCommencer.Click
        showComponents()
    End Sub

    ' Bouton jouer, continuer, clear
    Private Sub btnMiser_Click(sender As Object, e As EventArgs) Handles btnMiser.Click

        Select Case Tab
            Case 1 ' AU PREMIER CLICK : On paye la mise, on lance les cartes

                initializeHand()
                activateCardCheckBoxes()

                miseActuelle = numericBet.Value
                creditUtilisateur = creditUtilisateur - miseActuelle
                lblCredit.Text = creditUtilisateur.ToString()

                numericBet.Enabled = False

                btnMiser.Text = "Continuer"
                Tab = 2


            Case 2 ' AU DEUXIEME CLICK : On change les cartes non checked, on évalue la main, on rend le gain au joueur dans le cas ou il a lieu

                switchCards()
                deActivateCardCheckBoxes()

                evaluateHand()

                btnMiser.Text = "CLEAR"
                Tab = 3


            Case 3 ' AU TROISIEME CLICK : On revient au départ, avec un jeu cleared & l'option de selection une mise puis jouer

                viderLblCartes()
                numericBet.Enabled = True


                btnMiser.Text = "Miser"
                Tab = 1

        End Select


    End Sub

    ' Fonction qui valide que la carte pigée n'est pas une carte déjà pigée
    Public Function validerCarte(maCarte As String, nbrCartes As Integer) As Boolean

        Dim carteValide = True

        For i = 0 To nbrCartes
            If (arrayCartes(i) = maCarte) Then
                carteValide = False
            End If
        Next

        Return carteValide


    End Function

    ' Vide simplement les labels qui affichent les valeurs des cartes
    Public Sub viderLblCartes()

        txtCarte11.Text = ""
        txtCarte12.Text = ""
        txtCarte13.Text = ""
        txtCarte21.Text = ""
        txtCarte22.Text = ""
        txtCarte23.Text = ""
        txtCarte31.Text = ""
        txtCarte32.Text = ""
        txtCarte33.Text = ""
        txtCarte41.Text = ""
        txtCarte42.Text = ""
        txtCarte43.Text = ""
        txtCarte51.Text = ""
        txtCarte52.Text = ""
        txtCarte53.Text = ""

    End Sub
    ' Initialise la première main ( Après avoir cliqué sur le bouton MISER )
    Public Sub initializeHand()

        ' Réinitialise les cartes déjà pijées ( DECK SHUFFLE )
        For i = 0 To 10
            arrayCartes(i) = ""
        Next
        nbrCartes = 0

        Static valueGenerator As System.Random = New System.Random()


        ' Carte #1 
        Dim carteNonValide = True
        While (carteNonValide)
            Dim c As Integer = valueGenerator.Next(0, 4)
            Dim v As Integer = valueGenerator.Next(0, 13)
            Dim maCarte As String = c.ToString() + v.ToString()

            If (validerCarte(maCarte, nbrCartes)) Then
                arrayCartes(nbrCartes) = maCarte

                mainDuJoueur(0, 0) = c
                mainDuJoueur(0, 1) = v

                carteNonValide = False
            End If

        End While

        nbrCartes += 1


        ' Carte #2
        carteNonValide = True

        While (carteNonValide)
            Dim c As Integer = valueGenerator.Next(0, 4)
            Dim v As Integer = valueGenerator.Next(0, 13)
            Dim maCarte As String = c.ToString() + v.ToString()

            If (validerCarte(maCarte, nbrCartes)) Then
                arrayCartes(nbrCartes) = maCarte

                mainDuJoueur(1, 0) = c
                mainDuJoueur(1, 1) = v

                carteNonValide = False
            End If

        End While

        nbrCartes += 1


        ' CARTE #3
        carteNonValide = True

        While (carteNonValide)
            Dim c As Integer = valueGenerator.Next(0, 4)
            Dim v As Integer = valueGenerator.Next(0, 13)
            Dim maCarte As String = c.ToString() + v.ToString()

            If (validerCarte(maCarte, nbrCartes)) Then
                arrayCartes(nbrCartes) = maCarte

                mainDuJoueur(2, 0) = c
                mainDuJoueur(2, 1) = v

                carteNonValide = False
            End If

        End While

        nbrCartes += 1


        ' CARTE #4
        carteNonValide = True

        While (carteNonValide)
            Dim c As Integer = valueGenerator.Next(0, 4)
            Dim v As Integer = valueGenerator.Next(0, 13)
            Dim maCarte As String = c.ToString() + v.ToString()

            If (validerCarte(maCarte, nbrCartes)) Then
                arrayCartes(nbrCartes) = maCarte

                mainDuJoueur(3, 0) = c
                mainDuJoueur(3, 1) = v

                carteNonValide = False
            End If

        End While

        nbrCartes += 1


        ' CARTE #5
        carteNonValide = True

        While (carteNonValide)
            Dim c As Integer = valueGenerator.Next(0, 4)
            Dim v As Integer = valueGenerator.Next(0, 13)
            Dim maCarte As String = c.ToString() + v.ToString()

            If (validerCarte(maCarte, nbrCartes)) Then
                arrayCartes(nbrCartes) = maCarte

                mainDuJoueur(4, 0) = c
                mainDuJoueur(4, 1) = v

                carteNonValide = False
            End If

        End While

        nbrCartes += 1


        ' Assigne la valeur 0 ou 13 aux aces, selon les autres cartes
        assignAcesValue()

        ' Trie nos cartes dans un ordre croissant de valeur
        sort()

        ' Affiche les valeur & couleurs des cartes sur les paneaux
        assosiateImage()


    End Sub

    ' Trie les cartes dans un ordre croissant de valeur
    Private Sub sort()

        Dim emptyArray(2) As Integer

        ' HOME MADE SORT - Peut-etre pas le plus efficace, mais c'est homemade haha !

        For i = 0 To 3
            If (mainDuJoueur(i, 1) > mainDuJoueur(i + 1, 1)) Then
                emptyArray(0) = mainDuJoueur(i + 1, 0)
                emptyArray(1) = mainDuJoueur(i + 1, 1)

                mainDuJoueur(i + 1, 0) = mainDuJoueur(i, 0)
                mainDuJoueur(i + 1, 1) = mainDuJoueur(i, 1)

                mainDuJoueur(i, 0) = emptyArray(0)
                mainDuJoueur(i, 1) = emptyArray(1)

                For y = 0 To 2
                    If (mainDuJoueur(y, 1) > mainDuJoueur(y + 1, 1)) Then
                        emptyArray(0) = mainDuJoueur(y + 1, 0)
                        emptyArray(1) = mainDuJoueur(y + 1, 1)

                        mainDuJoueur(y + 1, 0) = mainDuJoueur(y, 0)
                        mainDuJoueur(y + 1, 1) = mainDuJoueur(y, 1)

                        mainDuJoueur(y, 0) = emptyArray(0)
                        mainDuJoueur(y, 1) = emptyArray(1)
                    End If

                    For j = 0 To 1
                        If (mainDuJoueur(j, 1) > mainDuJoueur(j + 1, 1)) Then
                            emptyArray(0) = mainDuJoueur(j + 1, 0)
                            emptyArray(1) = mainDuJoueur(j + 1, 1)

                            mainDuJoueur(j + 1, 0) = mainDuJoueur(j, 0)
                            mainDuJoueur(j + 1, 1) = mainDuJoueur(j, 1)

                            mainDuJoueur(j, 0) = emptyArray(0)
                            mainDuJoueur(j, 1) = emptyArray(1)
                        End If

                        If (mainDuJoueur(0, 1) > mainDuJoueur(0 + 1, 1)) Then
                            emptyArray(0) = mainDuJoueur(0 + 1, 0)
                            emptyArray(1) = mainDuJoueur(0 + 1, 1)

                            mainDuJoueur(0 + 1, 0) = mainDuJoueur(0, 0)
                            mainDuJoueur(0 + 1, 1) = mainDuJoueur(0, 1)

                            mainDuJoueur(0, 0) = emptyArray(0)
                            mainDuJoueur(0, 1) = emptyArray(1)
                        End If

                    Next
                Next
            End If
        Next


    End Sub

    ' Désactive l'option d'utiliser les checkBoxes ( cardChanging )
    Private Sub deActivateCardCheckBoxes()

        checkCarte1.Enabled = False
        checkCarte2.Enabled = False
        checkCarte3.Enabled = False
        checkCarte4.Enabled = False
        checkCarte5.Enabled = False

    End Sub

    ' Active l'option d'utiliser les checkBoxes ( cardChanging )
    Private Sub activateCardCheckBoxes()

        checkCarte1.Enabled = True
        checkCarte2.Enabled = True
        checkCarte3.Enabled = True
        checkCarte4.Enabled = True
        checkCarte5.Enabled = True

    End Sub

    ' Associe le bon visuel sur le jeu, pour chaque cartes
    Private Sub assosiateImage() ' ♠♠ ♥♡ ♣♣ ♦♦


        ' *** CARTE 1 ***

        ' CUBS
        If (mainDuJoueur(0, 0) = 0) Then
            txtCarte11.Text = "♣"
            txtCarte12.Text = "♣"
            txtCarte13.Text = "♣"

            ' SPADES
        ElseIf (mainDuJoueur(0, 0) = 1) Then
            txtCarte11.Text = "♠"
            txtCarte12.Text = "♠"
            txtCarte13.Text = "♠"

            ' HEARTHS
        ElseIf (mainDuJoueur(0, 0) = 2) Then
            txtCarte11.Text = "♥"
            txtCarte12.Text = "♥"
            txtCarte13.Text = "♥"

            ' DIAMONDS
        ElseIf (mainDuJoueur(0, 0) = 3) Then
            txtCarte11.Text = "♦"
            txtCarte12.Text = "♦"
            txtCarte13.Text = "♦"
        End If


        ' ACE
        If (mainDuJoueur(0, 1) = 0 Or mainDuJoueur(0, 1) = 13) Then
            txtCarte11.Text += "A"
            txtCarte12.Text += "A"

            ' Valeur entre 2 & 9
        ElseIf (mainDuJoueur(0, 1) >= 1 And mainDuJoueur(0, 1) <= 8) Then
            txtCarte11.Text += (mainDuJoueur(0, 1) + 1).ToString()
            txtCarte12.Text += (mainDuJoueur(0, 1) + 1).ToString()

            ' TEN
        ElseIf (mainDuJoueur(1, 1) = 9) Then
            txtCarte11.Text += "T"
            txtCarte12.Text += "T"

            ' JACK
        ElseIf (mainDuJoueur(0, 1) = 10) Then
            txtCarte11.Text += "J"
            txtCarte12.Text += "J"

            ' QUEEN
        ElseIf (mainDuJoueur(0, 1) = 11) Then
            txtCarte11.Text += "Q"
            txtCarte12.Text += "Q"

            ' KING
        ElseIf (mainDuJoueur(0, 1) = 12) Then
            txtCarte11.Text += "K"
            txtCarte12.Text += "K"

        End If


        ' *** CARTE 2 ***

        ' CUBS
        If (mainDuJoueur(1, 0) = 0) Then
            txtCarte21.Text = "♣"
            txtCarte22.Text = "♣"
            txtCarte23.Text = "♣"

            ' SPADES
        ElseIf (mainDuJoueur(1, 0) = 1) Then
            txtCarte21.Text = "♠"
            txtCarte22.Text = "♠"
            txtCarte23.Text = "♠"

            ' HEARTHS
        ElseIf (mainDuJoueur(1, 0) = 2) Then
            txtCarte21.Text = "♥"
            txtCarte22.Text = "♥"
            txtCarte23.Text = "♥"

            ' DIAMONDS
        ElseIf (mainDuJoueur(1, 0) = 3) Then
            txtCarte21.Text = "♦"
            txtCarte22.Text = "♦"
            txtCarte23.Text = "♦"

        End If

        ' ACE
        If (mainDuJoueur(1, 1) = 0 Or mainDuJoueur(1, 1) = 13) Then
            txtCarte21.Text += "A"
            txtCarte22.Text += "A"

            ' Valeur entre 2 & 9
        ElseIf (mainDuJoueur(1, 1) >= 1 And mainDuJoueur(1, 1) <= 8) Then
            txtCarte21.Text += (mainDuJoueur(1, 1) + 1).ToString()
            txtCarte22.Text += (mainDuJoueur(1, 1) + 1).ToString()

            ' TEN
        ElseIf (mainDuJoueur(1, 1) = 9) Then
            txtCarte21.Text += "T"
            txtCarte22.Text += "T"

            ' JACK
        ElseIf (mainDuJoueur(1, 1) = 10) Then
            txtCarte21.Text += "J"
            txtCarte22.Text += "J"

            ' QUEEN
        ElseIf (mainDuJoueur(1, 1) = 11) Then
            txtCarte21.Text += "Q"
            txtCarte22.Text += "Q"

            ' KING
        ElseIf (mainDuJoueur(1, 1) = 12) Then
            txtCarte21.Text += "K"
            txtCarte22.Text += "K"

        End If


        ' *** CARTE 3 ***

        ' CUBS
        If (mainDuJoueur(2, 0) = 0) Then
            txtCarte31.Text = "♣"
            txtCarte32.Text = "♣"
            txtCarte33.Text = "♣"

            ' SPADES
        ElseIf (mainDuJoueur(2, 0) = 1) Then
            txtCarte31.Text = "♠"
            txtCarte32.Text = "♠"
            txtCarte33.Text = "♠"

            ' HEARTHS
        ElseIf (mainDuJoueur(2, 0) = 2) Then
            txtCarte31.Text = "♥"
            txtCarte32.Text = "♥"
            txtCarte33.Text = "♥"

            ' DIAMONDS
        ElseIf (mainDuJoueur(2, 0) = 3) Then
            txtCarte31.Text = "♦"
            txtCarte32.Text = "♦"
            txtCarte33.Text = "♦"

        End If

        ' ACE
        If (mainDuJoueur(2, 1) = 0 Or mainDuJoueur(2, 1) = 13) Then
            txtCarte31.Text += "A"
            txtCarte32.Text += "A"

            ' Valeur entre 2 & 10
        ElseIf (mainDuJoueur(2, 1) >= 1 And mainDuJoueur(2, 1) <= 8) Then
            txtCarte31.Text += (mainDuJoueur(2, 1) + 1).ToString()
            txtCarte32.Text += (mainDuJoueur(2, 1) + 1).ToString()

            ' TEN
        ElseIf (mainDuJoueur(2, 1) = 9) Then
            txtCarte31.Text += "T"
            txtCarte32.Text += "T"

            ' JACK
        ElseIf (mainDuJoueur(2, 1) = 10) Then
            txtCarte31.Text += "J"
            txtCarte32.Text += "J"

            ' QUEEN
        ElseIf (mainDuJoueur(2, 1) = 11) Then
            txtCarte31.Text += "Q"
            txtCarte32.Text += "Q"

            ' KING
        ElseIf (mainDuJoueur(2, 1) = 12) Then
            txtCarte31.Text += "K"
            txtCarte32.Text += "K"

        End If


        ' *** CARTE 4 ***

        ' CUBS
        If (mainDuJoueur(3, 0) = 0) Then
            txtCarte41.Text = "♣"
            txtCarte42.Text = "♣"
            txtCarte43.Text = "♣"

            ' SPADES
        ElseIf (mainDuJoueur(3, 0) = 1) Then
            txtCarte41.Text = "♠"
            txtCarte42.Text = "♠"
            txtCarte43.Text = "♠"

            ' HEARTHS
        ElseIf (mainDuJoueur(3, 0) = 2) Then
            txtCarte41.Text = "♥"
            txtCarte42.Text = "♥"
            txtCarte43.Text = "♥"

            ' DIAMONDS
        ElseIf (mainDuJoueur(3, 0) = 3) Then
            txtCarte41.Text = "♦"
            txtCarte42.Text = "♦"
            txtCarte43.Text = "♦"

        End If

        ' ACE
        If (mainDuJoueur(3, 1) = 0 Or mainDuJoueur(3, 1) = 13) Then
            txtCarte41.Text += "A"
            txtCarte42.Text += "A"

            ' Valeur entre 2 & 9
        ElseIf (mainDuJoueur(3, 1) >= 1 And mainDuJoueur(3, 1) <= 8) Then
            txtCarte41.Text += (mainDuJoueur(3, 1) + 1).ToString()
            txtCarte42.Text += (mainDuJoueur(3, 1) + 1).ToString()

            ' TEN
        ElseIf (mainDuJoueur(3, 1) = 9) Then
            txtCarte41.Text += "T"
            txtCarte42.Text += "T"

            ' JACK
        ElseIf (mainDuJoueur(3, 1) = 10) Then
            txtCarte41.Text += "J"
            txtCarte42.Text += "J"

            ' QUEEN
        ElseIf (mainDuJoueur(3, 1) = 11) Then
            txtCarte41.Text += "Q"
            txtCarte42.Text += "Q"

            ' KING
        ElseIf (mainDuJoueur(3, 1) = 12) Then
            txtCarte41.Text += "K"
            txtCarte42.Text += "K"

        End If


        ' *** CARTE 5 ***

        ' CUBS
        If (mainDuJoueur(4, 0) = 0) Then
            txtCarte51.Text = "♣"
            txtCarte52.Text = "♣"
            txtCarte53.Text = "♣"

            ' SPADES
        ElseIf (mainDuJoueur(4, 0) = 1) Then
            txtCarte51.Text = "♠"
            txtCarte52.Text = "♠"
            txtCarte53.Text = "♠"

            ' HEARTHS
        ElseIf (mainDuJoueur(4, 0) = 2) Then
            txtCarte51.Text = "♥"
            txtCarte52.Text = "♥"
            txtCarte53.Text = "♥"

            ' DIAMONDS
        ElseIf (mainDuJoueur(4, 0) = 3) Then
            txtCarte51.Text = "♦"
            txtCarte52.Text = "♦"
            txtCarte53.Text = "♦"

        End If

        ' ACE
        If (mainDuJoueur(4, 1) = 0 Or mainDuJoueur(4, 1) = 13) Then
            txtCarte51.Text += "A"
            txtCarte52.Text += "A"

            ' Valeur entre 2 & 10
        ElseIf (mainDuJoueur(4, 1) >= 1 And mainDuJoueur(4, 1) <= 8) Then
            txtCarte51.Text += (mainDuJoueur(4, 1) + 1).ToString()
            txtCarte52.Text += (mainDuJoueur(4, 1) + 1).ToString()

            ' TEN
        ElseIf (mainDuJoueur(4, 1) = 9) Then
            txtCarte51.Text += "T"
            txtCarte52.Text += "T"

            ' JACK
        ElseIf (mainDuJoueur(4, 1) = 10) Then
            txtCarte51.Text += "J"
            txtCarte52.Text += "J"

            ' QUEEN
        ElseIf (mainDuJoueur(4, 1) = 11) Then
            txtCarte51.Text += "Q"
            txtCarte52.Text += "Q"

            ' KING
        ElseIf (mainDuJoueur(4, 1) = 12) Then
            txtCarte51.Text += "K"
            txtCarte52.Text += "K"

        End If

    End Sub

    ' Repige les cartes selon la demande du joueur ( En lien avec les CheckBox )
    Private Sub switchCards()


        ' *** CARTE 1 ***
        If (checkCarte1.Checked = False) Then
            Dim carteNonValide = True

            While (carteNonValide)
                Dim c As Integer = valueGenerator.Next(0, 4)
                Dim v As Integer = valueGenerator.Next(0, 13)
                Dim maCarte As String = c.ToString() + v.ToString()

                If (validerCarte(maCarte, nbrCartes)) Then
                    arrayCartes(nbrCartes) = maCarte

                    mainDuJoueur(0, 0) = c
                    mainDuJoueur(0, 1) = v

                    carteNonValide = False
                End If
            End While

            nbrCartes += 1
        End If


        ' *** CARTE 2 ***
        If (checkCarte2.Checked = False) Then
            Dim carteNonValide = True

            While (carteNonValide)
                Dim c As Integer = valueGenerator.Next(0, 4)
                Dim v As Integer = valueGenerator.Next(0, 13)
                Dim maCarte As String = c.ToString() + v.ToString()

                If (validerCarte(maCarte, nbrCartes)) Then
                    arrayCartes(nbrCartes) = maCarte

                    mainDuJoueur(1, 0) = c
                    mainDuJoueur(1, 1) = v

                    carteNonValide = False
                End If
            End While

            nbrCartes += 1
        End If


        ' *** CARD 3 ***
        If (checkCarte3.Checked = False) Then
            Dim carteNonValide = True

            While (carteNonValide)
                Dim c As Integer = valueGenerator.Next(0, 4)
                Dim v As Integer = valueGenerator.Next(0, 13)
                Dim maCarte As String = c.ToString() + v.ToString()

                If (validerCarte(maCarte, nbrCartes)) Then
                    arrayCartes(nbrCartes) = maCarte

                    mainDuJoueur(2, 0) = c
                    mainDuJoueur(2, 1) = v

                    carteNonValide = False
                End If
            End While

            nbrCartes += 1
        End If


        ' *** CARD 4 ***
        If (checkCarte4.Checked = False) Then
            Dim carteNonValide = True

            While (carteNonValide)
                Dim c As Integer = valueGenerator.Next(0, 4)
                Dim v As Integer = valueGenerator.Next(0, 13)
                Dim maCarte As String = c.ToString() + v.ToString()

                If (validerCarte(maCarte, nbrCartes)) Then
                    arrayCartes(nbrCartes) = maCarte

                    mainDuJoueur(3, 0) = c
                    mainDuJoueur(3, 1) = v

                    carteNonValide = False
                End If
            End While

            nbrCartes += 1
        End If


        ' *** CARD 5 ***
        If (checkCarte5.Checked = False) Then
            Dim carteNonValide = True

            While (carteNonValide)
                Dim c As Integer = valueGenerator.Next(0, 4)
                Dim v As Integer = valueGenerator.Next(0, 13)
                Dim maCarte As String = c.ToString() + v.ToString()

                If (validerCarte(maCarte, nbrCartes)) Then
                    arrayCartes(nbrCartes) = maCarte

                    mainDuJoueur(4, 0) = c
                    mainDuJoueur(4, 1) = v

                    carteNonValide = False
                End If
            End While

            nbrCartes += 1
        End If

        ' Assigne la bonne valeur aux aces...
        assignAcesValue()

        ' Trie les cartes en ordre croissant de valeur...
        sort()

        ' Donne un retour visuel des valeurs de nos cartes...
        assosiateImage()

    End Sub

    ' Vérifie si la main du joueur est une Royal Flush
    Private Function isRoyalFlush() As Boolean

        ' ROYAL FLUSH
        Dim win = True

        For i = 0 To 3
            If Not (mainDuJoueur(i, 0) = mainDuJoueur(i + 1, 0) And mainDuJoueur(i, 1) = (mainDuJoueur(i + 1, 1) - 1) And (mainDuJoueur(0, 1) = 9)) Then
                win = False
            End If
        Next

        If (win) Then
            annoncerGains(10)
            Return True
        End If


        Return False
    End Function

    ' Vérifie si la main du joueur est une Straight Flush
    Private Function isStraightFlush() As Boolean

        ' STRAIGHT FLUSH
        Dim win = True

        For i = 0 To 3
            If Not (mainDuJoueur(i, 0) = mainDuJoueur(i + 1, 0) And mainDuJoueur(i, 1) = (mainDuJoueur(i + 1, 1) - 1)) Then
                win = False
            End If
        Next

        If (win) Then
            annoncerGains(9)
            Return True
        End If

        Return False

    End Function

    ' Vérifie si la main du joueur est un Quadruple
    Private Function isFourOfAKind() As Boolean

        ' FOUR OF A KIND

        For i = 0 To 1
            If (mainDuJoueur(i, 1) = mainDuJoueur(i + 1, 1) And mainDuJoueur(i + 1, 1) = mainDuJoueur(i + 2, 1) And mainDuJoueur(i + 2, 1) = mainDuJoueur(i + 3, 1)) Then
                annoncerGains(8)
                Return True
            End If
        Next

        Return False

    End Function

    ' Vérifie si la main du joueur est un Full House
    Private Function isFullHouse() As Boolean

        ' FULL HOUSE

        If (mainDuJoueur(0, 1) = mainDuJoueur(1, 1)) And (mainDuJoueur(2, 1) = mainDuJoueur(3, 1) And mainDuJoueur(3, 1) = mainDuJoueur(4, 1)) Then
            annoncerGains(7)
            Return True

        ElseIf (mainDuJoueur(0, 1) = mainDuJoueur(1, 1) And mainDuJoueur(1, 1) = mainDuJoueur(2, 1)) And (mainDuJoueur(3, 1) = mainDuJoueur(4, 1)) Then
            annoncerGains(7)
            Return True

        End If

        Return False

    End Function

    ' Vérifie si la main du joueur est une Flush
    Private Function isFlush() As Boolean

        ' FLUSH

        Dim win = True

        For i = 0 To 3
            If Not (mainDuJoueur(i, 0) = mainDuJoueur(i + 1, 0)) Then
                win = False
            End If
        Next

        If (win) Then
            annoncerGains(6)
            Return True
        End If

        Return False

    End Function

    ' Vérifie si la main du joueur est une Straight
    Private Function isStraight() As Boolean

        ' STRAIGHT

        Dim win = True

        For i = 0 To 3
            If Not (mainDuJoueur(i, 1) = mainDuJoueur(i + 1, 1) - 1) Then
                win = False
            End If
        Next

        If (win) Then
            annoncerGains(5)
            Return True
        End If

        Return False

    End Function

    ' Vérifie si la main du joueur est un Triple
    Private Function isThreeOfAKind() As Boolean

        ' THREE OF A KIND

        For i = 0 To 2

            If (mainDuJoueur(i, 1) = mainDuJoueur(i + 1, 1) And mainDuJoueur(i + 1, 1) = mainDuJoueur(i + 2, 1)) Then
                annoncerGains(4)
                Return True
            End If

        Next

        Return False

    End Function

    ' Vérifie si la main du joueur est Deux Pairs
    Private Function isTwoPair() As Boolean

        ' TWO PAIRS

        ' Deux pairs collées 
        For i = 0 To 1
            If (mainDuJoueur(i, 1) = mainDuJoueur(i + 1, 1) And (mainDuJoueur(i + 2, 1) = mainDuJoueur(i + 3, 1))) Then
                annoncerGains(3)
                Return True
            End If
        Next

        ' Deux pairs avec un espace au milieu
        If (mainDuJoueur(0, 1) = mainDuJoueur(1, 1) And (mainDuJoueur(3, 1) = mainDuJoueur(4, 1))) Then
            annoncerGains(3)
            Return True
        End If

        Return False

    End Function

    ' Vérifie si la main du jouer est une Paire de Valet,Queen,King,Ace
    Private Function isPairAbove10() As Boolean
        ' PAIR HIGHER THAN JACK

        For i = 0 To 3

            ' Pair de J,Q,K,A
            If (mainDuJoueur(i, 1) = mainDuJoueur(i + 1, 1) And mainDuJoueur(i, 1) > 9) Then
                annoncerGains(2)
                Return True
            End If

            ' Pair d'as avec valeur de 0 
            If (mainDuJoueur(0, 1) = mainDuJoueur(1, 1) And mainDuJoueur(0, 1) = 0) Then
                annoncerGains(2)
                Return True
            End If

        Next

        Return False

    End Function

    ' Associe la bonne valeur aux aces... Dépadement des autres valeurs de cartes
    Private Sub assignAcesValue()

        ' Assigning proper value to aces


        Dim Ace As Boolean = True
        Dim compteurCardValue = 0

        ' On compte la valeur numérique additionnée des cartes
        For i = 0 To 3
            compteurCardValue += mainDuJoueur(i, 1)
        Next

        ' si la valeur cumulé des carte est inférieur à 30... une suite ACE,2,3,4,5 est possible
        ' Donc si la valeur est plus haute que 30, la petite suite impossible, l'as prend la valeur de 13 pour faciliter le travail par la suite

        If compteurCardValue >= 30 Then

            For i = 0 To 4
                If (mainDuJoueur(i, 1) = 0) Then
                    mainDuJoueur(i, 1) = 13
                End If
            Next

        End If

    End Sub

    ' Pour chaque différents gains possible, appelle la fonction qui détérmine si un jeu est gagné, jusqu'a ce que un soit trouvé ( sinon sans gains )
    Private Sub evaluateHand()

        Dim jeuGagnant As Boolean = False
        ' Quand jeu gagnant deviendra vrai, le reste des demandes seronts ignorées

        jeuGagnant = isRoyalFlush()

        If Not (jeuGagnant) Then
            jeuGagnant = isStraightFlush()
        End If
        If Not (jeuGagnant) Then
            jeuGagnant = isFourOfAKind()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isFullHouse()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isFlush()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isStraight()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isThreeOfAKind()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isTwoPair()
        End If

        If Not (jeuGagnant) Then
            jeuGagnant = isPairAbove10()
        End If
        If Not (jeuGagnant) Then
            annoncerGains(1)
        End If

    End Sub

    ' Annonce les gains à l'utilisateur, envois les crédits
    Private Sub annoncerGains(prize As Integer)

        Dim prix As Integer = 0

        Select Case prize

            Case 10 ' ROYAL FLUSH
                prix = 500 * miseActuelle
                MsgBox($"Vous avez gagné ! ROYAL FLUSH - {prix} crédits")
                creditUtilisateur += prix

            Case 9 ' STRAIGHT FLUSH
                prix = 100 * miseActuelle
                MsgBox($"Vous avez gagné ! STRAIGHT FLUSH - {prix} crédits")
                creditUtilisateur += prix

            Case 8 ' FOR OF A KIND
                prix = 50 * miseActuelle
                MsgBox($"Vous avez gagné ! FOUR OF A KIND - {prix} crédits")
                creditUtilisateur += prix

            Case 7 ' FULL HOUSE
                prix = 25 * miseActuelle
                MsgBox($"Vous avez gagné ! FULL HOUSE - {prix} crédits")
                creditUtilisateur += prix

            Case 6 ' FLUSH
                prix = 20 * miseActuelle
                MsgBox($"Vous avez gagné ! FLUSH - {prix} crédits")
                creditUtilisateur += prix

            Case 5 ' STRAIGHT
                prix = 15 * miseActuelle
                MsgBox($"Vous avez gagné ! STRAIGHT - {prix} crédits")
                creditUtilisateur += prix

            Case 4 ' THREE OF A KIND
                prix = 5 * miseActuelle
                MsgBox($"Vous avez gagné ! THREE OF A KIND - {prix} crédits")
                creditUtilisateur += prix

            Case 3 ' TWO PAIRS
                prix = 3 * miseActuelle
                MsgBox($"Vous avez gagné ! TWO PAIRS - {prix} crédits")
                creditUtilisateur += prix

            Case 2 ' SINGLE PAIR ABOVE TEN
                prix = 1 * miseActuelle
                MsgBox($"Vous avez gagné ! PAIR - Jack or higher - {prix} crédits")
                creditUtilisateur += prix

            Case 1
                MsgBox("Vous n'avez pas gagné ! Auncun gains")

        End Select

        lblCredit.Text = creditUtilisateur.ToString()
    End Sub



End Class
