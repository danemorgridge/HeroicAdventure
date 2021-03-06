Imports HA.Common.Enumerations

#Region " Item Base Class "

Public MustInherit Class ItemBase

    Public Sub New()
        ItemState = DivineState.Normal
    End Sub

    'TODO: Add code to increase / decrease weight in equippedweight and backpackweight whenever an equippable item is activated / deactivated
    Public Property Type() As ItemType
    Public Property Color() As ConsoleColor
    Public Property Symbol() As String

    Public Property IsBreakable() As Boolean
    Public Property IsPaper() As Boolean
    Public Property IsRustable() As Boolean
    Public Property IsLiquid() As Boolean
    Public Property IsPoisonable() As Boolean
    Public Property IsDirty() As Boolean

    Public Property Missle() As Boolean
    Public Property Tool() As Boolean
    Public Property Weight() As Single
    Public Property Quantity() As Integer
    Public Property Walkover() As String
    Public Property Damage() As String
    Public Property Name() As String
    Public Property Identified() As Boolean
    Public Property StatBonus() As Integer
    Public Property HasCharges() As Boolean
    Public Property Charges() As Integer
    Public Property Flammable() As Boolean
    Public Property MarketValue() As Integer
    Public Property ACBonus() As Integer
    Public Property AtkBonus() As Integer
    Public Property ItemState() As DivineState
    Public Property Rusted As Boolean

    Public Property IsPoisoned() As Boolean
    Public Property Poison() As PoisonType
    Public Property PoisonDMGMultiple As Int16

    Public Function Curse(ByVal whoIsCursing As Avatar, Optional ByVal strMessage As String = "") As String
        'TODO: Curse item by spell or effect

        Return strMessage
    End Function

    ' Bless an item by spell
    Public Function Bless(ByVal whoIsCasting As Avatar, Optional ByVal strMessage As String = "") As String
        'TODO: Bless item by spell or effect
        Dim SecondaryMessage As String = ""

        Select Case Me.ItemState
            Case DivineState.Normal
                Me.ItemState = DivineState.Blessed
                secondaryMessage = "You feel good about the " + Me.Name + ". You feel as though your god is pleased with you. "
                'TODO: implement piety change for adding a blessing to an item.

            Case DivineState.Cursed
                Me.ItemState = DivineState.Normal
                secondaryMessage = "You feel better about the " + Me.Name + ". "

            Case DivineState.Blessed
                Me.ItemState = DivineState.Blessed
                secondaryMessage = "You don't feel any different about the " + Me.Name + ". "
        End Select

        strMessage += "The " + Me.Name + " glows brightly for a moment. " + SecondaryMessage

        Return strMessage
    End Function

    ' Dipping an item into Holy Water will Bless it
    Public Function Bless(ByVal DippedInto As Potion, Optional ByVal strMessage As String = "") As String
        Dim secondaryMessage As String = ""

        If DippedInto.ItemState = DivineState.Blessed AndAlso DippedInto.Name = "water" Then

            Select Case Me.ItemState
                Case DivineState.Normal
                    Me.ItemState = DivineState.Blessed
                    secondaryMessage = "You feel good about the " + Me.Name + ". You feel as though your god is pleased with you. "
                'TODO: implement piety change for adding a blessing to an item.

                Case DivineState.Cursed
                    Me.ItemState = DivineState.Normal
                    secondaryMessage = "You feel better about the " + Me.Name + ". "

                Case DivineState.Blessed
                    Me.ItemState = DivineState.Blessed
                    secondaryMessage = "You don't feel any different about the " + Me.Name + ". "

            End Select
        End If

        If DippedInto.ItemState = DivineState.Cursed AndAlso DippedInto.Name = "water" Then

            Select Case Me.ItemState
                Case DivineState.Normal
                    Me.ItemState = DivineState.Cursed
                    secondaryMessage = "You have a bad feeling about the " + Me.Name + ". "

                Case DivineState.Cursed
                    Me.ItemState = DivineState.Cursed
                    secondaryMessage = "You don't feel any different about the " + Me.Name + ". "

                Case DivineState.Blessed
                    Me.ItemState = DivineState.Normal
                    secondaryMessage = "The " + DippedInto.Name + " begins to bubble and hiss. You feel as if your god is disappointed in you. "
                    'TODO: implement piety change for removing a blessing from an item.
            End Select
        End If

        strMessage += "You dip the " + Me.Name + " into the " + DippedInto.Name + ". " + secondaryMessage

        Return strMessage

        'TODO: Destroy potion after dipping something into it.
    End Function

    Public Function Destroy(ByVal DippedInto As Potion, Optional ByVal strMessage As String = "") As String
		strMessage &= String.Format("The {0} is destroyed when you dip it into the {1}.", Name, DippedInto.Name)

		'''If itemArray(intItemIndex).quantity = 1 Then
		'''    TheHero.Equipment.BackPack.Remove(itemArray(intItemIndex))
		'''    itemArray.RemoveAt(intItemIndex)

		'''ElseIf itemArray(intItemIndex).quantity > 1 Then
		'''    TheHero.Equipment.BackPack.Remove(itemArray(intItemIndex))
		'''    itemArray(intItemIndex).quantity -= 1
		'''    TheHero.Equipment.BackPack.Add(itemArray(intItemIndex))
		'''End If

		'TODO: Fix item destruction when dipped into liquid

		Return strMessage
	End Function

    Public Function Rust(ByVal DippedInto As PoWater, Optional ByVal strMessage As String = "") As String
        If IsRustable Then
            Rusted = True
        End If
        ' TODO: Rusted items should have a higher break chance
        ' TODO: Hero luck should affect rust chance

        Return strMessage
    End Function

    Public Function Mix(ByVal DippedInto As Potion, Optional ByVal strMessage As String = "") As String
		' TODO: Mix potions
		Return strMessage
	End Function

	Public Function Clean(ByVal DippedInto As Potion, Optional ByVal strMessage As String = "") As String
		' TODO: Clean something
		Return strMessage
	End Function

    Public Function ApplyPoison(ByVal DippedInto As PoPoison, Optional ByVal strMessage As String = "") As String
        If IsPoisonable Then
            IsPoisoned = True
            Poison = DippedInto.PoisonType
            PoisonDMGMultiple = DippedInto.DMGMultiple

            strMessage += "You successfully apply the poison to your " + Me.Name + ". "
        Else
            strMessage += "You are unable to apply poison to the " + Me.Name + ". "
        End If

        'TODO: should applied poison expire?
        'TODO: Should attacking a poisonous monster trigger ApplyPoison?

        Return strMessage
    End Function

End Class

#End Region


