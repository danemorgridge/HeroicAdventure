Public Class HornedHelmet
    Inherits Helmet

    Public Sub New()
        MyBase.New()

        Name = "horned helmet"
        Walkover = Name
        Weight = 3
	End Sub

	Public Overrides Sub activate(whoIsActivating As Avatar)
		whoIsActivating.MiscACMod += ACBonus
	End Sub

	Public Overrides Sub deactivate(whoIsDeactivating As Avatar)
		whoIsDeactivating.MiscACMod -= ACBonus
	End Sub
End Class
